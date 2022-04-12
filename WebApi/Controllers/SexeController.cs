using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
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
            var sexesDto = mapper.Map<IEnumerable<SexeDto>>(sexes);
            if(sexesDto is null) {
                return NotFound();
            }
            return Ok(sexesDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sexe = await uow.SexeRepository.FindByIdAsync(id);
            var sexeDto = mapper.Map<SexeDto>(sexe);
            if(sexeDto is null) {
                return NotFound();
            }
            return Ok(sexeDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(SexeDto sexeDto)
        {
            var sexe = mapper.Map<Sexe>(sexeDto);
            sexe.CreatedBy = 1;
            sexe.LastUpdatedBy = 1;
            sexe.LastUpdatedOn = DateTime.Now;
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

            sexeFromDb.LastUpdatedBy = 1;
            sexeFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(sexeDto, sexeFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.SexeRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}