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
                    if(membreInfos.Mouvements is not null) {
                        foreach(var mouvement in membreInfos.Mouvements) {
                            mouvements.Add(mouvement);
                        }
                    }

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

                    if(membreInfos.Avances is not null) {
                        foreach(var avance in membreInfos.Avances) {
                            if(avance.AvanceDebourse is not null) {
                                var debour = await uow.AvanceDebourseRepository.FindByIdAsync(avance.AvanceDebourse.AvanceId);
                                if(debour is not null) {
                                    if(debour.Mouvement is not null) {
                                        mouvements.Add(debour.Mouvement);
                                    } 

                                    // if(debour.Echeancier is not null) {
                                    //     foreach(var echeance in debour.Echeancier) {
                                    //         if(echeance.Mouvement is not null) {
                                    //              mouvements.Add(echeance.Mouvement);
                                    //         }
                                    //     }
                                    // }
                                }

                            }
                        }
                    }

                    if(membre.Credits is not null) {
                        foreach(var credit in membre.Credits) {
                            if(credit.CreditDebourse is not null) {
                                if(credit.CreditDebourse.Mouvement is not null) {
                                    mouvements.Add(credit.CreditDebourse.Mouvement);
                                }

                                // if(credit.CreditDebourse.Echeancier is not null) {
                                //     foreach(var echeance in credit.CreditDebourse.Echeancier) {
                                //         if(echeance.Mouvements is not null) {
                                //             foreach(var mouvement in echeance.Mouvements) {
                                //                 mouvements.Add(mouvement);
                                //             }
                                //         }
                                //     }
                                // }
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
            var membreInfos = await uow.MembreRepository.FindByIdAsync(membre.Id);
            var mouvements = new List<Mouvement>();

            if(membreInfos is not null) {
                if(membreInfos.Mouvements is not null) {
                    foreach(var mouvement in membreInfos.Mouvements) {
                        mouvements.Add(mouvement);
                    }
                }

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

                if(membreInfos.Avances is not null) {
                    foreach(var avance in membreInfos.Avances) {
                        if(avance.AvanceDebourse is not null) {
                            var debour = await uow.AvanceDebourseRepository.FindByIdAsync(avance.AvanceDebourse.AvanceId);
                            if(debour is not null) {
                                if(debour.Mouvement is not null) {
                                    mouvements.Add(debour.Mouvement);
                                } 

                                // if(debour.Echeancier is not null) {
                                //     foreach(var echeance in debour.Echeancier) {
                                //         if(echeance.Mouvement is not null) {
                                //              mouvements.Add(echeance.Mouvement);
                                //         }
                                //     }
                                // }
                            }

                        }
                    }
                }

                if(membre.Credits is not null) {
                    foreach(var credit in membre.Credits) {
                        if(credit.CreditDebourse is not null) {
                            if(credit.CreditDebourse.Mouvement is not null) {
                                mouvements.Add(credit.CreditDebourse.Mouvement);
                            }

                            // if(credit.CreditDebourse.Echeancier is not null) {
                            //     foreach(var echeance in credit.CreditDebourse.Echeancier) {
                            //         if(echeance.Mouvements is not null) {
                            //             foreach(var mouvement in echeance.Mouvements) {
                            //                 mouvements.Add(mouvement);
                            //             }
                            //         }
                            //     }
                            // }
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
            if(membre.Mouvements is not null) {
                foreach(var mouvement in membre.Mouvements) {
                    mouvements.Add(mouvement);
                }
            }

            if(membre.Cotisations is not null) {
                foreach(var cotisation in membre.Cotisations) {
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

            if(membre.Avances is not null) {
                foreach(var avance in membre.Avances) {
                    if(avance.AvanceDebourse is not null) {
                        if(avance.AvanceDebourse.Mouvement is not null) {
                            mouvements.Add(avance.AvanceDebourse.Mouvement);
                        }

                        // if(avance.Echeancier is not null) {
                        //     foreach(var echeance in avance.Echeancier) {
                        //         if(echeance.Mouvement is not null) {
                        //             mouvements.Add(echeance.Mouvement);
                        //         }
                        //     }
                        // }
                    }
                }
            }

            if(membre.Credits is not null) {
                foreach(var credit in membre.Credits) {
                    if(credit.CreditDebourse is not null) {
                        if(credit.CreditDebourse.Mouvement is not null) {
                            mouvements.Add(credit.CreditDebourse.Mouvement);
                        }

                        // if(credit.CreditDebourse.Echeancier is not null) {
                        //     foreach(var echeance in credit.CreditDebourse.Echeancier) {
                        //         if(echeance.Mouvements is not null) {
                        //             foreach(var mouvement in echeance.Mouvements) {
                        //                 mouvements.Add(mouvement);
                        //             }
                        //         }
                        //     }
                        // }
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