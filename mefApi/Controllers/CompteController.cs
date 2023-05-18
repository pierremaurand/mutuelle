using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace mefApi.Controllers
{
    public class CompteController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CompteController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpPost("addmvts")]
        public async Task<IActionResult> AddMvts(MvtCompteDto[] mvtcomptesDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            foreach(var mvtCompteDto in mvtcomptesDto) {
                if(mvtCompteDto.Id == 0) {
                    var mvtCompte = mapper.Map<MvtCompte>(mvtCompteDto);
                    uow.MvtCompteRepository.Add(mvtCompte);
                }
            }
            
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpGet("membres")]
        public async Task<IActionResult> GetAllMembres()
        {
            var membres = await uow.MembreRepository.GetByEtatAsync(true);
            if(membres is null) {
                return NotFound();
            }
            var membresDto = mapper.Map<IEnumerable<MembreListDto>>(membres);
            return Ok(membresDto);
        }

        [HttpGet("comptes")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllComptes()
        {
            var membres = await uow.MembreRepository.GetAllAsync();
            var comptesListDto = new List<ComptesListDto>();
            if(membres is null) {
                return NotFound();
            }
            foreach(var membre in membres) {
                var compte = new ComptesListDto();
                compte.Membre = mapper.Map<MembreListDto>(membre);
                comptesListDto.Add(compte);
            }
            return Ok(comptesListDto);
        }

        [HttpGet("mvtcomptes")]
        public async Task<IActionResult> GetAllMvtComptes()
        {
            var mvtcomptes = await uow.MvtCompteRepository.GetAllAsync();
            if(mvtcomptes is null) {
                return NotFound();
            }
            var mvtcomptesDto = mapper.Map<IEnumerable<MvtCompteDto>>(mvtcomptes);
            return Ok(mvtcomptesDto);
        }

        [HttpGet("mvtcomptes/{id}")]
        public async Task<IActionResult> GetAllMvtsById(int id)
        {
            var mvtcomptes = await uow.MvtCompteRepository.GetAllByMembreAsync(id);
            if(mvtcomptes is null) {
                return NotFound();
            }
            var mvtcomptesDto = mapper.Map<IEnumerable<MvtCompteDto>>(mvtcomptes);
            return Ok(mvtcomptesDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(id);
            if(membre is null) {
                return NotFound();
            }
            var membreDto = mapper.Map<MembreDto>(membre);
            return Ok(membreDto);
        }

    }
}