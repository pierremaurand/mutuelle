using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace mefApi.Controllers
{
    public class MvtMvtCompteController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public MvtMvtCompteController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("mvtcomptes")]
        public async Task<IActionResult> GetAll()
        {
            var mvtcomptes = await uow.MvtCompteRepository.GetAllAsync();
            if(mvtcomptes is null) {
                return NotFound();
            }
            var mvtcomptesDto = mapper.Map<IEnumerable<MvtCompteDto>>(mvtcomptes);
            return Ok(mvtcomptesDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var mvtcompte = await uow.MvtCompteRepository.FindByIdAsync(id);
            if(mvtcompte is null) {
                return NotFound();
            }
            var mvtcompteDto = mapper.Map<MvtCompteDto>(mvtcompte);
            return Ok(mvtcompteDto);
        }
        

        [HttpPost("add")]
        public async Task<IActionResult> Add(MvtCompteDto mvtcompteDto)
        {
            var mvtcompte = mapper.Map<MvtCompte>(mvtcompteDto);
            mvtcompte.CreePar = 1;
            mvtcompte.ModifiePar = 1;
            mvtcompte.ModifieLe = DateTime.Now;

            uow.MvtCompteRepository.Add(mvtcompte);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPost("addmvtcomptes/{compteId}")]
        public async Task<IActionResult> AddMvtcomptes(int compteId,MvtCompteDto[] mvtcomptesDto)
        {
            var mvtcomptes = mapper.Map<MvtCompte[]>(mvtcomptesDto);
            var compteFromDb = await uow.CompteRepository.FindByIdAsync(compteId);
            if(compteFromDb is not null){
                 foreach(MvtCompte mvtCompte in mvtcomptes){
                    mvtCompte.Compte = compteFromDb;
                    mvtCompte.CreePar = 1;
                    mvtCompte.ModifiePar = 1;
                    mvtCompte.ModifieLe = DateTime.Now;
                    uow.MvtCompteRepository.Add(mvtCompte);
                }
            }
            
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,MvtCompteDto mvtcompteDto)
        {
            if(id != mvtcompteDto.Id) 
                return BadRequest("Update not allowed");

            var mvtcompteFromDb = await uow.MvtCompteRepository.FindByIdAsync(id);
            
            if(mvtcompteFromDb == null) 
                return BadRequest("Update not allowed");

            mvtcompteFromDb.ModifiePar = 1;
            mvtcompteFromDb.ModifieLe = DateTime.Now;
            mapper.Map(mvtcompteDto, mvtcompteFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            uow.MvtCompteRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}