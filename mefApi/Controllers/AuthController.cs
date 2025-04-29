using AutoMapper;
using mefApi.Controllers;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace mefapi.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public AuthController(IMapper mapper, IUnitOfWork uow, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginReqDto loginReqDto)
        {
            var utilisateur = await uow.UtilisateurRepository.Authenticate(loginReqDto.Login);

            if (utilisateur is null)
            {
                throw new UnauthorizedAccessException("Cet utilisateur n'existe pas dans la base");
            }

            if (
                utilisateur.MotDePasse is not null &&
                utilisateur.ClesMotDePasse is not null &&
                !MatchPasswordHash(loginReqDto.Password, utilisateur.MotDePasse, utilisateur.ClesMotDePasse)
            )
            {
                throw new UnauthorizedAccessException("Le mot de passe est invalide");
            }


            var loginResDto = new LoginResDto();
            loginResDto.Token = CreateJWT(utilisateur, 1);
            loginResDto.RefreshToken = CreateJWT(utilisateur, 24);

            return Ok(loginResDto);
        }

        private string CreateJWT(Utilisateur utilisateur, int expiration)
        {
            var secretKey = configuration.GetSection("AppSettings:Key").Value;

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("La clé secrète pour le JWT est introuvable ou vide.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(utilisateur.NomUtilisateur))
            {
                claims.Add(new Claim(ClaimTypes.Name, utilisateur.NomUtilisateur));
            }

            claims.Add(new Claim(ClaimTypes.NameIdentifier, utilisateur.Id.ToString()));

            var signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(expiration),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private bool MatchPasswordHash(string passworText, byte[] password, byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {
                var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passworText));

                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (password[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }
    }
}
