import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Cotisation } from 'src/app/model/cotisation';
import { HeaderState } from 'src/app/model/header';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { CotisationService } from 'src/app/services/cotisation.service';
import { HeaderService } from 'src/app/services/header.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-page-cotisation',
  templateUrl: './page-cotisation.component.html',
  styleUrls: ['./page-cotisation.component.scss'],
})
export class PageCotisationComponent implements OnInit {
  membres: Membre[] = [];
  sexes: Sexe[] = [];
  postes: Poste[] = [];
  lieuAffectations: LieuAffectation[] = [];
  cotisations: Cotisation[] = [];
  search: string = '';
  subscription!: Subscription;

  constructor(
    private cotisationService: CotisationService,
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
            this.cotisationService
              .getAllCotisations()
              .subscribe((cotisations: Cotisation[]) => {
                this.cotisations = cotisations;
                this.cotisationService
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

  nouvelleCotisation(): void {
    this.router.navigate(['/nouvellecotisation']);
  }

  modifier(id: number): void {
    this.router.navigate(['nouvellecotisation', id]);
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
    this.cotisations
      .filter(({ membreId }) => membreId == id)
      .forEach((c) => {
        solde += c.montant ?? 0;
      });

    return solde;
  }
}
