import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cotisation } from 'src/app/model/cotisation';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { CotisationService } from 'src/app/services/cotisation.service';
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

  constructor(
    private cotisationService: CotisationService,
    private membreService: MembreService,
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
  }

  nouveau(): void {
    this.router.navigate(['/nouvellecotisation']);
  }

  navigate(id: number): void {
    this.router.navigate(['/nouvellecotisation/' + id]);
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

  getSolde(id?: number): number {
    let solde = 0;
    this.cotisations
      .filter(({ membreId }) => membreId == id)
      .forEach((c) => {
        solde += c.montant ?? 0;
      });

    return solde;
  }
}
