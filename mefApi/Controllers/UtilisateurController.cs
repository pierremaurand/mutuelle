using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace mefApi.Controllers
{
    public class UtilisateurController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public UtilisateurController(IMapper mapper, IUnitOfWork uow, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("utilisateurs")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var utilisateurs = await uow.UtilisateurRepository.GetAllAsync();
            var utilisateursListDto = new List<UtilisateurListDto>();
            if(utilisateurs is null) {
                return NotFound();
            }
            foreach(var utilisateur in utilisateurs) {
                var membre = await uow.MembreRepository.FindByIdAsync(utilisateur.MembreId);
                if(membre is not null) {
                    var utilisateurListDto = new UtilisateurListDto();
                    utilisateurListDto.Id = utilisateur.Id;
                    utilisateurListDto.NomUtilisateur = utilisateur.NomUtilisateur;
                    utilisateurListDto.Membre = mapper.Map<MembreListDto>(membre);
                    utilisateursListDto.Add(utilisateurListDto);
                }
            }
            return Ok(utilisateursListDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var utilisateur = await uow.UtilisateurRepository.FindByIdAsync(id);
            if(utilisateur is null) {
                return NotFound();
            }
            var utilisateurDto = mapper.Map<UtilisateurDto>(utilisateur);
            return Ok(utilisateurDto);
        }

        [HttpGet("getmembre")]
        public async Task<IActionResult> GetMembre()
        {
            var id = GetUserId();
            var utilisateur = await uow.UtilisateurRepository.FindByIdAsync(id);
            if(utilisateur is null) {
                return NotFound();
            }

            var membre = await uow.MembreRepository.FindByIdAsync(utilisateur.MembreId);
            if(membre is null) {
                return NotFound();
            }

            var membreListDto = mapper.Map<MembreListDto>(membre);
            return Ok(membreListDto);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginReqDto loginReqDto)
        {   
            var utilisateur = await uow.UtilisateurRepository.Authenticate(loginReqDto.Login);

            if(utilisateur is null) {
                return Unauthorized();
            }

            if(
                utilisateur.MotDePasse is not null && 
                utilisateur.ClesMotDePasse is not null && 
                !MatchPasswordHash(loginReqDto.Password,utilisateur.MotDePasse,utilisateur.ClesMotDePasse)
            ) {
                 return Unauthorized();
            }
               

            var loginResDto = new LoginResDto();
            loginResDto.Nom = utilisateur.NomUtilisateur;
            loginResDto.Token = CreateJWT(utilisateur);

            return Ok(loginResDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(UtilisateurDto utilisateurDto)
        {   
            if(!ModelState.IsValid || utilisateurDto.Password != utilisateurDto.ConfirmPassword) 
                return BadRequest(ModelState);
            
            if(await uow.UtilisateurRepository.UtilisateurExists(utilisateurDto)) 
                return BadRequest("Cet utilisateur existe déjà, veillez choisir un autre.");

            byte[] passwordHash, passwordKey;

            using(var hmac = new HMACSHA512()){
               passwordKey = hmac.Key;
               passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(utilisateurDto.Password));
            }

            var utilisateur = mapper.Map<Utilisateur>(utilisateurDto);
            utilisateur.MotDePasse = passwordHash;
            utilisateur.ClesMotDePasse = passwordKey;
            utilisateur.ModifiePar = GetUserId();
            utilisateur.ModifieLe = DateTime.Now;
            uow.UtilisateurRepository.Add(utilisateur);
            await uow.SaveAsync();
            return StatusCode(201);

        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,UtilisateurDto utilisateurDto)
        {   
            if(id != utilisateurDto.Id) 
                return BadRequest("Update not allowed");

            var utilisateurFromDb = await uow.UtilisateurRepository.FindByIdAsync(id);
            
            if(utilisateurFromDb == null) 
                return BadRequest("Update not allowed");

            utilisateurFromDb.ModifiePar = GetUserId();
            utilisateurFromDb.ModifieLe = DateTime.Now;
            mapper.Map(utilisateurDto, utilisateurFromDb);
            await uow.SaveAsync();
            return StatusCode(200);

        }

        private string CreateJWT(Utilisateur utilisateur){
            var secretKey = configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new Claim[]{
                new Claim(ClaimTypes.Name, utilisateur.NomUtilisateur),
                new Claim(ClaimTypes.NameIdentifier, utilisateur.Id.ToString())
            };

            var signingCredentials = new SigningCredentials(
                key,SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private bool MatchPasswordHash(string passworText, byte[] password, byte[] passwordKey) 
        {
            using(var hmac = new HMACSHA512(passwordKey)){
               var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passworText));
            
               for(int i=0; i<passwordHash.Length; i++) 
               {
                    if(password[i] != passwordHash[i]) 
                        return false;
               }
            }
            return true;
        }
    }
}