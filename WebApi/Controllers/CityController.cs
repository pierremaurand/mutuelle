using AutoMapper;
using hspaApi2.Dtos;
using hspaApi2.Interfaces;
using hspaApi2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace hspaApi2.Controllers
{
    public class CityController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public CityController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet("cities")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCities()
        {
            //throw new UnauthorizedAccessException();
            var cities = await uow.CityRepository.GetAllAsync();
            var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);
            if(citiesDto is null) {
                return NotFound();
            }
            return Ok(citiesDto);
        }

        [HttpPost("post")]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            var city = mapper.Map<City>(cityDto);
            city.LastUpdatedBy = 1;
            city.LastUpdatedOn = DateTime.Now;
            uow.CityRepository.Add(city);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id,CityDto cityDto)
        {
            if(id != cityDto.Id) 
                return BadRequest("Update not allowed");

            var cityFromDb = await uow.CityRepository.FindByIdAsync(id);
            
            if(cityFromDb == null) 
                return BadRequest("Update not allowed");

            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityDto, cityFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
        {
            var cityFromDb = await uow.CityRepository.FindByIdAsync(id);
            if(cityFromDb!=null) {
                cityFromDb.LastUpdatedBy = 1;
                cityFromDb.LastUpdatedOn = DateTime.Now;
                cityToPatch.ApplyTo(cityFromDb, ModelState);
                await uow.SaveAsync();
                return StatusCode(200);
            }
            return NotFound();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.CityRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }

    }
}