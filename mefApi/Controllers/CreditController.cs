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
    public class CreditController : BaseController
    {
         private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CreditController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var credit = await uow.CreditRepository.FindByIdAsync(id);
            if(credit is null) {
                return NotFound();
            }
            var creditDto = mapper.Map<CreditDto>(credit);
            return Ok(creditDto);
        }

        [HttpGet("credits")]
        public async Task<IActionResult> GetAll()
        {
            var credits = await uow.CreditRepository.GetAllAsync();
            if(credits is null) {
                return NotFound();
            }
            var creditsDto = mapper.Map<IEnumerable<CreditDto>>(credits);
            return Ok(creditsDto);
        }

        [HttpGet("membres")]
        public async Task<IActionResult> GetAllCredits()
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
            var echeances = await uow.EcheanceCreditRepository.GetAllAsync();
            if(echeances is null) {
                return NotFound();
            }
            var echeancesDto = mapper.Map<IEnumerable<EcheanceCreditDto>>(echeances);
            return Ok(echeancesDto);
        }

        [HttpGet("echeances/{creditId}")]
        public async Task<IActionResult> GetAllEcheancesCredit(int creditId)
        {
            var echeances = await uow.EcheanceCreditRepository.GetAllByCreditAsync(creditId);
            if(echeances is null) {
                return NotFound();
            }
            var echeancesDto = mapper.Map<IEnumerable<EcheanceCreditDto>>(echeances);
            return Ok(echeancesDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CreditDto creditDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var credit = mapper.Map<Credit>(creditDto);
            uow.CreditRepository.Add(credit);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPost("addecheances")]
        public async Task<IActionResult> AddEcheances(EcheanceCreditDto[] echeanceCreditsDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            foreach(var echeanceDto in echeanceCreditsDto) {
                var echeance = mapper.Map<EcheanceCredit>(echeanceDto);
                if(echeanceDto.Id == 0) {
                    uow.EcheanceCreditRepository.Add(echeance);
                }else{
                    if(echeanceDto.Id != 0) {
                        var echeanceFromDb = await uow.EcheanceCreditRepository.FindByIdAsync(echeanceDto.Id);
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
        public async Task<IActionResult> Update(int id,CreditDto creditDto)
        {
            if(id != creditDto.Id) 
                return BadRequest("Update not allowed");

            var creditFromDb = await uow.CreditRepository.FindByIdAsync(id);
            
            if(creditFromDb == null) 
                return BadRequest("Update not allowed");

            mapper.Map(creditDto, creditFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }
    }
}