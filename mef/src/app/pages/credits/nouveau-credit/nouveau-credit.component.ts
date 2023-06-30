import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Credit } from 'src/app/model/credit';
import { CreditDebourse } from 'src/app/model/creditDebourse';
import { EcheanceCredit } from 'src/app/model/echeanceCredit';
import { InfosCredit } from 'src/app/model/infosCredit';
import { Membre } from 'src/app/model/Membre';
import { CreditService } from 'src/app/services/credit.service';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-nouveau-credit',
  templateUrl: './nouveau-credit.component.html',
  styleUrls: ['./nouveau-credit.component.scss'],
})
export class NouveauCreditComponent implements OnInit {
  membre: Membre = new Membre();
  credit: Credit = new Credit();
  creditDebourse: CreditDebourse = new CreditDebourse();
  echeancier: EcheanceCredit[] = [];
  idCredit: number = 0;
  nbrEcheances?: number = 0;
  solde: number = 0;
  status: string = 'Enregistré';

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private creditService: CreditService,
    private membreService: MembreService,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {
    this.idCredit = this.activatedRoute.snapshot.params['id'];
    if (this.idCredit) {
      this.creditService.getById(this.idCredit).subscribe((credit: Credit) => {
        this.credit = credit;
        this.membreService
          .getById(credit.membreId)
          .subscribe((membre: Membre) => {
            this.membre = membre;
            this.creditService
              .getDeboursement(this.credit.id)
              .subscribe((creditDebourse: CreditDebourse) => {
                this.creditDebourse = creditDebourse;
                this.creditService
                  .getEcheancier(credit.id)
                  .subscribe((echeancier: EcheanceCredit[]) => {
                    this.echeancier = echeancier;
                    this.nbrEcheances = echeancier.length;
                    alert(this.nbrEcheances);
                    this.getSolde();
                  });
              });
          });
      });
    }
  }

  enregistrer(): void {
    if (this.credit.id == 0 && this.checkInfosCredit()) {
      this.creditService.add(this.credit).subscribe((credit: Credit) => {
        this.credit = credit;
        this.idCredit = credit.id;
      });
    }

    if (
      this.credit.id !== 0 &&
      this.creditDebourse.id == 0 &&
      this.checkInfosDebourse()
    ) {
      this.creditService
        .debourserCredit(this.credit.id, this.creditDebourse)
        .subscribe((creditDebourse: CreditDebourse) => {
          this.creditDebourse = creditDebourse;
          this.getSolde();
        });
    }

    if (
      this.credit.id !== 0 &&
      this.creditDebourse.id !== 0 &&
      this.checkEcheancier()
    ) {
      this.creditService
        .addEcheancier(this.credit.id, this.echeancier)
        .subscribe((echeancier: EcheanceCredit[]) => {
          this.echeancier = echeancier;
          this.getSolde();
        });
    }
  }

  checkInfosCredit(): boolean {
    if (
      this.credit.dateDemande == '' ||
      this.credit.membreId == 0 ||
      this.credit.montantSollicite == 0 ||
      this.credit.dureeSollicite == 0
    ) {
      return false;
    }

    return true;
  }

  checkEcheancier(): boolean {
    let test = true;
    if (this.echeancier.length == 0) {
      test = false;
    } else {
      this.echeancier.forEach((e) => {
        if (e.id == 0) {
          test = true;
        }
      });
    }

    return test;
  }

  checkInfosDebourse(): boolean {
    if (
      this.creditDebourse.dateDecaissement == '' ||
      this.creditDebourse.montantAccorde == 0 ||
      this.creditDebourse.dureeAccordee == 0
    ) {
      return false;
    }

    return true;
  }

  cancel(): void {
    this.router.navigate(['/credits']);
  }

  genererEcheancier(): void {
    let dateDebut = new Date();
    let curDate = new Date();
    let capital: number | undefined = 0;
    let interet: number | undefined = 0;
    let montantCapital: number | undefined = 0;
    let montantInteret: number | undefined = 0;
    let nbrEcheances: number | undefined = 0;
    let resteCapital: number | undefined = 0;
    let resteInteret: number | undefined = 0;

    if (this.checkInfosCredit() || this.checkInfosDebourse()) {
      dateDebut = new Date(
        this.creditDebourse.dateDecaissement ?? this.credit.dateDemande
      );
      nbrEcheances =
        this.creditDebourse.dureeAccordee ?? this.credit.dureeSollicite;
      montantCapital =
        this.creditDebourse.montantAccorde ?? this.credit.montantSollicite ?? 0;

      montantInteret = this.creditDebourse.montantInteret ?? 0;

      if (montantCapital && montantInteret && nbrEcheances) {
        capital = Math.round(montantCapital / nbrEcheances);
        resteCapital = montantCapital - capital * nbrEcheances;
        interet = Math.round(montantInteret / nbrEcheances);
        resteInteret = montantInteret - interet * nbrEcheances;
      }

      this.nbrEcheances = nbrEcheances;

      if (nbrEcheances && nbrEcheances <= 24 && nbrEcheances > 0) {
        this.echeancier = [];
        curDate = dateDebut;
        if (nbrEcheances) {
          for (let i = 1; i <= nbrEcheances; i++) {
            if (curDate.getMonth() == 11) {
              curDate.setFullYear(curDate.getFullYear() + 1);
              curDate.setMonth(0);
            } else {
              curDate.setMonth(curDate.getMonth() + 1);
            }
            let echeance: EcheanceCredit = new EcheanceCredit();
            echeance.dateEcheance = this.datePipe.transform(
              curDate,
              'yyyy-MM-dd'
            );
            echeance.capital = capital;
            echeance.interet = interet;
            if (i === 1) {
              echeance.capital = capital + resteCapital;
              echeance.interet = interet + resteInteret;
            }
            this.echeancier.push(echeance);
          }
        }
      }
    }
  }

  getSolde(): void {
    this.creditService
      .getInfosCredit(this.credit.id)
      .subscribe((infos: InfosCredit) => {
        this.solde = infos.solde;
        this.status = infos.status;
      });
  }

  membreChoisie(id: number) {
    this.credit.membreId = id;
    this.membreService.getById(id).subscribe((membre: Membre) => {
      this.membre = membre;
    });
  }

  calculInteret(): void {
    if (
      this.creditDebourse.montantAccorde &&
      this.creditDebourse.montantAccorde != 0 &&
      this.creditDebourse.dureeAccordee &&
      this.creditDebourse.dureeAccordee != 0
    ) {
      this.creditDebourse.montantInteret = Math.round(
        (this.creditDebourse.montantAccorde *
          2 *
          this.creditDebourse.dureeAccordee) /
          1200
      );

      this.creditDebourse.montantCommission = Math.round(
        this.creditDebourse.montantAccorde / 100
      );
      if (this.creditDebourse.montantCommission < 1000) {
        this.creditDebourse.montantCommission = 1000;
      }
    }
  }
}
