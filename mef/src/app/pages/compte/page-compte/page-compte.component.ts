import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MvtCompte } from 'src/app/model/mvtCompte';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { TypeOperation } from 'src/app/model/typeoperation';
import { CompteService } from 'src/app/services/compte.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-page-compte',
  templateUrl: './page-compte.component.html',
  styleUrls: ['./page-compte.component.scss'],
})
export class PageCompteComponent implements OnInit {
  membres: Membre[] = [];
  sexes: Sexe[] = [];
  postes: Poste[] = [];
  lieuAffectations: LieuAffectation[] = [];
  mvtComptes: MvtCompte[] = [];

  constructor(
    private compteService: CompteService,
    private sexeService: SexeService,
    private posteService: PosteService,
    private lieuAffectationService: LieuAffectationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.sexeService.getAll().subscribe((sexes: Sexe[]) => {
      this.sexes = sexes;
      this.posteService.getAll().subscribe((postes: Poste[]) => {
        this.postes = postes;
        this.lieuAffectationService
          .getAll()
          .subscribe((lieuAffectations: LieuAffectation[]) => {
            this.lieuAffectations = lieuAffectations;
            this.compteService
              .getAllMvts()
              .subscribe((mvtComptes: MvtCompte[]) => {
                this.mvtComptes = mvtComptes;
                this.compteService
                  .getAllMembres()
                  .subscribe((membres: Membre[]) => {
                    this.membres = membres;
                  });
              });
          });
      });
    });
  }

  nouveauCompte(): void {
    this.router.navigate(['/nouveaucompte']);
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

  getSolde(id?: number): number | undefined {
    let solde = 0;
    this.mvtComptes
      .filter(({ membreId }) => membreId == id)
      .forEach((m) => {
        if (m.typeOperation == TypeOperation.Credit) {
          solde += m.montant ?? 0;
        } else {
          solde -= m.montant ?? 0;
        }
      });

    return solde;
  }
}
