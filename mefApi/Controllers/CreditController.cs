using AutoMapper;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mefApi.Controllers
{
    public class CreditController : BaseController
    {
         private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CreditController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var credit = await uow.CreditRepository.FindByIdAsync(id);
            if(credit is null) {
                return NotFound();
            }

            //Les mouvements de décaissement des credits 
            // var creditDebourse = await uow.CreditDebourseRepository.FindByIdAsync(credit.Id);
            // if(creditDebourse is not null) {
            //     credit.CreditDebourse = creditDebourse;
            // }

            // var echeancier = await uow.EcheanceCreditRepository.FindByIdAsync(credit.Id);
            // if(echeancier is not null) {
            //     credit.Echeancier = echeancier;
            // }

            return Ok(mapper.Map<CreditDto>(credit));
        }

        [HttpGet("credits")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var credits = await uow.CreditRepository.GetAllAsync();
            var creditsDto = new List<CreditDto>();
            if(credits is not null) {
                creditsDto = mapper.Map<List<CreditDto>>(credits);
            }
            
            return Ok(creditsDto);
        }

        [HttpGet("deboursement/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDeboursement(int id)
        {
            var credits = await uow.CreditDebourseRepository.GetAllAsync();
            var creditDto = new CreditDebourseDto();
            if(credits is not null) {
               var credit = credits.FirstOrDefault((x) => x.CreditId == id);
               if(credit is not null) {
                creditDto = mapper.Map<CreditDebourseDto>(credit);
               }
            }
           
            return Ok(creditDto);
        }

        [HttpGet("getsolde/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSolde(int id)
        {
            var credits = await uow.CreditDebourseRepository.GetAllAsync();
            decimal solde = 0;
            if(credits is not null) {
                var credit = credits.FirstOrDefault((x) => x.CreditId == id);
                //Les mouvements de décaissement des credits 
                 if(credit is not null) {
                    solde += credit.MontantAccorde;
                }
            }

            // var echeancier = await uow.EcheanceCreditRepository.FindByIdAsync(id);
            // if(echeancier is not null) {
            //     foreach(var echeance in echeancier) {
            //         if(echeance.Mouvement is not null){
            //             solde -= echeance.Mouvement.Montant;
            //         }
            //     }
            // }
           
            return Ok(solde);
        }

        [HttpGet("getinfoscredit/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInfosCredit(int id)
        {
            var credit = await uow.CreditRepository.FindByIdAsync(id);
            string status = "Enregistré";
            decimal solde = 0;
            if(credit is not null && credit.CreditDebourse is not null) {
                var accord = await uow.CreditDebourseRepository.FindByIdAsync(credit.CreditDebourse.CreditId);
                if(accord is not null){
                    solde += accord.MontantInteret + accord.MontantAccorde;
                    if(accord.Mouvement is not null) {
                        status = "Déboursé";
                    }
                }
                
            }

            if(credit is not null && credit.Echeancier is not null) {
                status = "Encours";
                foreach(var echeance in credit.Echeancier) {
                    var echeanceFromDB = await uow.EcheanceCreditRepository.FindByIdAsync(echeance.Id);
                    if(echeanceFromDB is not null && echeanceFromDB.Mouvements is not null){
                        foreach(var mouvement in echeanceFromDB.Mouvements) {
                           solde -= mouvement.Montant; 
                        }
                    }
                }
            }
            if(solde == 0 && status == "Encours") {
                status = "Soldé";
            }
           
            return Ok(new {solde = solde, status = status});
        }

        [HttpGet("getmouvements/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMouvements(int id)
        {
            var credit = await uow.CreditDebourseRepository.FindByIdAsync(id);
            var mouvements = new List<Mouvement>();
            if(credit is not null) {
                if(credit.Mouvement is not null) {
                    mouvements.Add(credit.Mouvement);
                }
                var echeancier = await uow.EcheanceCreditRepository.FindByIdAsync(credit.Id);
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
            var credit = await uow.CreditRepository.FindByIdAsync(id);
            if(credit is null) {
                return NotFound("Cet credit n'exista pas dans la base");
            }
            var echeancierDto = new List<EcheanceCreditDto>();
            if(credit.Echeancier is not null) {
                echeancierDto = mapper.Map<List<EcheanceCreditDto>>(credit.Echeancier);
            }
            
            return Ok(echeancierDto);
        }

        [HttpGet("echeances")]
        [AllowAnonymous]
        public async Task<IActionResult> GetEcheances()
        {
            var echeances = await uow.EcheanceCreditRepository.GetAllAsync();
            var echeancierDto = new List<EcheanceCreditDto>();
            if(echeances is not null) {
                foreach(var echeance in echeances) {
                    var echeanceFromDb = await uow.EcheanceCreditRepository.FindByIdAsync(echeance.Id);
                    if(echeanceFromDb is not null && echeanceFromDb.Mouvements is not null) {
                        decimal montantPaye = 0;
                        foreach(var mouvement in echeanceFromDb.Mouvements) {
                            montantPaye += mouvement.Montant;
                        }
                        if(montantPaye < (echeanceFromDb.Capital + echeanceFromDb.Interet)) {
                            var echeanceDto = mapper.Map<EcheanceCreditDto>(echeanceFromDb);
                            echeanceDto.MontantPaye = montantPaye;
                            echeancierDto.Add(echeanceDto);
                        } 
                    } 
                }
            }
            
            return Ok(echeancierDto);
        }

        [HttpPost("rembourserEcheances")] 
        [AllowAnonymous]
        public async Task<IActionResult> RembourserEcheances(InfosRemboursementsDto infos)
        {
            foreach(var echeanceDto in infos.Echeancier) {
                var echeance = await uow.EcheanceCreditRepository.FindByIdAsync(echeanceDto.Id);
                if(echeance is null) {
                    return NotFound("Cette échéances n'existe pas");
                }

                var credit = await uow.CreditRepository.FindByIdAsync(echeance.CreditId);
                if(credit is null) {
                    return NotFound("Ce crédit n'existe pas dans la base de données");
                }

                var membre = await uow.MembreRepository.FindByIdAsync(credit.MembreId);
                if(membre is null) {
                    return NotFound("Ce membre n'existe pas dans la base de données");
                }

                if(echeance.Mouvements is not null) { 
                    decimal solde = echeance.Capital + echeance.Interet;
                    foreach(var mvt in echeance.Mouvements) {
                        solde -= mvt.Montant;
                    }                   
                    
                    if(solde == (echeance.Capital + echeance.Interet)) {
                        // MOUVEMENT DE REMBOURSEMENT CREDIT
                        var mouvement = new Mouvement();
                        mouvement.DateMvt = echeance.DateEcheance;
                        if(infos.DateMouvement != "") {
                            mouvement.DateMvt = infos.DateMouvement;
                        }
                        mouvement.TypeOperation = TypeOperation.Credit;
                        mouvement.GabaritId = 1;
                        mouvement.Libelle = "Remboursement écheance credit N° " + echeance.CreditId + " du " + echeance.DateEcheance;
                        if (echeance.Capital != 0 && echeance.Interet != 0){
                            mouvement.Montant = echeance.Capital + echeance.Interet;
                        }
                        mouvement.ModifiePar = GetUserId();
                        mouvement.ModifieLe = DateTime.Now;
                        mouvement.EcheanceCredit = echeance;
                        uow.MouvementRepository.Add(mouvement);
                        await uow.SaveAsync();

                        // MOUVEMENT DE PRELEVEMENT DE L'INTERET
                        mouvement = new Mouvement();
                        mouvement.Credit = credit;
                        mouvement.DateMvt = echeance.DateEcheance;
                        if(infos.DateMouvement != "") {
                            mouvement.DateMvt = infos.DateMouvement;
                        }
                        mouvement.TypeOperation = TypeOperation.Debit;
                        mouvement.GabaritId = 1;
                        mouvement.Libelle = "Prélèvement de l'intérêt sur l'échéance de credit N° " + credit.Id + " du " + echeance.DateEcheance;
                        if (echeance.Interet != 0){
                            mouvement.Montant = echeance.Interet;
                        }
                        mouvement.ModifiePar = GetUserId();
                        mouvement.ModifieLe = DateTime.Now;
                        uow.MouvementRepository.Add(mouvement);
                        await uow.SaveAsync();
                    }
                }

            }

            return Ok();
        }


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

            return Ok(mapper.Map<CreditDto>(credit));
        }

        [HttpPost("deboursercredit/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DebourserCredit(int id, CreditDebourseDto creditDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var credit = await uow.CreditRepository.FindByIdAsync(id);
            if(credit is null) {
                return NotFound("Cet credit n'existe pas dans la base de données");
            }

            var membre = await uow.MembreRepository.FindByIdAsync(credit.MembreId);
            if(membre is null) {
                return NotFound("Ce membre n'existe pas dans la base de données");
            }

            // MOUVEMENT DE DEBOURSEMENT
            var mouvement = new Mouvement();
            mouvement.DateMvt = creditDto.DateDecaissement;
            mouvement.TypeOperation = TypeOperation.Debit;
            mouvement.GabaritId = 1;
            mouvement.Libelle = "Déboursement credit N° " + id + " du " + credit.DateDemande;
            if (creditDto.MontantAccorde != 0){
                mouvement.Montant = creditDto.MontantAccorde;
            }
            mouvement.ModifiePar = GetUserId();
            mouvement.ModifieLe = DateTime.Now;
            uow.MouvementRepository.Add(mouvement);
            await uow.SaveAsync();

            var creditDebourse = mapper.Map<CreditDebourse>(creditDto);
            creditDebourse.Credit = credit;
            creditDebourse.Mouvement = mouvement;
            creditDebourse.ModifiePar = GetUserId();
            creditDebourse.ModifieLe = DateTime.Now;
            uow.CreditDebourseRepository.Add(creditDebourse);
            await uow.SaveAsync();

            // MOUVEMENT DE PRELEVEMENT DE LA COMMISSION
            mouvement = new Mouvement();
            mouvement.Credit = credit;
            mouvement.DateMvt = creditDto.DateDecaissement;
            mouvement.TypeOperation = TypeOperation.Debit;
            mouvement.GabaritId = 1;
            mouvement.Libelle = "Prélèvement de la commission sur credit N° " + id + " du " + credit.DateDemande;
            if (creditDto.MontantCommission != 0){
                mouvement.Montant = creditDto.MontantCommission;
            }
            mouvement.ModifiePar = GetUserId();
            mouvement.ModifieLe = DateTime.Now;
            uow.MouvementRepository.Add(mouvement);
            await uow.SaveAsync();

            return Ok(mapper.Map<CreditDebourseDto>(creditDebourse));
        }

        [HttpPut("update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(int id, CreditDebourseDto creditDebourseDto)
        {

            var credit = await uow.CreditRepository.FindByIdAsync(id);
            
            if(credit is null) 
                return NotFound();

            var creditDebourse = mapper.Map<CreditDebourse>(creditDebourseDto);
            creditDebourse.ModifiePar = GetUserId();
            creditDebourse.ModifieLe = DateTime.Now;

            // Enregistrement du mouvement de déboursement dans le conte du membre
            var mouvement = new Mouvement();
            mouvement.DateMvt = creditDebourse.DateDecaissement;
            mouvement.TypeOperation = TypeOperation.Debit;
            mouvement.GabaritId = 1;
            mouvement.Libelle = "Décaissement credit N°" + creditDebourse.CreditId;
            if (
                creditDebourse.MontantAccorde != 0 
                && creditDebourse.MontantCommission != 0
                && creditDebourse.MontantInteret != 0 
            ){
                mouvement.Montant = creditDebourse.MontantAccorde 
                + creditDebourse.MontantCommission 
                + creditDebourse.MontantInteret;
            }
            mouvement.ModifiePar = GetUserId();
            mouvement.ModifieLe = DateTime.Now;
            creditDebourse.Mouvement = mouvement;

            

            credit.CreditDebourse = creditDebourse;

            await uow.SaveAsync();

            return Ok(credit);
        }

        [HttpPost("addecheancier/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> AddEcheancier(int id, EcheanceCreditDto[] echeanceCreditsDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var credit = await uow.CreditRepository.FindByIdAsync(id);
            if(credit is null) {
                return NotFound("Cet credit n'existe pas dans la base de données");
            }

            var echeancier = new List<EcheanceCredit>();

            foreach(var echeanceDto in echeanceCreditsDto) {
                var echeance = mapper.Map<EcheanceCredit>(echeanceDto);
                if(echeanceDto.Id == 0) {
                    echeance.ModifiePar = GetUserId();
                    echeance.ModifieLe = DateTime.Now;
                    credit.Echeancier.Add(echeance);
                    await uow.SaveAsync();
                }
                echeancier.Add(echeance);
            }

            var echeancierDto = mapper.Map<List<EcheanceCreditDto>>(echeancier);
            
            return Ok(echeancierDto);
        }
    }
}