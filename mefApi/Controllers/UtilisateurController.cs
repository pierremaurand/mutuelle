using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var utilisateurs = await uow.UtilisateurRepository.GetAllAsync();
            if(utilisateurs is null) {
                return NotFound("Aucun utilisateurs n'est enregistré dans la bdd");
            }
            var utilisateursDto = mapper.Map<List<UtilisateurDto>>(utilisateurs);
            return Ok(utilisateursDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var utilisateur = await uow.UtilisateurRepository.FindByIdAsync(id);
            if(utilisateur is null) {
                return NotFound();
            }
            var utilisateurDto = mapper.Map<UtilisateurDto>(utilisateur);
            return Ok(utilisateurDto);
        }

        [HttpPost("add")]
        [AllowAnonymous]
        public async Task<IActionResult> Add(UtilisateurDto utilisateurDto)
        {   
            if(!ModelState.IsValid) 
                throw new InvalidOperationException();
            
            if(await uow.UtilisateurRepository.UtilisateurExists(utilisateurDto)) 
                return BadRequest("Cet utilisateur existe déjà, veillez choisir un autre.");

            byte[] passwordHash, passwordKey;

            using(var hmac = new HMACSHA512()){
               passwordKey = hmac.Key;
               passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(utilisateurDto.Password??"mutuelle"));
            }

            Utilisateur utilisateur = new Utilisateur();
            utilisateur.Login = utilisateurDto.Login;
            utilisateur.Role = utilisateurDto.Role;
            utilisateur.Password = passwordHash;
            utilisateur.PasswordKey = passwordKey;
            // utilisateur.ModifiePar = GetUserId();
            utilisateur.ModifiePar = 0;
            utilisateur.ModifieLe = DateTime.Now;
            uow.UtilisateurRepository.Add(utilisateur);
            await uow.SaveAsync();
            return StatusCode(201);

        }

        [HttpPut("initPassword/{id}")]
        public async Task<IActionResult> InitPassword(int id, UtilisateurDto utilisateurDto) {
            if(id != utilisateurDto.Id) {
                return BadRequest("Reinitialisation impossible!");
            }

            byte[] passwordHash, passwordKey;

            var utilisateur = await uow.UtilisateurRepository.FindByIdAsync(id);
            if(utilisateur is null) {
                return NotFound("Cet utilisateur n'existe pas dans la base de données");
            }

            using(var hmac = new HMACSHA512()){
               passwordKey = hmac.Key;
               passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("mutuelle"));
            }

            utilisateur.Password = passwordHash;
            utilisateur.PasswordKey = passwordKey;
            utilisateur.ModifiePar = GetUserId();
            utilisateur.ModifieLe = DateTime.Now;
            await uow.SaveAsync();
            return StatusCode(200);
        }

        /*[HttpPut("changePassword")]
        public async Task<IActionResult> changePassword(InfosPassword infos) {
            if(!ModelState.IsValid || infos.Password != infos.ConfirmPassword) {
                return BadRequest("Changement de mot de passe impossible!");
            }

            var id = GetUserId();

            var utilisateur = await uow.UtilisateurRepository.FindByIdAsync(id);
            if(utilisateur is null) {
                return NotFound("Cet utilisateur n'existe pas dans la base de données");
            }

            byte[] passwordHash, passwordKey;

            using(var hmac = new HMACSHA512()){
               passwordKey = hmac.Key;
               passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(infos.Password));
            }

            utilisateur.MotDePasse = passwordHash;
            utilisateur.ClesMotDePasse = passwordKey;
            utilisateur.ModifiePar = GetUserId();
            utilisateur.ModifieLe = DateTime.Now;
            await uow.SaveAsync();
            return StatusCode(200);
        }*/

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
    }
}