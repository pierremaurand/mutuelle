using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace mefApi.Controllers
{
    public class SexeController : BaseController
    {
        
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public SexeController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("sexes")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var sexes = await uow.SexeRepository.GetAllAsync();
            if(sexes is null) {
                return NotFound();
            }
            var sexesDto = mapper.Map<IEnumerable<SexeDto>>(sexes);
            return Ok(sexesDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sexe = await uow.SexeRepository.FindByIdAsync(id);
            if(sexe is null) {
                return NotFound();
            }
            var sexeDto = mapper.Map<SexeDto>(sexe);
            return Ok(sexeDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(SexeDto sexeDto)
        {
            var sexe = mapper.Map<Sexe>(sexeDto);

            if(await uow.SexeRepository.SexeExists(sexeDto)) {
                sexe = await uow.SexeRepository.FindByNomAsync(sexeDto.Symbole);
                if(sexe is null) {
                    return NotFound("Ce sexe n'existe pas dans la base de donnée");
                }
            } else {
                sexe.ModifiePar = GetUserId();
                sexe.ModifieLe = DateTime.Now;
                uow.SexeRepository.Add(sexe);
                await uow.SaveAsync();
            }
            
            
            return Ok(sexe.Id);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,SexeDto sexeDto)
        {
            if(id != sexeDto.Id) 
                return BadRequest("Update not allowed");

            var sexeFromDb = await uow.SexeRepository.FindByIdAsync(id);
            
            if(sexeFromDb == null) 
                return BadRequest("Update not allowed");

            sexeFromDb.ModifiePar = GetUserId();
            sexeFromDb.ModifieLe = DateTime.Now;
            mapper.Map(sexeDto, sexeFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSexe(int id)
        {
            uow.SexeRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}