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

        [HttpPost("addCotisations/{id}")]
        public async Task<IActionResult> AddCotisations(int id,CotisationDto[] cotisationsDto)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(id);

            if(membre is null) {
                return NotFound("Ce membre n'existe pas");
            }

            foreach(var cotisationDto in cotisationsDto) {
                if(cotisationDto.Id == 0) {
                    // MOUVEMENT D"ENREGISTREMENT DE LA COTISATION DU MOIS
                    var cotisation = mapper.Map<Cotisation>(cotisationDto);
                    cotisation.Membre = membre;
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
                    mouvement.Cotisation = cotisation;
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


                    // RETENU 10%
                    mouvement = new Mouvement();
                    mouvement.Cotisation = cotisation;
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
                }
            }
            
            // await uow.SaveAsync();
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
        
            var comptesDto = new List<CompteDto>();
            if(membres is null) {
                return NotFound();
            }
            foreach(var membre in membres) {
                var compte = new CompteDto();
                compte.Membre = mapper.Map<MembreDto>(membre);
                compte.Solde = 0;

                var mouvements = new List<Mouvement>();
                //Les mouvements de décaissement des credits
                var infosMembre = await uow.MembreRepository.FindByIdAsync(membre.Id);
                if(infosMembre is not null) {
                    if(infosMembre.Cotisations is not null) {
                        foreach(var cotisation in infosMembre.Cotisations) {
                            var infosCotisation = await uow.CotisationRepository.FindByIdAsync(cotisation.Id);
                            if(infosCotisation is not null) {
                                if(infosCotisation.Mouvements is not null) {
                                    foreach(var mouvement in infosCotisation.Mouvements) {
                                        mouvements.Add(mouvement);
                                    }
                                }
                            }
                        }
                    }
                }
                
                
                decimal solde = 0;
                if(membre.Cotisations is not null) {
                    foreach(var cotisation in membre.Cotisations) {
                        solde += cotisation.Montant;
                    }
                }
                
                compte.Solde = solde;

                compte.Mouvements = mapper.Map<ICollection<MouvementDto>>(mouvements);
                
                comptesDto.Add(compte);
            }
            return Ok(comptesDto);
        }

        [HttpGet("mvtsmembre/{id}")]
        public async Task<IActionResult> GetMvtsMembre(int id)
        {
            var cotisations = await uow.CotisationRepository.GetAllAsync();
        

            var mouvements = new List<Mouvement>();

            

            //Les mouvements de cotisation
            if(cotisations is not null) {
                foreach(var cotisation in cotisations) {
                    if( cotisation is not null && cotisation.MembreId == id) {
                        if(cotisation.Mouvements is not null) {
                            foreach(var mouvement in cotisation.Mouvements){
                                mouvements.Add(mouvement);
                            } 
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
            var membre = await uow.MembreRepository.FindByIdAsync(id);
        
            if(membre is null) {
                return NotFound("Ce membre n'existe pas");
            }
            
            var cotisationsMembre = new CotisationsMembre();
            cotisationsMembre.Membre = mapper.Map<MembreDto>(membre);
            cotisationsMembre.Cotisations = mapper.Map<ICollection<CotisationDto>>(membre.Cotisations);
            return Ok(cotisationsMembre);
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