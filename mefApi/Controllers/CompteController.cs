using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace mefApi.Controllers
{
    public class CompteController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CompteController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpPost("addmvts/{id}")]
        public async Task<IActionResult> AddMvts(int id, MouvementDto[] mouvementsDto)
        {

            foreach(var mouvementDto in mouvementsDto) {
                if(mouvementDto.Id == 0) {
                    var mouvement = mapper.Map<Mouvement>(mouvementDto);
                    mouvement.ModifiePar = GetUserId();
                    mouvement.ModifieLe = DateTime.Now;
                    uow.MouvementRepository.Add(mouvement);
                    await uow.SaveAsync();

                    var mvtCompteDto = new MvtCompteDto();
                    mvtCompteDto.MembreId = id; 
                    mvtCompteDto.MouvementId = mouvement.Id;
                    var mvtCompte = mapper.Map<MvtCompte>(mvtCompteDto);
                    mvtCompte.ModifiePar = GetUserId();
                    mvtCompte.ModifieLe = DateTime.Now;
                    uow.MvtCompteRepository.Add(mvtCompte);
                     await uow.SaveAsync();
                }
            }
            
            return StatusCode(201);
        }

        [HttpGet("membres")]
        public async Task<IActionResult> GetAllMembres()
        {
            var membres = await uow.MembreRepository.GetByEtatAsync(true);
            if(membres is null) {
                return NotFound();
            }
            var membresDto = mapper.Map<IEnumerable<MembreListDto>>(membres);
            return Ok(membresDto);
        }

        [HttpGet("comptes")]
        public async Task<IActionResult> GetAllComptes()
        {
            var membres = await uow.MembreRepository.GetAllAsync();

            var mvtComptes = await uow.MvtCompteRepository.GetAllAsync();
            var mvtDeblocageAvances = await uow.MvtAvanceDebourseRepository.GetAllAsync();
            var mvtDeblocageCredits = await uow.MvtCreditDebourseRepository.GetAllAsync();
            var mvtEcheanceAvances = await uow.MvtEcheanceAvanceRepository.GetAllAsync();
            var mvtEcheanceCredits = await uow.MvtEcheanceCreditRepository.GetAllAsync();
        

            var comptesDto = new List<CompteDto>();
            if(membres is null) {
                return NotFound();
            }
            foreach(var membre in membres) {
                
                var compte = new CompteDto();
                compte.Membre = mapper.Map<MembreListDto>(membre);
                compte.Solde = 0;

                var mouvements = new List<Mouvement>();

                //Les mouvement de comptes
                if(mvtComptes is not null) {
                    foreach(var mvt in mvtComptes) {
                        if( mvt.MembreId == membre.Id) {
                            if(mvt.Mouvement is not null) {
                                mouvements.Add(mvt.Mouvement);
                            }
                        }
                    }
                }

                //Les mouvements de décaissement des avances 
                if(mvtDeblocageAvances is not null) {
                    foreach(var mvt in mvtDeblocageAvances) {
                        if(mvt.AvanceDebourse is not null) {
                            var avance = await uow.AvanceRepository.FindByIdAsync(mvt.AvanceDebourse.AvanceId);
                            if(avance is not null && avance.MembreId == membre.Id) {
                                if(mvt.Mouvement is not null) {
                                mouvements.Add(mvt.Mouvement);
                                }
                            }
                        }
                    }
                }

                //Les mouvements de décaissement des credits 
                if(mvtDeblocageCredits is not null) {
                    foreach(var mvt in mvtDeblocageCredits) {
                        if(mvt.CreditDebourse is not null) {
                            var credit = await uow.CreditRepository.FindByIdAsync(mvt.CreditDebourse.CreditId);
                            if(credit is not null && credit.MembreId == membre.Id) {
                                if(mvt.Mouvement is not null ) {
                                    mouvements.Add(mvt.Mouvement);
                                }
                            }
                        }
                    }
                }

                //Les mouvements de reboursement echeance avance 
                if(mvtEcheanceAvances is not null) {
                    foreach(var mvt in mvtEcheanceAvances) {
                        if(mvt.EcheanceAvance is not null) {
                            var avance = await uow.AvanceRepository.FindByIdAsync(mvt.EcheanceAvance.AvanceId);
                            if(avance is not null && avance.MembreId == membre.Id) {
                                if(mvt.Mouvement is not null) {
                                    mouvements.Add(mvt.Mouvement);
                                }
                            }
                        }
                    }
                }

                //Les mouvements de reboursement échéance credit 
                if(mvtEcheanceCredits is not null) {
                    foreach(var mvt in mvtEcheanceCredits) {
                        if(mvt.EcheanceCredit is not null) {
                            var credit = await uow.CreditRepository.FindByIdAsync(mvt.EcheanceCredit.CreditId);
                            if(credit is not null && credit.MembreId == membre.Id) {
                                if(mvt.Mouvement is not null) {
                                    mouvements.Add(mvt.Mouvement);
                                }
                            }
                        }
                    }
                }
                
                decimal solde = 0;
                foreach(var mvt in mouvements) {
                    if(mvt.TypeOperation == TypeOperation.Credit) {
                        solde += mvt.Montant;
                    } else {
                        solde -= mvt.Montant;
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
            var mvtComptes = await uow.MvtCompteRepository.GetAllAsync();
            var mvtDeblocageAvances = await uow.MvtAvanceDebourseRepository.GetAllAsync();
            var mvtDeblocageCredits = await uow.MvtCreditDebourseRepository.GetAllAsync();
            var mvtEcheanceAvances = await uow.MvtEcheanceAvanceRepository.GetAllAsync();
            var mvtEcheanceCredits = await uow.MvtEcheanceCreditRepository.GetAllAsync();
        

            var mouvements = new List<Mouvement>();

            //Les mouvement de comptes
            if(mvtComptes is not null) {
                foreach(var mvt in mvtComptes) {
                    if( mvt.MembreId == id) {
                        if(mvt.Mouvement is not null) {
                            mouvements.Add(mvt.Mouvement);
                        }
                    }
                }
            }

            //Les mouvements de décaissement des avances 
            if(mvtDeblocageAvances is not null) {
                foreach(var mvt in mvtDeblocageAvances) {
                    if(mvt.AvanceDebourse is not null) {
                        var avance = await uow.AvanceRepository.FindByIdAsync(mvt.AvanceDebourse.AvanceId);
                        if(avance is not null && avance.MembreId == id) {
                            if(mvt.Mouvement is not null) {
                               mouvements.Add(mvt.Mouvement);
                            }
                        }
                    }
                }
            }

            //Les mouvements de décaissement des credits 
            if(mvtDeblocageCredits is not null) {
                foreach(var mvt in mvtDeblocageCredits) {
                    if(mvt.CreditDebourse is not null) {
                        var credit = await uow.CreditRepository.FindByIdAsync(mvt.CreditDebourse.CreditId);
                        if(credit is not null && credit.MembreId == id) {
                            if(mvt.Mouvement is not null ) {
                                mouvements.Add(mvt.Mouvement);
                            }
                        }
                    }
                }
            }

            //Les mouvements de reboursement echeance avance 
            if(mvtEcheanceAvances is not null) {
                foreach(var mvt in mvtEcheanceAvances) {
                    if(mvt.EcheanceAvance is not null) {
                        var avance = await uow.AvanceRepository.FindByIdAsync(mvt.EcheanceAvance.AvanceId);
                        if(avance is not null && avance.MembreId == id) {
                            if(mvt.Mouvement is not null) {
                                mouvements.Add(mvt.Mouvement);
                            }
                        }
                    }
                }
            }

            //Les mouvements de reboursement échéance credit 
            if(mvtEcheanceCredits is not null) {
                foreach(var mvt in mvtEcheanceCredits) {
                    if(mvt.EcheanceCredit is not null) {
                        var credit = await uow.CreditRepository.FindByIdAsync(mvt.EcheanceCredit.CreditId);
                        if(credit is not null && credit.MembreId == id) {
                            if(mvt.Mouvement is not null) {
                                mouvements.Add(mvt.Mouvement);
                            }
                        }
                    }
                }
            }

            var mouvementsDto = mapper.Map<IEnumerable<MouvementDto>>(mouvements);
            return Ok(mouvementsDto);
        }

        [HttpGet("mvtcomptes")]
        public async Task<IActionResult> GetAllMvtComptes()
        {
            var mvtcomptes = await uow.MvtCompteRepository.GetAllAsync();
            if(mvtcomptes is null) {
                return NotFound();
            }
            var mvtcomptesDto = mapper.Map<IEnumerable<MvtCompteDto>>(mvtcomptes);
            return Ok(mvtcomptesDto);
        }

        [HttpGet("mvtcomptes/{id}")]
        public async Task<IActionResult> GetAllMvtsById(int id)
        {
            var mvtcomptes = await uow.MvtCompteRepository.FindByIdAsync(id);
            if(mvtcomptes is null) {
                return NotFound();
            }
            var mvtcomptesDto = mapper.Map<IEnumerable<MvtCompteDto>>(mvtcomptes);
            return Ok(mvtcomptesDto);
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