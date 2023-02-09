using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace mefApi.Controllers
{
    public class PosteController: BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public PosteController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("postes")]
        public async Task<IActionResult> GetAll()
        {
            var postes = await uow.PosteRepository.GetAllAsync();
            if(postes is null) {
                return NotFound();
            }
            var postesDto = mapper.Map<IEnumerable<PosteListDto>>(postes);
            return Ok(postesDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var poste = await uow.PosteRepository.FindByIdAsync(id);
            if(poste is null) {
                return NotFound();
            }
            var posteDto = mapper.Map<PosteDto>(poste);
            return Ok(posteDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(NewPosteDto posteDto)
        {
            var poste = mapper.Map<Poste>(posteDto);
            poste.CreePar = 1;
            poste.ModifiePar = 1;
            poste.ModifieLe = DateTime.Now;
            uow.PosteRepository.Add(poste);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,PosteDto posteDto)
        {
            if(id != posteDto.Id) 
                return BadRequest("Update not allowed");

            var posteFromDb = await uow.PosteRepository.FindByIdAsync(id);
            
            if(posteFromDb == null) 
                return BadRequest("Update not allowed");

            posteFromDb.ModifiePar = 1;
            posteFromDb.ModifieLe = DateTime.Now;
            mapper.Map(posteDto, posteFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePoste(int id)
        {
            uow.PosteRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }

    }
}