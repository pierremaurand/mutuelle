using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace mefApi.Controllers
{
    public class CotisationController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CotisationController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpPost("addcotisations")]
        public async Task<IActionResult> AddCotisations(CotisationDto[] cotisationsDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            foreach(var cotisationDto in cotisationsDto) {
                if(cotisationDto.Id == 0) {
                    var cotisation = mapper.Map<Cotisation>(cotisationDto);
                    uow.CotisationRepository.Add(cotisation);
                }
            }
            
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpGet("membres")]
        public async Task<IActionResult> GetAllMembres()
        {
            var membres = await uow.MembreRepository.GetByEtatAsync(true);
            if(membres is null) {
                return NotFound();
            }
            var membresDto = mapper.Map<IEnumerable<MembreDto>>(membres);
            return Ok(membresDto);
        }

        [HttpGet("cotisations")]
        public async Task<IActionResult> GetAllCotisations()
        {
            var cotisations = await uow.CotisationRepository.GetAllAsync();
            if(cotisations is null) {
                return NotFound();
            }
            var cotisationsDto = mapper.Map<IEnumerable<CotisationDto>>(cotisations);
            return Ok(cotisationsDto);
        }

        [HttpGet("cotisations/{id}")]
        public async Task<IActionResult> GetAllCotisationsById(int id)
        {
            var cotisations = await uow.CotisationRepository.GetAllByMembreAsync(id);
            if(cotisations is null) {
                return NotFound();
            }
            var cotisationsDto = mapper.Map<IEnumerable<CotisationDto>>(cotisations);
            return Ok(cotisationsDto);
        }

        [HttpGet("mois")]
        public async Task<IActionResult> GetAllMois()
        {
            var mois = await uow.MoisRepository.GetAllAsync();
            if(mois is null) {
                return NotFound();
            }
            var moisDto = mapper.Map<IEnumerable<MoisDto>>(mois);
            return Ok(moisDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(id);
            if(membre is null) {
                return NotFound();
            }
            var membreDto = mapper.Map<MembreDto>(membre);
            return Ok(membreDto);
        }

    }
}