using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class GabarieController : BaseController
    {
         private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GabarieController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("gabaries")]
        public async Task<IActionResult> GetAll()
        {
            var gabaries = await uow.GabarieRepository.GetAllAsync();
            var gabariesDto = mapper.Map<IEnumerable<GabarieDto>>(gabaries);
            if(gabariesDto is null) {
                return NotFound();
            }
            return Ok(gabariesDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var gabarie = await uow.GabarieRepository.FindByIdAsync(id);
            var gabarieDto = mapper.Map<GabarieDto>(gabarie);
            if(gabarieDto is null) {
                return NotFound();
            }
            return Ok(gabarieDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(GabarieDto gabarieDto)
        {
            var gabarie = mapper.Map<Gabarie>(gabarieDto);
            gabarie.CreatedBy = 1;
            gabarie.LastUpdatedBy = 1;
            gabarie.LastUpdatedOn = DateTime.Now;
            uow.GabarieRepository.Add(gabarie);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,GabarieDto gabarieDto)
        {
            if(id != gabarieDto.Id) 
                return BadRequest("Update not allowed");

            var gabarieFromDb = await uow.GabarieRepository.FindByIdAsync(id);
            
            if(gabarieFromDb == null) 
                return BadRequest("Update not allowed");

            gabarieFromDb.LastUpdatedBy = 1;
            gabarieFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(gabarieDto, gabarieFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.GabarieRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}