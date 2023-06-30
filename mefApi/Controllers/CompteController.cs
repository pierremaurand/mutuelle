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
        [AllowAnonymous]
        public async Task<IActionResult> AddMvts(int id, MouvementDto[] mouvementsDto)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(id);
            if(membre is null) {
                return NotFound("Ce membre n'existe pas dans la base");
            }

            foreach(var mouvementDto in mouvementsDto) {
                if(mouvementDto.Id == 0) {
                    var mouvement = mapper.Map<Mouvement>(mouvementDto);
                    mouvement.Membre = membre;
                    mouvement.ModifiePar = GetUserId();
                    mouvement.ModifieLe = DateTime.Now;
                    uow.MouvementRepository.Add(mouvement);
                    await uow.SaveAsync();
                }
            }
            
            return StatusCode(201);
        }


        [HttpGet("comptes")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllComptes()
        {
            var membres = await uow.MembreRepository.GetAllAsync();
        

            if(membres is null) {
                return NotFound("Aucun compte n'a été trouvé dans la base");
            }

            var comptesDto = new List<CompteDto>();

            foreach(var membre in membres) {
                var compte = new CompteDto();
                compte.Membre = mapper.Map<MembreDto>(membre);
                compte.Solde = 0;
                var membreInfos = await uow.MembreRepository.FindByIdAsync(membre.Id);
                var mouvements = new List<Mouvement>();

                if(membreInfos is not null) {

                    // infos mouvements membres
                    if(membreInfos.Mouvements is not null) {
                        foreach(var mouvement in membreInfos.Mouvements) {
                            mouvements.Add(mouvement);
                        }
                    }

                    // infos mouvements cotisations
                    if(membreInfos.Cotisations is not null) {
                        foreach(var cotisation in membreInfos.Cotisations) {
                            var cotisationInfos = await uow.CotisationRepository.FindByIdAsync(cotisation.Id);
                            if(cotisationInfos is not null) {
                                if(cotisationInfos.Mouvements is not null) {
                                    foreach(var mouvement in cotisationInfos.Mouvements) {
                                        mouvements.Add(mouvement);
                                    }
                                }
                            }
                        }
                    }
                    
                    // infos mouvemntes avances
                    if(membreInfos.Avances is not null) {
                        foreach(var avance in membreInfos.Avances) {
                            var avanceInfos = await uow.AvanceRepository.FindByIdAsync(avance.Id);
                            if(avanceInfos is not null) {
                                if(avanceInfos.AvanceDebourse is not null) {
                                    var accord = await uow.AvanceDebourseRepository.FindByIdAsync(avanceInfos.AvanceDebourse.Id);
                                    if(accord is not null && accord.Mouvement is not null) {
                                        mouvements.Add(accord.Mouvement);
                                    } 
                                }

                                if(avanceInfos.Echeancier is not null) {
                                    foreach(var echeance in avanceInfos.Echeancier) {
                                        var eche = await uow.EcheanceAvanceRepository.FindByIdAsync(echeance.Id);
                                        if(eche is not null && eche.Mouvements is not null) {
                                            foreach(var mvt in eche.Mouvements) {
                                                mouvements.Add(mvt);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // infos mouvements crédits
                    if(membreInfos.Credits is not null) {
                        foreach(var credit in membreInfos.Credits) {
                            var creditInfos = await uow.CreditRepository.FindByIdAsync(credit.Id);
                            if(creditInfos is not null) {
                                if(creditInfos.Mouvements is not null) {
                                    foreach(var mvt in creditInfos.Mouvements) {
                                        mouvements.Add(mvt);
                                    }
                                }

                                if(creditInfos.CreditDebourse is not null) {
                                    var accord = await uow.CreditDebourseRepository.FindByIdAsync(creditInfos.CreditDebourse.Id);
                                    if(accord is not null && accord.Mouvement is not null) {
                                        mouvements.Add(accord.Mouvement);
                                    } 
                                }

                                if(creditInfos.Echeancier is not null) {
                                    foreach(var echeance in creditInfos.Echeancier) {
                                        var eche = await uow.EcheanceCreditRepository.FindByIdAsync(echeance.Id);
                                        if(eche is not null && eche.Mouvements is not null) {
                                            foreach(var mvt in eche.Mouvements) {
                                                mouvements.Add(mvt);
                                            }
                                        }
                                    }
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

                compte.Mouvements = mapper.Map<ICollection<MouvementDto>>(mouvements);
               
                comptesDto.Add(compte);
            }
            return Ok(comptesDto);
        }

        [HttpGet("compte/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCompte(int id)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(id);

            if(membre is null) {
                return NotFound("Ce compte n'existe pas");
            }

            var compte = new CompteDto();
            compte.Membre = mapper.Map<MembreDto>(membre);
            compte.Solde = 0;
            var mouvements = new List<Mouvement>();

            if(membre is not null) {
                // mouvements du membres
                if(membre.Mouvements is not null) {
                    foreach(var mouvement in membre.Mouvements) {
                        mouvements.Add(mouvement);
                    }
                }

                // mouvements de cotisations
                if(membre.Cotisations is not null) {
                    foreach(var cotisation in membre.Cotisations) {
                        var cotisationInfos = await uow.CotisationRepository.FindByIdAsync(cotisation.Id);
                        if(cotisationInfos is not null) {
                            if(cotisationInfos.Mouvements is not null) {
                                foreach(var mouvement in cotisationInfos.Mouvements) {
                                    mouvements.Add(mouvement);
                                }
                            }
                        }
                    }
                }
                
                // infos mouvemntes avances
                if(membre.Avances is not null) {
                    foreach(var avance in membre.Avances) {
                        var avanceInfos = await uow.AvanceRepository.FindByIdAsync(avance.Id);
                        if(avanceInfos is not null) {
                            if(avanceInfos.AvanceDebourse is not null) {
                                var accord = await uow.AvanceDebourseRepository.FindByIdAsync(avanceInfos.AvanceDebourse.Id);
                                if(accord is not null && accord.Mouvement is not null) {
                                    mouvements.Add(accord.Mouvement);
                                } 
                            }

                            if(avanceInfos.Echeancier is not null) {
                                foreach(var echeance in avanceInfos.Echeancier) {
                                    var eche = await uow.EcheanceAvanceRepository.FindByIdAsync(echeance.Id);
                                    if(eche is not null && eche.Mouvements is not null) {
                                        foreach(var mvt in eche.Mouvements) {
                                            mouvements.Add(mvt);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // infos mouvements crédits
                if(membre.Credits is not null) {
                    foreach(var credit in membre.Credits) {
                        var creditInfos = await uow.CreditRepository.FindByIdAsync(credit.Id);
                        if(creditInfos is not null) {
                            if(creditInfos.Mouvements is not null) {
                                foreach(var mvt in creditInfos.Mouvements) {
                                    mouvements.Add(mvt);
                                }
                            }

                            if(creditInfos.CreditDebourse is not null) {
                                var accord = await uow.CreditDebourseRepository.FindByIdAsync(creditInfos.CreditDebourse.Id);
                                if(accord is not null && accord.Mouvement is not null) {
                                    mouvements.Add(accord.Mouvement);
                                } 
                            }

                            if(creditInfos.Echeancier is not null) {
                                foreach(var echeance in creditInfos.Echeancier) {
                                    var eche = await uow.EcheanceCreditRepository.FindByIdAsync(echeance.Id);
                                    if(eche is not null && eche.Mouvements is not null) {
                                        foreach(var mvt in eche.Mouvements) {
                                            mouvements.Add(mvt);
                                        }
                                    }
                                }
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

            compte.Mouvements = mapper.Map<ICollection<MouvementDto>>(mouvements);
            
            return Ok(compte);
        }

        [HttpGet("mvtsmembre/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMvtsMembre(int id)
        {
            var membre = await uow.MembreRepository.FindByIdAsync(id);

            if(membre is null) {
                return NotFound("Ce membre n'existe pas");
            }
        

            var mouvements = new List<Mouvement>();
            // mouvements du membres
            if(membre.Mouvements is not null) {
                foreach(var mouvement in membre.Mouvements) {
                    mouvements.Add(mouvement);
                }
            }

            // mouvements de cotisations
            if(membre.Cotisations is not null) {
                foreach(var cotisation in membre.Cotisations) {
                    var cotisationInfos = await uow.CotisationRepository.FindByIdAsync(cotisation.Id);
                    if(cotisationInfos is not null) {
                        if(cotisationInfos.Mouvements is not null) {
                            foreach(var mouvement in cotisationInfos.Mouvements) {
                                mouvements.Add(mouvement);
                            }
                        }
                    }
                }
            }
            
            // infos mouvemntes avances
            if(membre.Avances is not null) {
                foreach(var avance in membre.Avances) {
                    var avanceInfos = await uow.AvanceRepository.FindByIdAsync(avance.Id);
                    if(avanceInfos is not null) {
                        if(avanceInfos.AvanceDebourse is not null) {
                            var accord = await uow.AvanceDebourseRepository.FindByIdAsync(avanceInfos.AvanceDebourse.Id);
                            if(accord is not null && accord.Mouvement is not null) {
                                mouvements.Add(accord.Mouvement);
                            } 
                        }

                        if(avanceInfos.Echeancier is not null) {
                            foreach(var echeance in avanceInfos.Echeancier) {
                                var eche = await uow.EcheanceAvanceRepository.FindByIdAsync(echeance.Id);
                                if(eche is not null && eche.Mouvements is not null) {
                                    foreach(var mvt in eche.Mouvements) {
                                        mouvements.Add(mvt);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // infos mouvements crédits
            if(membre.Credits is not null) {
                foreach(var credit in membre.Credits) {
                    var creditInfos = await uow.CreditRepository.FindByIdAsync(credit.Id);
                    if(creditInfos is not null) {
                        if(creditInfos.Mouvements is not null) {
                            foreach(var mvt in creditInfos.Mouvements) {
                                mouvements.Add(mvt);
                            }
                        }

                        if(creditInfos.CreditDebourse is not null) {
                            var accord = await uow.CreditDebourseRepository.FindByIdAsync(creditInfos.CreditDebourse.Id);
                            if(accord is not null && accord.Mouvement is not null) {
                                mouvements.Add(accord.Mouvement);
                            } 
                        }

                        if(creditInfos.Echeancier is not null) {
                            foreach(var echeance in creditInfos.Echeancier) {
                                var eche = await uow.EcheanceCreditRepository.FindByIdAsync(echeance.Id);
                                if(eche is not null && eche.Mouvements is not null) {
                                    foreach(var mvt in eche.Mouvements) {
                                        mouvements.Add(mvt);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return Ok(mapper.Map<ICollection<MouvementDto>>(mouvements));
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