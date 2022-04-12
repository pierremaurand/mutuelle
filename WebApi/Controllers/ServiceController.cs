using AutoMapper;
using hspaApi2.Controllers;
using hspaApi2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ServiceController : BaseController
    {
        
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ServiceController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("services")]
        public async Task<IActionResult> GetAll()
        {
            var services = await uow.ServiceRepository.GetAllAsync();
            var servicesDto = mapper.Map<IEnumerable<ServiceDto>>(services);
            if(servicesDto is null) {
                return NotFound();
            }
            return Ok(servicesDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var service = await uow.ServiceRepository.FindByIdAsync(id);
            var serviceDto = mapper.Map<ServiceDto>(service);
            if(serviceDto is null) {
                return NotFound();
            }
            return Ok(serviceDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ServiceDto serviceDto)
        {
            var service = mapper.Map<Service>(serviceDto);
            service.CreatedBy = 1;
            service.LastUpdatedBy = 1;
            service.LastUpdatedOn = DateTime.Now;
            uow.ServiceRepository.Add(service);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,ServiceDto serviceDto)
        {
            if(id != serviceDto.Id) 
                return BadRequest("Update not allowed");

            var serviceFromDb = await uow.ServiceRepository.FindByIdAsync(id);
            
            if(serviceFromDb == null) 
                return BadRequest("Update not allowed");

            serviceFromDb.LastUpdatedBy = 1;
            serviceFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(serviceDto, serviceFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.ServiceRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}