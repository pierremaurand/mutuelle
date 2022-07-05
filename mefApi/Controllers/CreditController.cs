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
        public async Task<IActionResult> GetAllCredits()
        {
            var credits = await uow.CreditRepository.GetAllAsync();
            var creditsDto = mapper.Map<IEnumerable<CreditDto>>(credits);
            if (creditsDto is null)
            {
                return NotFound();
            }
            return Ok(creditsDto);
        }

        [HttpGet("credits/membre/{id}")]
        public async Task<IActionResult> GetAllCreditsMembre(int id)
        {
            var credits = await uow.CreditRepository.GetAllByMembreAsync(id);
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

        [HttpPost("add/{id}")]
        public async Task<IActionResult> Add(int id, CreditDto creditDto)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(id);
            if (membre is not null)
            {
                var credit = mapper.Map<Credit>(creditDto);
                credit.Membre = membre;
                credit.CreatedBy = 1;
                credit.LastUpdatedBy = 1;
                credit.LastUpdatedOn = DateTime.Now;
                uow.CreditRepository.Add(credit);
                await uow.SaveAsync();
                return StatusCode(201);
            }
            return BadRequest("Ce membre n'existe pas dans la bdd");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, CreditDto creditDto)
        {
            if (id != creditDto.Id)
                return BadRequest("Update not allowed");

            var creditFromDb = await uow.CreditRepository.FindByIdAsync(id);

            if (creditFromDb == null)
                return BadRequest("Update not allowed");

            mapper.Map(creditDto, creditFromDb);
            if (creditFromDb.EstValide)
            {
                for (var i = 0; i < creditDto.EcheanceCredits.Count(); i++)
                {
                    if (creditDto.EcheanceCredits.ElementAt(i).EstNouveau == true)
                    {
                        creditFromDb.EcheanceCredits.ElementAt(i).EstPaye = true;
                        creditFromDb.EcheanceCredits.ElementAt(i).LastUpdatedBy = 1;
                        creditFromDb.EcheanceCredits.ElementAt(i).LastUpdatedOn = DateTime.Now;
                    }
                }
            }

            creditFromDb.LastUpdatedBy = 1;
            creditFromDb.LastUpdatedOn = DateTime.Now;

            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCredit(int id)
        {
            var creditFromDb = await uow.CreditRepository.FindByIdAsync(id);
            if (creditFromDb == null)
                return BadRequest("Update not allowed");
            creditFromDb.EstValide = false;
            creditFromDb.LastUpdatedBy = 1;
            creditFromDb.LastUpdatedOn = DateTime.Now;
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}