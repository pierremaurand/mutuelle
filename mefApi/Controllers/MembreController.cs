using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class MembreController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly ILocalPhotoService localPhotoService;

        public MembreController(IMapper mapper, IUnitOfWork uow, ILocalPhotoService localPhotoService)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.localPhotoService = localPhotoService;
        }

        [HttpGet("membres")]
        public async Task<IActionResult> GetAll()
        {
            var membres = await uow.MembreRepository.GetAllAsync();
            var membresListDto = mapper.Map<IEnumerable<MembreDto>>(membres);
            if (membresListDto is null)
            {
                return NotFound();
            }
            return Ok(membresListDto);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(id);
            var membreDto = mapper.Map<MembreDto>(membre);
            if (membreDto is null)
            {
                return NotFound();
            }
            return Ok(membreDto);
        }
        
        [HttpPost("add")]
        public async Task<IActionResult> Add(MembreDto membreDto)
        {
            var membre = mapper.Map<Membre>(membreDto);
            membre.CreatedBy = 1;
            membre.LastUpdatedBy = 1;
            membre.LastUpdatedOn = DateTime.Now;
            uow.MembreRepository.Add(membre);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, MembreDto membreDto)
        {
            if (id != membreDto.Id)
                return BadRequest("Update not allowed");

            var membreFromDb = await uow.MembreRepository.FindByIdAsync(id);

            if (membreFromDb is null)
                return BadRequest("Update not allowed");

            membreFromDb.LastUpdatedBy = 1;
            membreFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(membreDto, membreFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }


        [HttpPost("add/avance/{id}")]
        public async Task<IActionResult> AddAvance(int id, AvanceDto avanceDto)
        {

            var membreFromDb = await uow.MembreRepository.FindByIdAsync(id);
            if (membreFromDb != null && membreFromDb.Avances != null)
            {
                var avance = mapper.Map<Avance>(avanceDto);
                for(var i = 0; i < avance.EcheanceAvances.Count(); i++) {
                    avance.EcheanceAvances.ElementAt(i).CreatedBy = 1;
                    avance.EcheanceAvances.ElementAt(i).LastUpdatedBy = 1;
                    avance.EcheanceAvances.ElementAt(i).LastUpdatedOn = DateTime.Now;
                }
                avance.CreatedBy = 1;
                avance.LastUpdatedBy = 1;
                avance.LastUpdatedOn = DateTime.Now;
                membreFromDb.Avances.Add(avance);
                await uow.SaveAsync();
                return StatusCode(201);
            }
            return BadRequest("Les informations sur l'avance ou le membre sont incorrectes");
        }

        [HttpPost("add/credit/{id}")]
        public async Task<IActionResult> AddCredit(int id, CreditDto creditDto)
        {

            var membreFromDb = await uow.MembreRepository.FindByIdAsync(id);
            if (membreFromDb != null && membreFromDb.Credits != null)
            {
                var credit = mapper.Map<Credit>(creditDto);
                for(var i = 0; i < credit.EcheanceCredits.Count(); i++) {
                    credit.EcheanceCredits.ElementAt(i).CreatedBy = 1;
                    credit.EcheanceCredits.ElementAt(i).LastUpdatedBy = 1;
                    credit.EcheanceCredits.ElementAt(i).LastUpdatedOn = DateTime.Now;
                }
                credit.CreatedBy = 1;
                credit.LastUpdatedBy = 1;
                credit.LastUpdatedOn = DateTime.Now;
                membreFromDb.Credits.Add(credit);
                await uow.SaveAsync();
                return StatusCode(201);
            }
            return BadRequest("Les informations sur l'avance ou le membre sont incorrectes");
        }

        [HttpPut("update/avance/{id}")]
        public async Task<IActionResult> UpdateAvance(int id, AvanceDto avanceDto)
        {

            var membreFromDb = await uow.MembreRepository.FindByIdAsync(id);
            if (membreFromDb != null && membreFromDb.Avances != null)
            {
                var avance = membreFromDb.Avances.FirstOrDefault(c => c.Id == avanceDto.Id);
                if (avance is not null)
                {
                    mapper.Map(avanceDto, avance);
                    avance.Montant = avance.Montant;
                    avance.CreatedBy = 1;
                    avance.LastUpdatedBy = 1;
                    avance.LastUpdatedOn = DateTime.Now;
                    if (await uow.SaveAsync())
                        return StatusCode(200);
                }
                return BadRequest("Aucune avance n'a été trouvée");
            }
            return BadRequest("Les informations sur l'avance ou le membre sont incorrectes");
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.MembreRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }

        [HttpPost("add/cotisation/{id}")]
        public async Task<IActionResult> AddCotisation(int id, CotisationDto cotisationDto)
        {

            var membreFromDb = await uow.MembreRepository.FindByIdAsync(id);
            if (membreFromDb != null && membreFromDb.Cotisations != null)
            {
                var cotisation = mapper.Map<Cotisation>(cotisationDto);
                cotisation.CreatedBy = 1;
                cotisation.LastUpdatedBy = 1;
                cotisation.LastUpdatedOn = DateTime.Now;

                membreFromDb.Cotisations.Add(cotisation);
                await uow.SaveAsync();
                return StatusCode(201);
            }
            return BadRequest("Les informations sur la cotisation ou le membre sont incorrectes");
        }

        [HttpPost("add/photo")]
        public async Task<IActionResult> addPhoto(IFormFile file)
        {
            var result = await localPhotoService.UploadPhotoAsync(file);
            if (result != null && result.Error != null)
                return BadRequest(result.Error.Message);

            return Ok(result);
        }

    }
}