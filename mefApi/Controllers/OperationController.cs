using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace mefApi.Controllers
{
    public class OperationController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public OperationController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("operations")]
        public async Task<IActionResult> GetAll()
        {
            var operations = await uow.OperationRepository.GetAllAsync();
            if(operations is null) {
                return NotFound();
            }
            var operationsDto = mapper.Map<IEnumerable<OperationDto>>(operations);
            return Ok(operationsDto);
        }

        [HttpGet("operations/{gabaritId}")]
        public async Task<IActionResult> GetByGabarit(int gabaritId)
        {
            var operations = await uow.OperationRepository.GetByGabaritAsync(gabaritId);
            if(operations is null) {
                return NotFound();
            }
            var operationsDto = mapper.Map<IEnumerable<OperationDto>>(operations);
            return Ok(operationsDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var operation = await uow.OperationRepository.FindByIdAsync(id);
            if(operation is null) {
                return NotFound();
            }
            var operationDto = mapper.Map<OperationDto>(operation);
            return Ok(operationDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(OperationDto operationDto)
        {
            var operation = mapper.Map<Operation>(operationDto);
            operation.CreePar = 1;
            operation.ModifiePar = 1;
            operation.ModifieLe = DateTime.Now;

            uow.OperationRepository.Add(operation);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPost("addoperations/{gabaritId}")]
        public async Task<IActionResult> AddOperations(int gabaritId,OperationDto[] operationsDto)
        {
            var operations = mapper.Map<Operation[]>(operationsDto);
            var gabaritFromDb = await uow.GabaritRepository.FindByIdAsync(gabaritId);
            if(gabaritFromDb is not null){
                 foreach(Operation operation in operations){
                    operation.Gabarit = gabaritFromDb;
                    operation.CreePar = 1;
                    operation.ModifiePar = 1;
                    operation.ModifieLe = DateTime.Now;
                    uow.OperationRepository.Add(operation);
                }
            }
           
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id,OperationDto operationDto)
        {
            if(id != operationDto.Id) 
                return BadRequest("Update not allowed");

            var operationFromDb = await uow.OperationRepository.FindByIdAsync(id);
            
            if(operationFromDb == null) 
                return BadRequest("Update not allowed");

            operationFromDb.ModifiePar = 1;
            operationFromDb.ModifieLe = DateTime.Now;
            mapper.Map(operationDto, operationFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            uow.OperationRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}