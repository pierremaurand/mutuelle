using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mefApi.Controllers
{
    public class AvanceController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AvanceController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var avance = await uow.AvanceRepository.FindByIdAsync(id);
            if(avance is null) {
                return NotFound();
            }

            //Les mouvements de décaissement des avances 
            // var avanceDebourse = await uow.AvanceDebourseRepository.FindByIdAsync(avance.Id);
            // if(avanceDebourse is not null) {
            //     avance.AvanceDebourse = avanceDebourse;
            // }

            // var echeancier = await uow.EcheanceAvanceRepository.FindByIdAsync(avance.Id);
            // if(echeancier is not null) {
            //     avance.Echeancier = echeancier;
            // }

            return Ok(mapper.Map<AvanceDto>(avance));
        }

        [HttpGet("avances")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var avances = await uow.AvanceRepository.GetAllAsync();
            var avancesDto = new List<AvanceDto>();
            if(avances is not null) {
                avancesDto = mapper.Map<List<AvanceDto>>(avances);
            }
            
            return Ok(avancesDto);
        }

        [HttpGet("deboursement/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDeboursement(int id)
        {
            var avances = await uow.AvanceDebourseRepository.GetAllAsync();
            var avanceDto = new AvanceDebourseDto();
            if(avances is not null) {
               var avance = avances.FirstOrDefault((x) => x.AvanceId == id);
               if(avance is not null) {
                avanceDto = mapper.Map<AvanceDebourseDto>(avance);
               }
            }
           
            return Ok(avanceDto);
        }

        [HttpGet("getsolde/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSolde(int id)
        {
            var avances = await uow.AvanceDebourseRepository.GetAllAsync();
            decimal solde = 0;
            if(avances is not null) {
                var avance = avances.FirstOrDefault((x) => x.AvanceId == id);
                //Les mouvements de décaissement des avances 
                 if(avance is not null) {
                    solde += avance.MontantApprouve;
                }
            }

            // var echeancier = await uow.EcheanceAvanceRepository.FindByIdAsync(id);
            // if(echeancier is not null) {
            //     foreach(var echeance in echeancier) {
            //         if(echeance.Mouvement is not null){
            //             solde -= echeance.Mouvement.Montant;
            //         }
            //     }
            // }
           
            return Ok(solde);
        }

        [HttpGet("getinfosavance/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInfosAvance(int id)
        {
            var avances = await uow.AvanceDebourseRepository.GetAllAsync();
            string status = "Enregistré";
            decimal solde = 0;
            if(avances is not null) {
                var avance = avances.FirstOrDefault((x) => x.AvanceId == id);
                //Les mouvements de décaissement des avances 
                if(avance is not null) {
                    status = "Déboursé";
                    solde += avance.MontantApprouve;
                }
            }

            // var echeancier = await uow.EcheanceAvanceRepository.FindByIdAsync(id);
            // if(echeancier is not null) {
            //     foreach(var echeance in echeancier) {
            //         if(echeance.Mouvement is not null){
            //             solde -= echeance.Mouvement.Montant;
            //         }
            //     }
            // }
            if(solde == 0 && status == "Déboursé") {
                status = "Soldé";
            }
           
            return Ok(new {solde = solde, status = status});
        }

        [HttpGet("getmouvements/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMouvements(int id)
        {
            var avance = await uow.AvanceDebourseRepository.FindByIdAsync(id);
            var mouvements = new List<Mouvement>();
            if(avance is not null) {
                if(avance.Mouvement is not null) {
                    mouvements.Add(avance.Mouvement);
                }
                var echeancier = await uow.EcheanceAvanceRepository.FindByIdAsync(avance.Id);
                // if(echeancier is not null) {
                //     foreach(var echeance in echeancier) {
                //         if(echeance.Mouvement is not null){
                //             mouvements.Add(echeance.Mouvement);
                //         }
                //     }
                // }
            }

            var mouvementsDto = mapper.Map<List<MouvementDto>>(mouvements);
           
            return Ok(mouvementsDto);
        }

        [HttpGet("getecheancier/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetEcheancier(int id)
        {
            var echeancier = await uow.EcheanceAvanceRepository.FindByIdAsync(id);
            var echeancierDto = new List<EcheanceAvanceDto>();
            if(echeancier is not null) {
                echeancierDto = mapper.Map<List<EcheanceAvanceDto>>(echeancier);
            }
            
            return Ok(echeancierDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AvanceDto avanceDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var avance = mapper.Map<Avance>(avanceDto);

            avance.ModifiePar = GetUserId();
            avance.ModifieLe = DateTime.Now;

            uow.AvanceRepository.Add(avance);
            await uow.SaveAsync();

            return Ok(mapper.Map<AvanceDto>(avance));
        }

        [HttpPost("debourseravance/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DebourserAvance(int id, AvanceDebourseDto avanceDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var avance = await uow.AvanceRepository.FindByIdAsync(id);
            if(avance is null) {
                return NotFound("Cet avance n'existe pas dans la base de données");
            }

            // MOUVEMENT DE DEBOURSEMENT
            var mouvement = new Mouvement();
            mouvement.DateMvt = avanceDto.DateDecaissement;
            mouvement.TypeOperation = TypeOperation.Debit;
            mouvement.GabaritId = 1;
            mouvement.Libelle = "Déboursement avance N° " + id + " du " + avance.DateDemande;
            if (avanceDto.MontantApprouve != 0){
                mouvement.Montant = avanceDto.MontantApprouve;
            }
            mouvement.ModifiePar = 1;
            mouvement.ModifieLe = DateTime.Now;
            uow.MouvementRepository.Add(mouvement);
            await uow.SaveAsync();

            var avanceDebourse = mapper.Map<AvanceDebourse>(avanceDto);
            avanceDebourse.Avance = avance;
            avanceDebourse.Mouvement = mouvement;
            avanceDebourse.ModifiePar = 1;
            avanceDebourse.ModifieLe = DateTime.Now;
            uow.AvanceDebourseRepository.Add(avanceDebourse);
            await uow.SaveAsync();

            return Ok(mapper.Map<AvanceDebourseDto>(avanceDebourse));
        }

        [HttpPut("update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(int id, AvanceDebourseDto avanceDebourseDto)
        {

            var avance = await uow.AvanceRepository.FindByIdAsync(id);
            
            if(avance is null) 
                return NotFound();

            var avanceDebourse = mapper.Map<AvanceDebourse>(avanceDebourseDto);
            avanceDebourse.ModifiePar = 1;
            avanceDebourse.ModifieLe = DateTime.Now;

            // Enregistrement du mouvement de déboursement dans le conte du membre
            var mouvement = new Mouvement();
            mouvement.DateMvt = avanceDebourse.DateDecaissement;
            mouvement.TypeOperation = TypeOperation.Debit;
            mouvement.GabaritId = 1;
            mouvement.Libelle = "Décaissement avance N°" + avanceDebourse.AvanceId;
            if (avanceDebourse.MontantApprouve != 0){
                mouvement.Montant = avanceDebourse.MontantApprouve;
            }
            mouvement.ModifiePar = 1;
            mouvement.ModifieLe = DateTime.Now;
            avanceDebourse.Mouvement = mouvement;

            // foreach(var echeanceDto in infos.Echeancier) {
            //     var echeance = mapper.Map<EcheanceAvance>(echeanceDto);
            //     if(echeanceDto.Id == 0) {
            //         echeance.ModifiePar = 1;
            //         echeance.ModifieLe = DateTime.Now;
            //         avanceDebourse.Echeancier.Add(echeance);
            //     }
            // }

            avance.AvanceDebourse = avanceDebourse;

            await uow.SaveAsync();
            // infos.Avance = mapper.Map<AvanceDto>(avance);
            // infos.AvanceDebourse = mapper.Map<AvanceDebourseDto>(avance.AvanceDebourse);
            // infos.Echeancier = mapper.Map<ICollection<EcheanceAvanceDto>>(avance.AvanceDebourse.Echeancier);

            return Ok(avance);
        }

        [HttpPost("addecheancier/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> AddEcheancier(int id, EcheanceAvanceDto[] echeanceAvancesDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var avance = await uow.AvanceRepository.FindByIdAsync(id);
            if(avance is null) {
                return NotFound("Cet avance n'existe pas dans la base de données");
            }

            var echeancier = new List<EcheanceAvance>();

            foreach(var echeanceDto in echeanceAvancesDto) {
                var echeance = mapper.Map<EcheanceAvance>(echeanceDto);
                if(echeanceDto.Id == 0) {
                    echeance.ModifiePar = 1;
                    echeance.ModifieLe = DateTime.Now;
                    avance.Echeancier.Add(echeance);
                    await uow.SaveAsync();
                }
                echeancier.Add(echeance);
            }

            var echeancierDto = mapper.Map<List<EcheanceAvanceDto>>(echeancier);
            
            return Ok(echeancierDto);
        }

        
    }
}