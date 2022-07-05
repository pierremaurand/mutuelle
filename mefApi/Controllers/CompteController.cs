using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompteController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CompteController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("comptes")]
        public async Task<IActionResult> GetAll()
        {
            var comptes = await uow.CompteRepository.GetAllAsync();
            var comptesDto = mapper.Map<IEnumerable<CompteDto>>(comptes);
            if (comptesDto is null)
            {
                return NotFound();
            }
            return Ok(comptesDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var compte = await uow.CompteRepository.FindByIdAsync(id);
            var compteDto = mapper.Map<CompteDto>(compte);
            if (compteDto is null)
            {
                return NotFound();
            }
            return Ok(compteDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CompteDto compteDto)
        {
            var compte = mapper.Map<Compte>(compteDto);
            compte.CreatedBy = 1;
            compte.LastUpdatedBy = 1;
            compte.LastUpdatedOn = DateTime.Now;
            uow.CompteRepository.Add(compte);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, CompteDto compteDto)
        {
            if (id != compteDto.Id)
                return BadRequest("Update not allowed");

            var compteFromDb = await uow.CompteRepository.FindByIdAsync(id);

            if (compteFromDb == null)
                return BadRequest("Update not allowed");

            compteFromDb.LastUpdatedBy = 1;
            compteFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(compteDto, compteFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.CompteRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}