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
            var membresListDto = mapper.Map<IEnumerable<MembreListDto>>(membres);
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
            var membreDto = mapper.Map<MembreListDto>(membre);
            if (membreDto is null)
            {
                return NotFound();
            }
            return Ok(membreDto);
        }

        [HttpGet("get/cotisations/{id}")]
        public async Task<IActionResult> GetCotisations(int id)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(id);
            if (membre != null && membre.Cotisations != null)
            {
                var cotisationsDto = mapper.Map<IEnumerable<CotisationDto>>(membre.Cotisations);
                return Ok(cotisationsDto);
            }
            return NotFound();
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

        [HttpPost("add/cotisation/{id}")]
        public async Task<IActionResult> AddCotisation(int id, CotisationDto cotisationDto)
        {

            var membreFromDb = await uow.MembreRepository.FindByIdAsync(id);
            if (membreFromDb != null && membreFromDb.Cotisations != null)
            {
                var cotisation = membreFromDb.Cotisations.FirstOrDefault(c => c.Periode == cotisationDto.Periode);
                if (cotisation is null)
                {
                    cotisation = mapper.Map<Cotisation>(cotisationDto);
                    cotisation.CreatedBy = 1;
                    cotisation.LastUpdatedBy = 1;
                    cotisation.LastUpdatedOn = DateTime.Now;
                    membreFromDb.Cotisations.Add(cotisation);
                    await uow.SaveAsync();
                    return StatusCode(201);
                }
            }
            return BadRequest("La cotisation de se mois a déjà été enregistrer");
        }

        [HttpPut("update/cotisation/{id}")]
        public async Task<IActionResult> UpdateCotisation(int id, CotisationDto cotisationDto)
        {

            var membreFromDb = await uow.MembreRepository.FindByIdAsync(id);
            if (membreFromDb != null && membreFromDb.Cotisations != null)
            {
                var cotisation = membreFromDb.Cotisations.FirstOrDefault(c => c.Id == cotisationDto.Id);
                if (cotisation is not null)
                {
                    cotisation.Montant = cotisationDto.Montant;
                    cotisation.CreatedBy = 1;
                    cotisation.LastUpdatedBy = 1;
                    cotisation.LastUpdatedOn = DateTime.Now;
                    if (await uow.SaveAsync())
                        return StatusCode(200);
                }
            }
            return BadRequest("La cotisation de se mois a déjà été enregistrer");
        }


        [HttpPost("add/avance/{id}")]
        public async Task<IActionResult> AddAvance(int id, AvanceDto avanceDto)
        {

            var membreFromDb = await uow.MembreRepository.FindByIdAsync(id);
            if (membreFromDb != null && membreFromDb.Avances != null)
            {
                var avance = mapper.Map<Avance>(avanceDto);
                avance.CreatedBy = 1;
                avance.LastUpdatedBy = 1;
                avance.LastUpdatedOn = DateTime.Now;
                /*foreach (EcheanceAvanceDto echeanceDto in avanceDto.EcheanceAvances)
                {
                    var echeance = mapper.Map<EcheanceAvance>(echeanceDto);
                    echeance.CreatedBy = 1;
                    echeance.LastUpdatedBy = 1;
                    echeance.LastUpdatedOn = DateTime.Now;
                    avance.EcheanceAvances.Add(echeance);
                }*/

                membreFromDb.Avances.Add(avance);
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