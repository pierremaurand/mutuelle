using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CreditController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CreditController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("credits")]
        public async Task<IActionResult> GetAll()
        {
            var credits = await uow.CreditRepository.GetAllAsync();
            var creditsDto = mapper.Map<IEnumerable<CreditDto>>(credits);
            if (creditsDto is null)
            {
                return NotFound();
            }
            return Ok(creditsDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var credit = await uow.CreditRepository.FindByIdAsync(id);
            var creditDto = mapper.Map<CreditDto>(credit);
            if (creditDto is null)
            {
                return NotFound();
            }
            return Ok(creditDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CreditDto creditDto)
        {
            var credit = mapper.Map<Credit>(creditDto);
            credit.CreatedBy = 1;
            credit.LastUpdatedBy = 1;
            credit.LastUpdatedOn = DateTime.Now;
            uow.CreditRepository.Add(credit);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, CreditDto creditDto)
        {
            if (id != creditDto.Id)
                return BadRequest("Update not allowed");

            var creditFromDb = await uow.CreditRepository.FindByIdAsync(id);

            if (creditFromDb == null)
                return BadRequest("Update not allowed");

            creditFromDb.LastUpdatedBy = 1;
            creditFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(creditDto, creditFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.CreditRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}