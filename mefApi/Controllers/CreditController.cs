using AutoMapper;
using mefApi.Dtos;
using mefApi.Enums;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using mefApi.HubConfig;
using mefapi.Enums;

namespace mefApi.Controllers
{
    public class CreditController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IHubContext<SignalrServer> signalrHub; 

        public CreditController(IMapper mapper, IUnitOfWork uow, IHubContext<SignalrServer> signalrHub)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.signalrHub = signalrHub;
        }

        [HttpGet("credits")]
        public async Task<IActionResult> GetAll()
        {
            var credits = await uow.CreditRepository.GetAllAsync();
            var creditsDto = new List<CreditDto>();
            if(credits is not null) {
                creditsDto = mapper.Map<List<CreditDto>>(credits);
            }
            
            
            return Ok(creditsDto);
        }

        /*[HttpGet("echeances")]
        public async Task<IActionResult> GetAllEcheances()
        {
            // var echeances = await uow.EcheanceCreditRepository.GetAllAsync();
            // var echeancesDto = new List<EcheanceCreditDto>();
            // if(echeances is not null) {
            //     echeancesDto = mapper.Map<List<EcheanceCreditDto>>(echeances);
            // }

            // if(echeancesDto is not null) {
            //     foreach(var echeance in echeancesDto) {
            //         echeance.MontantPaye = calculMontantPayeEcheance(echeance);
            //     }
            // }
            
            return Ok();
        }*/


        [HttpPost("add")]
        public async Task<IActionResult> Add(CreditDto creditDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var credit = mapper.Map<Credit>(creditDto);

            credit.ModifiePar = GetUserId();
            credit.ModifieLe = DateTime.Now;

            uow.CreditRepository.Add(credit);
            await uow.SaveAsync();
            await signalrHub.Clients.All.SendAsync("CreditAdded");
            return StatusCode(201);
        }

        [HttpPost("deboursercredit/{id}")]
        public async Task<IActionResult> DebourserCredit(int id, CreditDebourseDto creditDto)
        {
            // if(!ModelState.IsValid) 
            //     return BadRequest(ModelState);

            // var credit = await uow.CreditRepository.FindByIdAsync(id);
            // if(credit is null) {
            //     return NotFound("Cet credit n'existe pas dans la base de données");
            // }

            // var membre = await uow.MembreRepository.FindByIdAsync(credit.MembreId);
            // if(membre is null) {
            //     return NotFound("Ce membre n'existe pas dans la base de données");
            // }

            // // MOUVEMENT DE DEBOURSEMENT
            // var mouvement = new Mouvement();
            // mouvement.Credit = credit;
            // mouvement.Membre = membre;
            // mouvement.DateMvt = creditDto.DateDecaissement;
            // mouvement.TypeOperation = TypeOperation.Debit;
            // mouvement.GabaritId = 1;
            // mouvement.Libelle = "Déboursement credit N° " + id + " du " + credit.DateDemande;
            // if (creditDto.MontantAccorde != 0){
            //     mouvement.Montant = creditDto.MontantAccorde;
            // }
            // mouvement.ModifiePar = GetUserId();
            // mouvement.ModifieLe = DateTime.Now;
            // uow.MouvementRepository.Add(mouvement);
            // await uow.SaveAsync();

            // var creditDebourse = mapper.Map<CreditDebourse>(creditDto);
            // creditDebourse.Credit = credit;
            // creditDebourse.Mouvement = mouvement;
            // creditDebourse.ModifiePar = GetUserId();
            // creditDebourse.ModifieLe = DateTime.Now;
            // uow.CreditDebourseRepository.Add(creditDebourse);
            // await uow.SaveAsync();

            // MOUVEMENT DE PRELEVEMENT DE LA COMMISSION
            // mouvement = new Mouvement();
            // mouvement.Credit = credit;
            // mouvement.DateMvt = creditDto.DateDecaissement;
            // mouvement.TypeOperation = TypeOperation.Debit;
            // mouvement.GabaritId = 1;
            // mouvement.Libelle = "Prélèvement de la commission sur credit N° " + id + " du " + credit.DateDemande;
            // if (creditDto.MontantCommission != 0){
            //     mouvement.Montant = creditDto.MontantCommission;
            // }
            // mouvement.ModifiePar = GetUserId();
            // mouvement.ModifieLe = DateTime.Now;
            // uow.MouvementRepository.Add(mouvement);
            // await uow.SaveAsync();
            await signalrHub.Clients.All.SendAsync("CreditAdded");
            return StatusCode(201);
        }

        [HttpPost("addecheancier/{id}")]
        public async Task<IActionResult> AddEcheancier(int id, EcheanceCreditDto[] echeanceCreditsDto)
        {
            // if(!ModelState.IsValid) 
            //     return BadRequest(ModelState);

            // var credit = await uow.CreditRepository.FindByIdAsync(id);
            // if(credit is null) {
            //     return NotFound("Cet credit n'existe pas dans la base de données");
            // }

            // foreach(var echeanceDto in echeanceCreditsDto) {
            //     var echeance = mapper.Map<EcheanceCredit>(echeanceDto);
            //     if(echeanceDto.Id == 0) {
            //         echeance.Credit = credit;
            //         echeance.ModifiePar = GetUserId();
            //         echeance.ModifieLe = DateTime.Now;
            //         uow.EcheanceCreditRepository.Add(echeance);
            //         await uow.SaveAsync();
            //     }
            // }
            
            await signalrHub.Clients.All.SendAsync("CreditAdded");
            return StatusCode(201);
        }
    }
}