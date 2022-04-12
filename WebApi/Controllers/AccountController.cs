using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.Dtos;
using WebApi.Errors;
using WebApi.Extensions;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;
        public AccountController(IUnitOfWork uow, IConfiguration configuration)
        {
            this.uow = uow;
            this.configuration = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginReqDto loginReq) 
        {
            var user = await uow.UserRepository.Authenticate(loginReq.Email, loginReq.Password);
            ApiError apiError = new ApiError();
            
            if(user == null)
            {
                apiError.ErrorCode = Unauthorized().StatusCode;
                apiError.ErrorMessage = "Invalid User ID or Password";
                apiError.ErrorDetails = "This error appear when provided user id or password does not exists";
                return Unauthorized(apiError);
            }

            var loginRes = new LoginResDto();
            loginRes.UserName = user.UserName;
            loginRes.Token = CreateJWT(user);
            return Ok(loginRes);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserReqDto user) 
        {
            ApiError apiError = new ApiError();

            if (user.Email.isEmpty() || user.Password.isEmpty() || user.UserName.isEmpty()){
                apiError.ErrorCode = BadRequest().StatusCode;
                apiError.ErrorMessage = "User name, email or password can not be blank";
                 return BadRequest(apiError);
            }

            if (await uow.UserRepository.UserAlreadyExists(user.Email)){
                apiError.ErrorCode = BadRequest().StatusCode;
                apiError.ErrorMessage = "User already exists, please try somthing else";
                 return BadRequest(apiError);
            }
               
            
            uow.UserRepository.Register(user, user.Password);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        private string CreateJWT(User user) {
            var secretKey = this.configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secretKey));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor(){
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}