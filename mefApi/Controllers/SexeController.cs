using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;

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
        public async Task<IActionResult> GetAll()
        {
            var sexes = await uow.SexeRepository.GetAllAsync();
            if(sexes is null) {
                return NotFound();
            }
            var sexesDto = mapper.Map<IEnumerable<SexeListDto>>(sexes);
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
        public async Task<IActionResult> Add(NewSexeDto sexeDto)
        {
            var sexe = mapper.Map<Sexe>(sexeDto);
            sexe.CreePar = 1;
            sexe.ModifiePar = 1;
            sexe.ModifieLe = DateTime.Now;
            uow.SexeRepository.Add(sexe);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,SexeDto sexeDto)
        {
            if(id != sexeDto.Id) 
                return BadRequest("Update not allowed");

            var sexeFromDb = await uow.SexeRepository.FindByIdAsync(id);
            
            if(sexeFromDb == null) 
                return BadRequest("Update not allowed");

            sexeFromDb.ModifiePar = 1;
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