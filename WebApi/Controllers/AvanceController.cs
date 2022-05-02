using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
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

        [HttpGet("avances")]
        public async Task<IActionResult> GetAll()
        {
            var avances = await uow.AvanceRepository.GetAllAsync();
            var avancesDto = mapper.Map<IEnumerable<AvanceDto>>(avances);
            if (avancesDto is null)
            {
                return NotFound();
            }
            return Ok(avancesDto);
        }

        [HttpGet("avances/membre/{id}")]
        public async Task<IActionResult> GetAllAvanceMembre(int id)
        {
            var avances = await uow.AvanceRepository.GetAllByMembreAsync(id);
            var avancesDto = mapper.Map<IEnumerable<AvanceDto>>(avances);
            if (avancesDto is null)
            {
                return NotFound();
            }
            return Ok(avancesDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var avance = await uow.AvanceRepository.FindByIdAsync(id);
            var avanceDto = mapper.Map<AvanceDto>(avance);
            if (avanceDto is null)
            {
                return NotFound();
            }
            return Ok(avanceDto);
        }

        [HttpGet("get/echeances/{id}")]
        public async Task<IActionResult> GetEcheances(int id)
        {
            var avance = await uow.AvanceRepository.FindByIdAsync(id);
            if(avance is not null) {
                var echeancesAvanceDto = mapper.Map<IEnumerable<EcheanceAvanceDto>>(avance.EcheanceAvances);
                return Ok(echeancesAvanceDto);
            }
            return NotFound();
        }

        [HttpPost("add/{id}")]
        public async Task<IActionResult> Add(int id,AvanceDto avanceDto)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(id);
            if(membre is not null) {
                var avance = mapper.Map<Avance>(avanceDto);
                avance.Membre = membre;
                avance.CreatedBy = 1;
                avance.LastUpdatedBy = 1;
                avance.LastUpdatedOn = DateTime.Now;
                /*foreach (EcheanceAvance echeance in avance.EcheanceAvances)
                {
                    var echeance = mapper.Map<EcheanceAvance>(echeanceDto);
                    echeance.CreatedBy = 1;
                    echeance.LastUpdatedBy = 1;
                    echeance.LastUpdatedOn = DateTime.Now;
                    avance.EcheanceAvances.Add(echeance);
                }*/
                uow.AvanceRepository.Add(avance);
                await uow.SaveAsync();
                return StatusCode(201);
            }
            return BadRequest("Ce membre n'existe pas dans la bdd");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, AvanceDto avanceDto)
        {
            if (id != avanceDto.Id)
                return BadRequest("Update not allowed");

            var avanceFromDb = await uow.AvanceRepository.FindByIdAsync(id);

            if (avanceFromDb == null)
                return BadRequest("Update not allowed");

            avanceFromDb.LastUpdatedBy = 1;
            avanceFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(avanceDto, avanceFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.AvanceRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}