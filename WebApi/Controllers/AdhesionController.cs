using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AdhesionController : BaseController
    {
         private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AdhesionController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("adhesions")]
        public async Task<IActionResult> GetAll()
        {
            var adhesions = await uow.AdhesionRepository.GetAllAsync();
            var adhesionsDto = mapper.Map<IEnumerable<AdhesionDto>>(adhesions);
            if(adhesionsDto is null) {
                return NotFound();
            }
            return Ok(adhesionsDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var adhesion = await uow.AdhesionRepository.FindByIdAsync(id);
            var adhesionDto = mapper.Map<AdhesionDto>(adhesion);
            if(adhesionDto is null) {
                return NotFound();
            }
            return Ok(adhesionDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AdhesionDto adhesionDto)
        {
            var adhesion = mapper.Map<Adhesion>(adhesionDto);
            adhesion.CreatedBy = 1;
            adhesion.LastUpdatedBy = 1;
            adhesion.LastUpdatedOn = DateTime.Now;
            uow.AdhesionRepository.Add(adhesion);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,AdhesionDto adhesionDto)
        {
            if(id != adhesionDto.Id) 
                return BadRequest("Update not allowed");

            var adhesionFromDb = await uow.AdhesionRepository.FindByIdAsync(id);
            
            if(adhesionFromDb == null) 
                return BadRequest("Update not allowed");

            adhesionFromDb.LastUpdatedBy = 1;
            adhesionFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(adhesionDto, adhesionFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.AdhesionRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}