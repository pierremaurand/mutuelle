using AutoMapper;
using hspaApi2.Controllers;
using hspaApi2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class MembreController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public MembreController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("membres")]
        public async Task<IActionResult> GetAll()
        {
            var membres = await uow.MembreRepository.GetAllAsync();
            var membresDto = mapper.Map<IEnumerable<MembreListDto>>(membres);
            if (membresDto is null)
            {
                return NotFound();
            }
            return Ok(membresDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(id);
            var membreDto = mapper.Map<MembreDetailDto>(membre);
            if (membreDto is null)
            {
                return NotFound();
            }
            return Ok(membreDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(MembreDetailDto membreDto)
        {
            var membre = mapper.Map<Membre>(membreDto);
            membre.LastUpdatedBy = 1;
            membre.LastUpdatedOn = DateTime.Now;
            uow.MembreRepository.Add(membre);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, MembreDetailDto membreDto)
        {
            if (id != membreDto.Id)
                return BadRequest("Update not allowed");

            var membreFromDb = await uow.MembreRepository.FindByIdAsync(id);

            if (membreFromDb == null)
                return BadRequest("Update not allowed");

            membreFromDb.LastUpdatedBy = 1;
            membreFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(membreDto, membreFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.MembreRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}