using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace mefApi.Controllers
{
    public class CompteComptableController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CompteComptableController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("comptes")]
        public async Task<IActionResult> GetAll()
        {
            var comptes = await uow.CompteComptableRepository.GetAllAsync();
            if(comptes is null) {
                return NotFound();
            }
            var comptesDto = mapper.Map<IEnumerable<CompteComptableDto>>(comptes);
            return Ok(comptesDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var compte = await uow.CompteComptableRepository.FindByIdAsync(id);
            if(compte is null) {
                return NotFound();
            }
            var compteDto = mapper.Map<CompteComptableDto>(compte);
            return Ok(compteDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(NewCompteComptableDto compteDto)
        {
            var compte = mapper.Map<CompteComptable>(compteDto);
            compte.CreePar = 1;
            compte.ModifiePar = 1;
            compte.ModifieLe = DateTime.Now;
            uow.CompteComptableRepository.Add(compte);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,CompteComptableDto compteDto)
        {
            if(id != compteDto.Id) 
                return BadRequest("Update not allowed");

            var compteFromDb = await uow.CompteComptableRepository.FindByIdAsync(id);
            
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
            uow.CompteComptableRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}