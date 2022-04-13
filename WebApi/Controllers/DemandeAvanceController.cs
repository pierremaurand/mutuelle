using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class DemandeAvanceController : BaseController
    {
         private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public DemandeAvanceController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("demandeavances")]
        public async Task<IActionResult> GetAll()
        {
            var demandeavances = await uow.DemandeAvanceRepository.GetAllAsync();
            var demandeavancesDto = mapper.Map<IEnumerable<DemandeAvanceDto>>(demandeavances);
            if(demandeavancesDto is null) {
                return NotFound();
            }
            return Ok(demandeavancesDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var demandeavance = await uow.DemandeAvanceRepository.FindByIdAsync(id);
            var demandeavanceDto = mapper.Map<DemandeAvanceDto>(demandeavance);
            if(demandeavanceDto is null) {
                return NotFound();
            }
            return Ok(demandeavanceDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(DemandeAvanceDto demandeavanceDto)
        {
            var demandeavance = mapper.Map<DemandeAvance>(demandeavanceDto);
            demandeavance.CreatedBy = 1;
            demandeavance.LastUpdatedBy = 1;
            demandeavance.LastUpdatedOn = DateTime.Now;
            uow.DemandeAvanceRepository.Add(demandeavance);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,DemandeAvanceDto demandeavanceDto)
        {
            if(id != demandeavanceDto.Id) 
                return BadRequest("Update not allowed");

            var demandeavanceFromDb = await uow.DemandeAvanceRepository.FindByIdAsync(id);
            
            if(demandeavanceFromDb == null) 
                return BadRequest("Update not allowed");

            demandeavanceFromDb.LastUpdatedBy = 1;
            demandeavanceFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(demandeavanceDto, demandeavanceFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.DemandeAvanceRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}