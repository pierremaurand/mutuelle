using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace mefApi.Controllers
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
            if(agences is null) {
                return NotFound();
            }
            var agencesDto = mapper.Map<IEnumerable<AgenceDto>>(agences);
            return Ok(agencesDto);
        }

        [HttpGet("agences/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var agence = await uow.AgenceRepository.FindByIdAsync(id);
            if(agence is null) {
                return NotFound();
            }
            var agenceDto = mapper.Map<AgenceDto>(agence);
            return Ok(agenceDto);
        }

        [HttpPost("agences")]
        public async Task<IActionResult> Add(AgenceDto agenceDto)
        {
            var agence = mapper.Map<Agence>(agenceDto);
            if(agenceDto.Nom is not null && await uow.AgenceRepository.AgenceExists(agenceDto.Nom)) {
                return BadRequest("Cet agence existe déjà dans la base de données");
            } else {
                agence.ModifiePar = GetUserId();
                agence.ModifieLe = DateTime.Now;
                await uow.SaveAsync();
            }
            
            return Ok(agence.Id);
        }

        [HttpPut("agences/{id}")]
        public async Task<IActionResult> Update(int id,AgenceDto agenceDto)
        {
            if(id != agenceDto.Id) 
                return BadRequest("Cette mise à jour n'est pas authorisée");

            var agenceFromDb = await uow.AgenceRepository.FindByIdAsync(id);
            
            if(agenceFromDb == null) 
                return BadRequest("Cette mise à jour n'est pas authorisée");

            agenceFromDb.ModifiePar = GetUserId();
            agenceFromDb.ModifieLe = DateTime.Now;
            mapper.Map(agenceDto, agenceFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("agences/{id}")]
        public async Task<IActionResult> DeleteAgence(int id)
        {
            uow.AgenceRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}