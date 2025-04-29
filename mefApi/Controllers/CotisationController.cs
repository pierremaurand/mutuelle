using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using mefApi.HubConfig;
using mefapi.Enums;

namespace mefApi.Controllers
{
    public class CotisationController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IHubContext<SignalrServer> signalrHub; 

        public CotisationController(IMapper mapper, IUnitOfWork uow, IHubContext<SignalrServer> signalrHub)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.signalrHub = signalrHub;
        }

        [HttpPost("cotisation")]
        public async Task<IActionResult> AddCotisations(CotisationDto cotisationDto)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(cotisationDto.MembreId);

            if(membre is null) {
                return NotFound("Ce membre n'existe pas");
            }

            if(cotisationDto.Id != 0) {
                return BadRequest("Cette cotisation existe déjà");
            }

            // MOUVEMENT D"ENREGISTREMENT DE LA COTISATION DU MOIS
            var cotisation = mapper.Map<Cotisation>(cotisationDto);
            cotisation.Membre = membre;
            cotisation.ModifiePar = GetUserId();
            cotisation.ModifieLe = DateTime.Now;
            uow.CotisationRepository.Add(cotisation);
            await uow.SaveAsync();

            var dateMvt = cotisation.Annee + "-" + getMois(cotisation.Mois)+ "-25";

            // MOUVEMENT D"ENREGISTREMENT DE LA COTISATION DU MOIS
            var mouvement = new Mouvement();
            mouvement.Cotisation = cotisation;
            mouvement.Membre = membre;
            var libelle = "Cotisation du " + getMois(cotisation.Mois) + cotisation.Annee;
        
            mouvement.DateMvt = dateMvt;
            mouvement.TypeOperation = TypeOperation.CREDIT;
            mouvement.Libelle = libelle;
            mouvement.Montant = cotisation.Montant != 0 ? cotisation.Montant : 0;
            mouvement.ModifiePar = GetUserId();
            mouvement.ModifieLe = DateTime.Now;
            uow.MouvementRepository.Add(mouvement);
            await uow.SaveAsync();

            // RETENU 10%
            mouvement = new Mouvement();
            mouvement.Cotisation = cotisation;
            mouvement.Membre = membre;
            libelle = "Retenu des 10% sur cotisation du " + getMois(cotisation.Mois) + cotisation.Annee;
            mouvement.DateMvt = dateMvt;
            mouvement.TypeOperation = TypeOperation.DEBIT;
            mouvement.Libelle = libelle;
            if (cotisation.Montant != 0){
                mouvement.Montant = (cotisation.Montant * 1) / 10;
            }
            mouvement.ModifiePar = GetUserId();
            mouvement.ModifieLe = DateTime.Now;
            uow.MouvementRepository.Add(mouvement);
            await uow.SaveAsync();
            
            await signalrHub.Clients.All.SendAsync("MouvementAdded");
            await signalrHub.Clients.All.SendAsync("CotisationAdded");
            return StatusCode(201);
        }

        [HttpGet("cotisations")]
        public async Task<IActionResult> GetAll()
        {
            var cotisations = await uow.CotisationRepository.GetAllAsync();
            if(cotisations is null) {
                return NotFound("Aucune cotisation n'est enregistré dans la bdd");
            }

            var cotisationsDto = mapper.Map<List<CotisationDto>>(cotisations);
            return Ok(cotisationsDto);
        }

        private string getMois(Mois mois)
        {
            string moisLibelle = "";
            switch (mois)
            {
                case Mois.JANVIER:
                    moisLibelle = "01";
                    break;
                case Mois.FEVRIER:
                    moisLibelle = "02";
                    break;
                case Mois.MARS:
                    moisLibelle = "03";
                    break;
                case Mois.AVRIL:
                    moisLibelle = "04";
                    break;
                case Mois.MAI:
                    moisLibelle = "05";
                    break;
                case Mois.JUIN:
                    moisLibelle = "06";
                    break;
                case Mois.JUILLET:
                    moisLibelle = "07";
                    break;
                case Mois.AOUT:
                    moisLibelle = "08";
                    break;
                case Mois.SEPTEMBRE:
                    moisLibelle = "09";
                    break;
                case Mois.OCTOBRE:
                    moisLibelle = "10";
                    break;
                case Mois.NOVEMBRE:
                    moisLibelle = "11";
                    break;
                case Mois.DECEMBRE:
                    moisLibelle = "12";
                    break;
            }
            return moisLibelle;
        }

    }
}