import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Avance } from 'src/app/model/avance';
import { AvanceDebourse } from 'src/app/model/avanceDebourse';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';
import { InfosAvance } from 'src/app/model/infosAvance';
import { Membre } from 'src/app/model/Membre';
import { AvanceService } from 'src/app/services/avance.service';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-nouvelle-avance',
  templateUrl: './nouvelle-avance.component.html',
  styleUrls: ['./nouvelle-avance.component.scss'],
})
export class NouvelleAvanceComponent implements OnInit {
  membre: Membre = new Membre();
  avance: Avance = new Avance();
  avanceDebourse: AvanceDebourse = new AvanceDebourse();
  echeancier: EcheanceAvance[] = [];
  idAvance: number = 0;
  nbrEcheances?: number = 0;
  solde: number = 0;
  status: string = 'Enregistré';

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private avanceService: AvanceService,
    private membreService: MembreService,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {
    this.idAvance = this.activatedRoute.snapshot.params['id'];
    if (this.idAvance) {
      this.avanceService.getById(this.idAvance).subscribe((avance: Avance) => {
        this.avance = avance;
        this.membreService
          .getById(avance.membreId)
          .subscribe((membre: Membre) => {
            this.membre = membre;
            this.avanceService
              .getDeboursement(this.avance.id)
              .subscribe((avanceDebourse: AvanceDebourse) => {
                this.avanceDebourse = avanceDebourse;
                this.avanceService
                  .getEcheancier(avance.id)
                  .subscribe((echeancier: EcheanceAvance[]) => {
                    this.echeancier = echeancier;
                    this.nbrEcheances = echeancier.length;
                    this.getSolde();
                  });
              });
          });
      });
    }
  }

  enregistrer(): void {
    if (this.avance.id == 0 && this.checkInfosAvance()) {
      this.avanceService.add(this.avance).subscribe((avance: Avance) => {
        this.avance = avance;
        this.idAvance = avance.id;
      });
    }

    if (
      this.avance.id !== 0 &&
      this.avanceDebourse.id == 0 &&
      this.checkInfosDebourse()
    ) {
      this.avanceService
        .debourserAvance(this.avance.id, this.avanceDebourse)
        .subscribe((avanceDebourse: AvanceDebourse) => {
          this.avanceDebourse = avanceDebourse;
          this.getSolde();
        });
    }

    if (
      this.avance.id !== 0 &&
      this.avanceDebourse.id !== 0 &&
      this.checkEcheancier()
    ) {
      this.avanceService
        .addEcheancier(this.avance.id, this.echeancier)
        .subscribe((echeancier: EcheanceAvance[]) => {
          this.echeancier = echeancier;
          this.getSolde();
        });
    }
  }

  checkInfosAvance(): boolean {
    if (
      this.avance.dateDemande == '' ||
      this.avance.membreId == 0 ||
      this.avance.montantSollicite == 0 ||
      this.avance.nombreEcheancesSollicite == 0
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
      this.avanceDebourse.dateDecaissement == '' ||
      this.avanceDebourse.montantApprouve == 0 ||
      this.avanceDebourse.nombreEcheancesApprouve == 0
    ) {
      return false;
    }

    return true;
  }

  cancel(): void {
    this.router.navigate(['/avances']);
  }

  genererEcheancier(): void {
    let dateDebut = new Date();
    let curDate = new Date();
    let montantEcheance: number | undefined = 0;
    let montant: number | undefined = 0;
    let nbrEcheances: number | undefined = 0;
    let reste: number | undefined = 0;

    if (this.checkInfosAvance() || this.checkInfosDebourse()) {
      dateDebut = new Date(
        this.avanceDebourse.dateDecaissement ?? this.avance.dateDemande
      );
      nbrEcheances =
        this.avanceDebourse.nombreEcheancesApprouve ??
        this.avance.nombreEcheancesSollicite;
      montant =
        this.avanceDebourse.montantApprouve ?? this.avance.montantSollicite;
      if (montant && nbrEcheances) {
        montantEcheance = Math.round(montant / nbrEcheances);
        reste = montant - montantEcheance * nbrEcheances;
      }

      this.nbrEcheances = nbrEcheances;

      if (nbrEcheances && nbrEcheances <= 9 && nbrEcheances > 0) {
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
            let echeance: EcheanceAvance = new EcheanceAvance();
            echeance.dateEcheance = this.datePipe.transform(
              curDate,
              'yyyy-MM-dd'
            );
            echeance.montantEcheance = montantEcheance;
            if (i === 1) {
              echeance.montantEcheance = montantEcheance + reste;
            }
            this.echeancier.push(echeance);
          }
        }
      }
    }
  }

  getSolde(): void {
    this.avanceService
      .getInfosAvance(this.avance.id)
      .subscribe((infos: InfosAvance) => {
        this.solde = infos.solde;
        this.status = infos.status;
      });
  }

  membreChoisie(id: number) {
    this.avance.membreId = id;
    this.membreService.getById(id).subscribe((membre: Membre) => {
      this.membre = membre;
    });
  }
}
