import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Cotisation } from 'src/app/model/cotisation';
import { InfosCotisation } from 'src/app/model/infosCotisation';
import { InfosMembre } from 'src/app/model/infosMembre';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { Mois } from 'src/app/model/mois';
import { Mouvement } from 'src/app/model/mouvement';
import { MvtCompte } from 'src/app/model/mvtCompte';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { TypeOperation } from 'src/app/model/typeoperation';
import { CotisationService } from 'src/app/services/cotisation.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-nouvelle-cotisation',
  templateUrl: './nouvelle-cotisation.component.html',
  styleUrls: ['./nouvelle-cotisation.component.scss'],
})
export class NouvelleCotisationComponent implements OnInit {
  membre: MembreList = new MembreList();
  cotisation: Cotisation = new Cotisation();
  idMembre: number = 0;
  mois: Mois[] = [];
  annees: number[] = [2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030];
  cotisations: Cotisation[] = [];

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private cotisationService: CotisationService,
    private membreService: MembreService
  ) {}

  ngOnInit(): void {
    this.idMembre = this.activatedRoute.snapshot.params['id'];
    this.cotisationService.getAllMois().subscribe((mois: Mois[]) => {
      this.mois = mois;
    });

    if (this.idMembre) {
      this.membreService
        .getInfosMembre(this.idMembre)
        .subscribe((membre: MembreList) => {
          this.membre = membre;
          this.cotisationService
            .getAllCotisationsById(this.membre.id)
            .subscribe((cotisations: Cotisation[]) => {
              this.cotisations = cotisations;
            });
        });
    }
  }

  enregistrer(): void {
    this.cotisationService.addCotisations(this.cotisations).subscribe(() => {
      this.cancel();
    });
  }

  soldeCompte(): number {
    let solde = 0;
    this.cotisations.map((c) => {
      if (c.montant) solde += c.montant;
    });
    return solde;
  }

  checkInfosCotisation(): boolean {
    if (
      !this.cotisation.moisId ||
      !this.cotisation.annee ||
      !this.cotisation.montant
    ) {
      return false;
    }

    return true;
  }

  cancel(): void {
    this.router.navigate(['/cotisations']);
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

  resetForm(): void {
    this.cotisation = new Cotisation();
  }

  ajouterCotisation(): void {
    if (this.checkInfosCotisation()) {
      this.cotisation.membreId = this.idMembre;
      this.cotisations.push(this.cotisation);
      this.resetForm();
    }
  }
}
