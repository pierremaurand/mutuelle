import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Credit } from 'src/app/model/credit';
import { EcheanceCredit } from 'src/app/model/echeanceCredit';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { Mois } from 'src/app/model/mois';
import { MvtCompte } from 'src/app/model/mvtCompte';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { TypeOperation } from 'src/app/model/typeoperation';
import { CotisationService } from 'src/app/services/cotisation.service';
import { CreditService } from 'src/app/services/credit.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-nouveau-credit',
  templateUrl: './nouveau-credit.component.html',
  styleUrls: ['./nouveau-credit.component.scss'],
})
export class NouveauCreditComponent implements OnInit {
  membres: MembreList[] = [];
  membre: MembreList = new MembreList();
  credit: Credit = new Credit();
  creditId?: number;
  photo: string = '';
  sexes: Sexe[] = [];
  sexe?: Sexe;
  postes: Poste[] = [];
  poste?: Poste;
  lieuAffectations: LieuAffectation[] = [];
  lieuAffectation?: LieuAffectation;
  echeancier: EcheanceCredit[] = [];
  mois: Mois[] = [];
  mvtComptes: MvtCompte[] = [];
  mvtDate?: string;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private creditService: CreditService,
    private sexeService: SexeService,
    private posteService: PosteService,
    private lieuAffectationService: LieuAffectationService,
    private cotisationService: CotisationService
  ) {}

  ngOnInit(): void {
    this.photo = this.creditService.getPhotoUrl();
    this.cotisationService.getAllMois().subscribe((mois: Mois[]) => {
      this.mois = mois;
      this.creditService.getAllMembres().subscribe((membres: Membre[]) => {
        // this.membres = membres;
        this.sexeService.getAll().subscribe((sexes: Sexe[]) => {
          this.sexes = sexes;
          this.posteService.getAll().subscribe((postes: Poste[]) => {
            this.postes = postes;
            this.lieuAffectationService
              .getAll()
              .subscribe((lieuAffectations: LieuAffectation[]) => {
                this.lieuAffectations = lieuAffectations;
                this.creditId = this.activatedRoute.snapshot.params['id'];
                if (this.creditId) {
                  this.creditService
                    .getById(this.creditId)
                    .subscribe((credit: Credit) => {
                      this.credit = credit;
                      this.changeMembre();
                    });
                  this.creditService
                    .getAllEcheancesCredit(this.creditId)
                    .subscribe((echeancier: EcheanceCredit[]) => {
                      this.echeancier = echeancier;
                    });
                }
              });
          });
        });
      });
    });
  }

  enregistrer(): void {
    if (!this.credit.id) {
      if (this.checkInfosCredit()) {
        this.creditService.add(this.credit).subscribe((value: any) => {
          this.cancel();
        });
      }
    } else {
      this.creditService
        .update(this.creditId, this.credit)
        .subscribe((value: any) => {
          this.creditService
            .addEcheances(this.echeancier)
            .subscribe((value: any) => {
              this.creditService
                .addMvtComptes(this.mvtComptes)
                .subscribe((value: any) => {
                  this.cancel();
                });
            });
        });
    }
  }

  soldeCredit(): number | undefined {
    let solde = 0;
    solde += this.credit.montantCapital ?? 0;
    solde += this.credit.montantInteret ?? 0;
    this.echeancier
      .filter(({ estPaye }) => estPaye)
      .forEach((e) => {
        solde -= e.montantCapital ?? 0;
        solde -= e.montantInteret ?? 0;
      });
    return solde;
  }

  checkInfosCredit(): boolean {
    if (
      !this.credit.dateEnregistrement ||
      !this.credit.membreId ||
      !this.credit.montantCapital
    ) {
      return false;
    }

    return true;
  }

  cancel(): void {
    this.router.navigate(['/credits']);
  }

  changeMembre(): void {
    // this.membre = this.membres.find(({ id }) => id == this.credit.membreId);
    if (this.membre) {
      this.photo = this.creditService.getPhotoUrl(this.membre.photo);
      // this.sexe = this.sexes.find(({ id }) => id == this.membre?.sexeId);
      // this.poste = this.postes.find(({ id }) => id == this.membre?.posteId);
      // this.lieuAffectation = this.lieuAffectations.find(
      //   ({ id }) => id == this.membre?.lieuAffectationId
      // );
    }
  }

  genererEcheancier(): void {
    if (
      this.credit.dateDeblocage &&
      this.credit.nombreEcheances &&
      this.credit.nombreEcheances > 0 &&
      this.credit.montantCapital
    ) {
      let dateDebut = new Date();
      let curDate = new Date();
      let nbrEcheances = this.credit.nombreEcheances;
      let montantEcheanceCapital = Math.round(
        this.credit.montantCapital / nbrEcheances
      );
      let montantEcheanceInteret = 0;
      if (this.credit.montantInteret) {
        montantEcheanceInteret = Math.round(
          this.credit.montantInteret / nbrEcheances
        );
      }

      let resteCapital =
        this.credit.montantCapital - montantEcheanceCapital * nbrEcheances;
      let resteInteret = 0;
      if (this.credit.montantInteret) {
        resteInteret =
          this.credit.montantInteret - montantEcheanceInteret * nbrEcheances;
      }

      if (this.credit.dateEnregistrement) {
        dateDebut = new Date(this.credit.dateEnregistrement);
      }

      if (this.credit.dateDeblocage) {
        dateDebut = new Date(this.credit.dateDeblocage);
      }

      curDate = dateDebut;

      for (let i = 1; i <= nbrEcheances; i++) {
        if (curDate.getMonth() == 11) {
          curDate.setFullYear(curDate.getFullYear() + 1);
          curDate.setMonth(0);
        } else {
          curDate.setMonth(curDate.getMonth() + 1);
        }
        let echeance: EcheanceCredit = {
          id: 0,
          creditId: this.creditId,
          moisId: curDate.getMonth() + 1,
          annee: curDate.getFullYear(),
          montantCapital: montantEcheanceCapital,
          montantInteret: montantEcheanceInteret,
          estPaye: false,
        };

        if (i === 1) {
          echeance.montantCapital = montantEcheanceCapital + resteCapital;
          echeance.montantInteret = montantEcheanceInteret + resteInteret;
        }
        this.echeancier.push(echeance);
      }
      // MOUVEMENT DE DECAISSEMENT CREDIT
      let mvtCompte: MvtCompte = {
        id: 0,
        dateMvt: this.credit.dateDeblocage,
        typeOperation: TypeOperation.Debit,
        gabaritId: 1,
        libelle: 'Décaissement credit ',
        montant: this.credit.montantCapital,
        creditId: this.credit.id,
        membreId: this.credit.membreId,
      };
      this.mvtComptes.push(mvtCompte);
      // MOUVEMENT DE PRELEVEMENT DES INTERET DU CREDIT
      mvtCompte = {
        id: 0,
        dateMvt: this.credit.dateDeblocage,
        typeOperation: TypeOperation.Debit,
        gabaritId: 1,
        libelle: 'Interêts credit ',
        montant: this.credit.montantInteret,
        creditId: this.credit.id,
        membreId: this.credit.membreId,
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
          'Paiement échance capital credit du ' +
          this.getMoisNum(this.echeancier[i].moisId) +
          '/' +
          this.echeancier[i].annee,
        montant: this.echeancier[i].montantCapital,
        echeanceCreditId: this.echeancier[i].id,
        membreId: this.credit.membreId,
      };
      this.mvtComptes.push(mvtCompte);
      // MOUVEMENT DE PAIEMENT ECHEANCE
      mvtCompte = {
        id: 0,
        dateMvt: this.mvtDate,
        typeOperation: TypeOperation.Credit,
        gabaritId: 1,
        libelle:
          'Paiement échance interêts credit du ' +
          this.getMoisNum(this.echeancier[i].moisId) +
          '/' +
          this.echeancier[i].annee,
        montant: this.echeancier[i].montantInteret,
        echeanceCreditId: this.echeancier[i].id,
        membreId: this.credit.membreId,
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

  calculInteret(): void {
    if (this.credit.montantCapital) {
      this.credit.montantInteret = Math.round(this.credit.montantCapital / 100);
    }
  }
}
