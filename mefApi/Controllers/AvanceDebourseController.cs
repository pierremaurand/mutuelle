using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mefApi.Controllers
{
    public class AvanceDebourseController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AvanceDebourseController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var avance = await uow.AvanceDebourseRepository.FindByIdAsync(id);
            if(avance is null) {
                return NotFound();
            }
            return Ok(mapper.Map<AvanceDebourseDto>(avance));
        }

    }
}