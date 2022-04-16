using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CotisationController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CotisationController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("cotisations")]
        public async Task<IActionResult> GetAll()
        {
            var cotisations = await uow.CotisationRepository.GetAllAsync();
            var cotisationsDto = mapper.Map<IEnumerable<CotisationListDto>>(cotisations);
            if (cotisationsDto is null)
            {
                return NotFound();
            }
            return Ok(cotisationsDto);
        }

        [HttpGet("cotisations/membre/{id}")]
        public async Task<IActionResult> GetAllCotisationMembre(int id)
        {
            var cotisations = await uow.CotisationRepository.GetAllByMembreAsync(id);
            var cotisationsDto = mapper.Map<IEnumerable<CotisationListDto>>(cotisations);
            if (cotisationsDto is null)
            {
                return NotFound();
            }
            return Ok(cotisationsDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cotisation = await uow.CotisationRepository.FindByIdAsync(id);
            var cotisationDto = mapper.Map<CotisationDto>(cotisation);
            if (cotisationDto is null)
            {
                return NotFound();
            }
            return Ok(cotisationDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CotisationDto cotisationDto)
        {
            var cotisation = mapper.Map<Cotisation>(cotisationDto);
            cotisation.CreatedBy = 1;
            cotisation.LastUpdatedBy = 1;
            cotisation.LastUpdatedOn = DateTime.Now;
            uow.CotisationRepository.Add(cotisation);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, CotisationDto cotisationDto)
        {
            if (id != cotisationDto.Id)
                return BadRequest("Update not allowed");

            var cotisationFromDb = await uow.CotisationRepository.FindByIdAsync(id);

            if (cotisationFromDb == null)
                return BadRequest("Update not allowed");

            cotisationFromDb.LastUpdatedBy = 1;
            cotisationFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(cotisationDto, cotisationFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.CotisationRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}