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
    public class AvanceController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AvanceController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var avance = await uow.AvanceRepository.FindByIdAsync(id);
            if(avance is null) {
                return NotFound();
            }
            var avanceDto = mapper.Map<AvanceDto>(avance);
            return Ok(avanceDto);
        }

        [HttpGet("avances")]
        public async Task<IActionResult> GetAll()
        {
            var avances = await uow.AvanceRepository.GetAllAsync();
            if(avances is null) {
                return NotFound();
            }
            var avancesDto = mapper.Map<IEnumerable<AvanceDto>>(avances);
            return Ok(avancesDto);
        }

        [HttpGet("membres")]
        public async Task<IActionResult> GetAllAvances()
        {
            var membres = await uow.MembreRepository.GetByEtatAsync(true);
            if(membres is null) {
                return NotFound();
            }
            var membresDto = mapper.Map<IEnumerable<MembreDto>>(membres);
            return Ok(membresDto);
        }

        [HttpGet("echeances")]
        public async Task<IActionResult> GetAllEcheances()
        {
            var echeances = await uow.EcheanceAvanceRepository.GetAllAsync();
            if(echeances is null) {
                return NotFound();
            }
            var echeancesDto = mapper.Map<IEnumerable<EcheanceAvanceDto>>(echeances);
            return Ok(echeancesDto);
        }

        [HttpGet("echeances/{avanceId}")]
        public async Task<IActionResult> GetAllEcheancesAvance(int avanceId)
        {
            var echeances = await uow.EcheanceAvanceRepository.GetAllByAvanceAsync(avanceId);
            if(echeances is null) {
                return NotFound();
            }
            var echeancesDto = mapper.Map<IEnumerable<EcheanceAvanceDto>>(echeances);
            return Ok(echeancesDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AvanceDto avanceDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var avance = mapper.Map<Avance>(avanceDto);
            uow.AvanceRepository.Add(avance);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPost("addecheances")]
        public async Task<IActionResult> AddEcheances(EcheanceAvanceDto[] echeanceAvancesDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            foreach(var echeanceDto in echeanceAvancesDto) {
                var echeance = mapper.Map<EcheanceAvance>(echeanceDto);
                if(echeanceDto.Id == 0) {
                    uow.EcheanceAvanceRepository.Add(echeance);
                }else{
                    if(echeanceDto.Id != 0) {
                        var echeanceFromDb = await uow.EcheanceAvanceRepository.FindByIdAsync(echeanceDto.Id);
                         mapper.Map(echeanceDto, echeanceFromDb);
                    }
                }
            }
            
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPost("addmvtcomptes")]
        public async Task<IActionResult> AddMvtComptes(MvtCompteDto[] mvtsDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            foreach(var mvtDto in mvtsDto) {
                var mvt = mapper.Map<MvtCompte>(mvtDto);
                uow.MvtCompteRepository.Add(mvt);
            }
            
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,AvanceDto avanceDto)
        {
            if(id != avanceDto.Id) 
                return BadRequest("Update not allowed");

            var avanceFromDb = await uow.AvanceRepository.FindByIdAsync(id);
            
            if(avanceFromDb == null) 
                return BadRequest("Update not allowed");

            mapper.Map(avanceDto, avanceFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }
    }
}