using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
     public class PeriodeController : BaseController
    {
          private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public PeriodeController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("periodes")]
        public async Task<IActionResult> GetAll()
        {
            var periodes = await uow.PeriodeRepository.GetAllAsync();
            var periodesDto = mapper.Map<IEnumerable<PeriodeDto>>(periodes);
            if (periodesDto is null)
            {
                return NotFound();
            }
            return Ok(periodesDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var periode = await uow.PeriodeRepository.FindByIdAsync(id);
            var periodeDto = mapper.Map<PeriodeDto>(periode);
            if (periodeDto is null)
            {
                return NotFound();
            }
            return Ok(periodeDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(PeriodeDto periodeDto)
        {
            var periode = mapper.Map<Periode>(periodeDto);
            periode.CreatedBy = 1;
            periode.LastUpdatedBy = 1;
            periode.LastUpdatedOn = DateTime.Now;
            uow.PeriodeRepository.Add(periode);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, PeriodeDto periodeDto)
        {
            if (id != periodeDto.Id)
                return BadRequest("Update not allowed");

            var periodeFromDb = await uow.PeriodeRepository.FindByIdAsync(id);

            if (periodeFromDb == null)
                return BadRequest("Update not allowed");

            periodeFromDb.LastUpdatedBy = 1;
            periodeFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(periodeDto, periodeFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.PeriodeRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}