import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Credit } from 'src/app/model/credit';
import { EcheanceCredit } from 'src/app/model/echeanceCredit';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { CreditService } from 'src/app/services/credit.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-page-credit',
  templateUrl: './page-credit.component.html',
  styleUrls: ['./page-credit.component.scss'],
})
export class PageCreditComponent implements OnInit {
  credits: Credit[] = [];
  membres: Membre[] = [];
  sexes: Sexe[] = [];
  postes: Poste[] = [];
  lieuAffectations: LieuAffectation[] = [];
  echeances: EcheanceCredit[] = [];

  constructor(
    private creditService: CreditService,
    private membreService: MembreService,
    private sexeService: SexeService,
    private posteService: PosteService,
    private lieuAffectationService: LieuAffectationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.creditService
      .getAllEcheances()
      .subscribe((echeances: EcheanceCredit[]) => {
        this.echeances = echeances;
        this.membreService.getAll().subscribe((membres: Membre[]) => {
          this.membres = membres;
          this.creditService.getAll().subscribe((credits: Credit[]) => {
            this.credits = credits;
            this.sexeService.getAll().subscribe((sexes: Sexe[]) => {
              this.sexes = sexes;
              this.posteService.getAll().subscribe((postes: Poste[]) => {
                this.postes = postes;
                this.lieuAffectationService
                  .getAll()
                  .subscribe((lieuAffectations: LieuAffectation[]) => {
                    this.lieuAffectations = lieuAffectations;
                    this.creditService
                      .getAll()
                      .subscribe((credits: Credit[]) => {
                        this.credits = credits;
                      });
                  });
              });
            });
          });
        });
      });
  }

  nouveauCredit(): void {
    this.router.navigate(['/nouveaucredit']);
  }

  getMembre(membreId?: number): Membre | undefined {
    return this.membres.find(({ id }) => id === membreId);
  }

  getSexe(sexeId?: number): Sexe | undefined {
    return this.sexes.find(({ id }) => id === sexeId);
  }

  getPoste(posteId?: number): Poste | undefined {
    return this.postes.find(({ id }) => id === posteId);
  }

  getLieuAffectation(lieuId?: number): LieuAffectation | undefined {
    return this.lieuAffectations.find(({ id }) => id === lieuId);
  }

  getCredit(creditId?: number): Credit | undefined {
    return this.credits.find(({ id }) => id === creditId);
  }

  getSolde(id?: number): number | undefined {
    const credit = this.getCredit(id);
    let solde = 0;
    solde += credit?.montantCapital ?? 0;
    solde += credit?.montantInteret ?? 0;
    this.echeances
      .filter(({ estPaye, creditId }) => estPaye && creditId == credit?.id)
      .forEach((e) => {
        solde -= e.montantCapital ?? 0;
        solde -= e.montantInteret ?? 0;
      });

    return solde;
  }
}
