using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ParametreController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ParametreController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("parametres")]
        public async Task<IActionResult> GetAll()
        {
            var parametres = await uow.ParametreRepository.GetAllAsync();
            var parametresDto = mapper.Map<IEnumerable<ParametreDto>>(parametres);
            if(parametresDto is null) {
                return NotFound();
            }
            return Ok(parametresDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var parametre = await uow.ParametreRepository.FindByIdAsync(id);
            var parametreDto = mapper.Map<ParametreDto>(parametre);
            if(parametreDto is null) {
                return NotFound();
            }
            return Ok(parametreDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ParametreDto parametreDto)
        {
            var parametre = mapper.Map<Parametre>(parametreDto);
            parametre.CreatedBy = 1;
            parametre.LastUpdatedBy = 1;
            parametre.LastUpdatedOn = DateTime.Now;
            uow.ParametreRepository.Add(parametre);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,ParametreDto parametreDto)
        {
            if(id != parametreDto.Id) 
                return BadRequest("Update not allowed");

            var parametreFromDb = await uow.ParametreRepository.FindByIdAsync(id);
            
            if(parametreFromDb == null) 
                return BadRequest("Update not allowed");

            parametreFromDb.LastUpdatedBy = 1;
            parametreFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(parametreDto, parametreFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.ParametreRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}