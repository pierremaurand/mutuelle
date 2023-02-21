using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace mefApi.Controllers
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
            if(comptes is null) {
                return NotFound();
            }
            var comptesDto = mapper.Map<IEnumerable<CompteDto>>(comptes);
            return Ok(comptesDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var compte = await uow.CompteRepository.FindByIdAsync(id);
            if(compte is null) {
                return NotFound();
            }
            var compteDto = mapper.Map<CompteDto>(compte);
            return Ok(compteDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CompteDto compteDto)
        {
            var compte = mapper.Map<Compte>(compteDto);
            compte.CreePar = 1;
            compte.ModifiePar = 1;
            compte.ModifieLe = DateTime.Now;

            uow.CompteRepository.Add(compte);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,CompteDto compteDto)
        {
            if(id != compteDto.Id) 
                return BadRequest("Update not allowed");

            var compteFromDb = await uow.CompteRepository.FindByIdAsync(id);
            
            if(compteFromDb == null) 
                return BadRequest("Update not allowed");

            compteFromDb.ModifiePar = 1;
            compteFromDb.ModifieLe = DateTime.Now;
            mapper.Map(compteDto, compteFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCompte(int id)
        {
            uow.CompteRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}