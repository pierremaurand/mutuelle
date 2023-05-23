using System.Collections.Generic;
using System.Threading.Tasks;
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
                    // MOUVEMENT D"ENREGISTREMENT DE LA COTISATION DU MOIS
                    var cotisation = mapper.Map<Cotisation>(cotisationDto);
                    cotisation.ModifiePar = GetUserId();
                    cotisation.ModifieLe = DateTime.Now;
                    uow.CotisationRepository.Add(cotisation);
                    await uow.SaveAsync();

                    var mois = await uow.MoisRepository.FindAsync(cotisation.MoisId);
                    var dateMvt = cotisation.Annee + "-" + "01" + "-25";
                    if(mois is not null && mois.Valeur is not null) {
                        dateMvt = cotisation.Annee + "-" + mois.Valeur + "-25";
                    }

                    // MOUVEMENT D"ENREGISTREMENT DE LA COTISATION DU MOIS
                    var mouvement = new Mouvement();
                    var libelle = "Cotisation du 01/" + cotisation.Annee;
                    if(mois is not null) {
                        libelle = "Cotisation du " + mois.Valeur + "/" + cotisation.Annee;
                    }
                    mouvement.DateMvt = dateMvt;
                    mouvement.TypeOperation = TypeOperation.Credit;
                    mouvement.GabaritId = 1;
                    mouvement.Libelle = libelle;
                    if (cotisation.Montant != 0){
                        mouvement.Montant = cotisation.Montant;
                    }
                    mouvement.ModifiePar = GetUserId();
                    mouvement.ModifieLe = DateTime.Now;
                    uow.MouvementRepository.Add(mouvement);
                    await uow.SaveAsync();

                    var mvtCotisation = new MvtCotisation();
                    mvtCotisation.CotisationId = cotisation.Id; 
                    mvtCotisation.MouvementId = mouvement.Id;
                    mvtCotisation.ModifiePar = GetUserId();
                    mvtCotisation.ModifieLe = DateTime.Now;
                    uow.MvtCotisationRepository.Add(mvtCotisation);
                    await uow.SaveAsync();


                    // RETENU 10%
                    mouvement = new Mouvement();
                    libelle = "Cotisation du 01/" + cotisation.Annee;
                    if(mois is not null) {
                        libelle = "Retenu des 10% sur cotisation du  " + mois.Valeur + "/" + cotisation.Annee;
                    }
                    mouvement.DateMvt = dateMvt;
                    mouvement.TypeOperation = TypeOperation.Debit;
                    mouvement.GabaritId = 1;
                    mouvement.Libelle = libelle;
                    if (cotisation.Montant != 0){
                        mouvement.Montant = (cotisation.Montant * 1) / 10;
                    }
                    mouvement.ModifiePar = GetUserId();
                    mouvement.ModifieLe = DateTime.Now;
                    uow.MouvementRepository.Add(mouvement);
                    await uow.SaveAsync();

                    mvtCotisation = new MvtCotisation();
                    mvtCotisation.CotisationId = cotisation.Id; 
                    mvtCotisation.MouvementId = mouvement.Id;
                    mvtCotisation.ModifiePar = GetUserId();
                    mvtCotisation.ModifieLe = DateTime.Now;
                    uow.MvtCotisationRepository.Add(mvtCotisation);
                    await uow.SaveAsync();
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
            var membres = await uow.MembreRepository.GetAllAsync();
            var mvtCotisations = await uow.MvtCotisationRepository.GetAllAsync();
        

            var comptesDto = new List<CompteDto>();
            if(membres is null) {
                return NotFound();
            }
            foreach(var membre in membres) {
                
                var compte = new CompteDto();
                compte.Membre = mapper.Map<MembreListDto>(membre);
                compte.Solde = 0;

                var mouvements = new List<Mouvement>();

                //Les mouvements de décaissement des credits 
                if(mvtCotisations is not null) {
                    foreach(var mvt in mvtCotisations) {
                        if(mvt.Cotisation is not null && mvt.Cotisation.MembreId == membre.Id) {
                            if(mvt.Mouvement is not null ) {
                                mouvements.Add(mvt.Mouvement);
                            }
                        }
                    }
                }
                
                decimal solde = 0;
                foreach(var mvt in mouvements) {
                    if(mvt.TypeOperation == TypeOperation.Credit) {
                        solde += mvt.Montant;
                    } 
                }
                compte.Solde = solde;
               
                comptesDto.Add(compte);
            }
            return Ok(comptesDto);
        }

        [HttpGet("mvtsmembre/{id}")]
        public async Task<IActionResult> GetMvtsMembre(int id)
        {
            var mvtCotisations = await uow.MvtCotisationRepository.GetAllAsync();
        

            var mouvements = new List<Mouvement>();

            

            //Les mouvements de cotisation
            if(mvtCotisations is not null) {
                foreach(var mvt in mvtCotisations) {
                    if( mvt.Cotisation is not null && mvt.Cotisation.MembreId == id) {
                        if(mvt.Mouvement is not null) {
                            mouvements.Add(mvt.Mouvement);
                        }
                    }
                }
            }

            var mouvementsDto = mapper.Map<IEnumerable<MouvementDto>>(mouvements);
            return Ok(mouvementsDto);
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