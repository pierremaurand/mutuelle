import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { HeaderState } from 'src/app/model/header';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MvtCompte } from 'src/app/model/mvtCompte';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { TypeOperation } from 'src/app/model/typeoperation';
import { CompteService } from 'src/app/services/compte.service';
import { HeaderService } from 'src/app/services/header.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-page-compte',
  templateUrl: './page-compte.component.html',
  styleUrls: ['./page-compte.component.scss'],
})
export class PageCompteComponent implements OnInit {
  [x: string]: any;
  membres: Membre[] = [];
  sexes: Sexe[] = [];
  postes: Poste[] = [];
  lieuAffectations: LieuAffectation[] = [];
  mvtComptes: MvtCompte[] = [];
  search: string = '';
  subscription!: Subscription;

  constructor(
    private compteService: CompteService,
    private sexeService: SexeService,
    private posteService: PosteService,
    private lieuAffectationService: LieuAffectationService,
    private membreService: MembreService,
    private headerService: HeaderService,
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

    this.subscription = this.headerService.headerState.subscribe(
      (state: HeaderState) => {
        this.search = state.search;
      }
    );

    this.search = localStorage.getItem('search') ?? '';
  }

  nouveauCompte(): void {
    this.router.navigate(['/nouveaucompte']);
  }

  modifier(id: number): void {
    this.router.navigate(['nouveaucompte', id]);
  }

  getSexe(sexeId?: number): string {
    return this.sexes.find(({ id }) => id === sexeId)?.nom ?? '';
  }

  getPoste(posteId?: number): string {
    return this.postes.find(({ id }) => id === posteId)?.libelle ?? '';
  }

  getLieuAffectation(lieuId?: number): string {
    return this.lieuAffectations.find(({ id }) => id === lieuId)?.lieu ?? '';
  }

  getPhoto(photo?: string): string {
    return this.membreService.getPhotoUrl(photo);
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
