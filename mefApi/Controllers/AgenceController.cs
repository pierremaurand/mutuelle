using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AgenceController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AgenceController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("agences")]
        public async Task<IActionResult> GetAll()
        {
            var agences = await uow.AgenceRepository.GetAllAsync();
            var agencesDto = mapper.Map<IEnumerable<AgenceDto>>(agences);
            if(agencesDto is null) {
                return NotFound();
            }
            return Ok(agencesDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var agence = await uow.AgenceRepository.FindByIdAsync(id);
            var agenceDto = mapper.Map<AgenceDto>(agence);
            if(agenceDto is null) {
                return NotFound();
            }
            return Ok(agenceDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AgenceDto agenceDto)
        {
            var agence = mapper.Map<Agence>(agenceDto);
            agence.CreatedBy = 1;
            agence.LastUpdatedBy = 1;
            agence.LastUpdatedOn = DateTime.Now;
            uow.AgenceRepository.Add(agence);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,AgenceDto agenceDto)
        {
            if(id != agenceDto.Id) 
                return BadRequest("Update not allowed");

            var agenceFromDb = await uow.AgenceRepository.FindByIdAsync(id);
            
            if(agenceFromDb == null) 
                return BadRequest("Update not allowed");

            agenceFromDb.LastUpdatedBy = 1;
            agenceFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(agenceDto, agenceFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.AgenceRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}