import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Avance } from 'src/app/model/avance';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { Mois } from 'src/app/model/mois';
import { MvtCompte } from 'src/app/model/mvtCompte';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { TypeOperation } from 'src/app/model/typeoperation';
import { AvanceService } from 'src/app/services/avance.service';
import { CotisationService } from 'src/app/services/cotisation.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-nouvelle-avance',
  templateUrl: './nouvelle-avance.component.html',
  styleUrls: ['./nouvelle-avance.component.scss'],
})
export class NouvelleAvanceComponent implements OnInit {
  membres: MembreList[] = [];
  membre: MembreList = new MembreList();
  avance: Avance = new Avance();
  avanceId: number = 0;
  echeancier: EcheanceAvance[] = [];
  mois: Mois[] = [];
  mvtComptes: MvtCompte[] = [];
  mvtDate?: string;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private avanceService: AvanceService,
    private cotisationService: CotisationService
  ) {}

  ngOnInit(): void {
    this.cotisationService.getAllMois().subscribe((mois: Mois[]) => {
      this.mois = mois;
      this.avanceId = this.activatedRoute.snapshot.params['id'];
      this.avanceService
        .getAllEcheancesAvance(this.avanceId)
        .subscribe((echeancier: EcheanceAvance[]) => {
          this.echeancier = echeancier;
        });
      if (this.avanceId) {
        this.avanceService
          .getById(this.avanceId)
          .subscribe((avance: Avance) => {
            this.avance = avance;
            this.changeMembre();
          });
      }
    });
  }

  enregistrer(): void {
    if (!this.avance.id) {
      if (this.checkInfosAvance()) {
        this.avanceService.add(this.avance).subscribe((value: any) => {
          this.cancel();
        });
      }
    } else {
      this.avanceService
        .update(this.avanceId, this.avance)
        .subscribe((value: any) => {
          this.avanceService
            .addEcheances(this.echeancier)
            .subscribe((value: any) => {
              this.avanceService
                .addMvtComptes(this.mvtComptes)
                .subscribe((value: any) => {
                  this.cancel();
                });
            });
        });
    }
  }

  soldeAvance(): number | undefined {
    let solde = this.avance.montant;
    this.echeancier
      .filter(({ estPaye }) => estPaye)
      .forEach((e) => {
        if (solde) solde -= e.montant ?? 0;
      });
    return solde;
  }

  checkInfosAvance(): boolean {
    if (
      !this.avance.dateEnregistrement ||
      !this.avance.membreId ||
      !this.avance.montant
    ) {
      return false;
    }

    return true;
  }

  cancel(): void {
    this.router.navigate(['/avances']);
  }

  changeMembre(): void {
    // this.membre = this.membres.find(({ id }) => id == this.avance.membreId);
    // if (this.membre) {
    //   this.photo = this.avanceService.getPhotoUrl(this.membre.photo);
    //   this.sexe = this.sexes.find(({ id }) => id == this.membre?.sexeId);
    //   this.poste = this.postes.find(({ id }) => id == this.membre?.posteId);
    //   this.lieuAffectation = this.lieuAffectations.find(
    //     ({ id }) => id == this.membre?.lieuAffectationId
    //   );
    // }
  }

  genererEcheancier(): void {
    if (
      this.avance.dateDeblocage &&
      this.avance.nombreEcheances &&
      this.avance.nombreEcheances > 0 &&
      this.avance.montant
    ) {
      let dateDebut = new Date();
      let curDate = new Date();
      let nbrEcheances = this.avance.nombreEcheances;
      let montantEcheance = Math.round(this.avance.montant / nbrEcheances);
      let reste = this.avance.montant - montantEcheance * nbrEcheances;

      if (this.avance.dateEnregistrement) {
        dateDebut = new Date(this.avance.dateEnregistrement);
      }

      if (this.avance.dateDeblocage) {
        dateDebut = new Date(this.avance.dateDeblocage);
      }

      curDate = dateDebut;

      for (let i = 1; i <= nbrEcheances; i++) {
        if (curDate.getMonth() == 11) {
          curDate.setFullYear(curDate.getFullYear() + 1);
          curDate.setMonth(0);
        } else {
          curDate.setMonth(curDate.getMonth() + 1);
        }
        let echeance: EcheanceAvance = {
          id: 0,
          avanceId: this.avanceId,
          moisId: curDate.getMonth() + 1,
          annee: curDate.getFullYear(),
          montant: montantEcheance,
          estPaye: false,
        };

        if (i === 1) {
          echeance.montant = montantEcheance + reste;
        }
        this.echeancier.push(echeance);
      }
      // MOUVEMENT DE DECAISSEMENT AVANCE
      let mvtCompte: MvtCompte = {
        id: 0,
        dateMvt: this.avance.dateDeblocage,
        typeOperation: TypeOperation.Debit,
        gabaritId: 1,
        libelle: 'Décaissement avance ',
        montant: this.avance.montant,
        avanceId: this.avance.id,
        membreId: this.avance.membreId,
      };
      this.mvtComptes.push(mvtCompte);
    }
  }

  payCheck(i: number): void {
    if (this.mvtDate) {
      this.echeancier[i].estPaye = true;
      // MOUVEMENT DE PAIEMENT ECHEANCE
      let mvtCompte: MvtCompte = {
        id: 0,
        dateMvt: this.mvtDate,
        typeOperation: TypeOperation.Credit,
        gabaritId: 1,
        libelle:
          'Paiement échance avance du ' +
          this.getMoisNum(this.echeancier[i].moisId) +
          '/' +
          this.echeancier[i].annee,
        montant: this.echeancier[i].montant,
        echeanceAvanceId: this.echeancier[i].id,
        membreId: this.avance.membreId,
      };
      this.mvtComptes.push(mvtCompte);
    }
  }

  getMoisNum(moisId?: number): string | undefined {
    let index: number = 0;
    if (moisId) {
      index = moisId - 1;
    }
    return this.mois[index].valeur;
  }

  getMois(moisId?: number): string | undefined {
    let index: number = 0;
    if (moisId) {
      index = moisId - 1;
    }
    return this.mois[index].libelle;
  }

  checkEcheancier(): boolean {
    const echeances = this.echeancier.filter(
      ({ id, estPaye }) => id != 0 && estPaye == true
    );
    if (echeances.length != this.echeancier.length) {
      return true;
    }
    return false;
  }
}
