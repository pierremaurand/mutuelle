using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class DemandeCreditController : BaseController
    {
         private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public DemandeCreditController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("demandecredits")]
        public async Task<IActionResult> GetAll()
        {
            var demandecredits = await uow.DemandeCreditRepository.GetAllAsync();
            var demandecreditsDto = mapper.Map<IEnumerable<DemandeCreditDto>>(demandecredits);
            if(demandecreditsDto is null) {
                return NotFound();
            }
            return Ok(demandecreditsDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var demandecredit = await uow.DemandeCreditRepository.FindByIdAsync(id);
            var demandecreditDto = mapper.Map<DemandeCreditDto>(demandecredit);
            if(demandecreditDto is null) {
                return NotFound();
            }
            return Ok(demandecreditDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(DemandeCreditDto demandecreditDto)
        {
            var demandecredit = mapper.Map<DemandeCredit>(demandecreditDto);
            demandecredit.CreatedBy = 1;
            demandecredit.LastUpdatedBy = 1;
            demandecredit.LastUpdatedOn = DateTime.Now;
            uow.DemandeCreditRepository.Add(demandecredit);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,DemandeCreditDto demandecreditDto)
        {
            if(id != demandecreditDto.Id) 
                return BadRequest("Update not allowed");

            var demandecreditFromDb = await uow.DemandeCreditRepository.FindByIdAsync(id);
            
            if(demandecreditFromDb == null) 
                return BadRequest("Update not allowed");

            demandecreditFromDb.LastUpdatedBy = 1;
            demandecreditFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(demandecreditDto, demandecreditFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.DemandeCreditRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}