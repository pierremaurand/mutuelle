import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Membre } from 'src/app/model/Membre';
import { Cotisation } from 'src/app/model/cotisation';
import { CotisationsMembre } from 'src/app/model/cotisationsMembre';
import { Mois } from 'src/app/model/mois';
import { CotisationService } from 'src/app/services/cotisation.service';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-nouvelle-cotisation',
  templateUrl: './nouvelle-cotisation.component.html',
  styleUrls: ['./nouvelle-cotisation.component.scss'],
})
export class NouvelleCotisationComponent implements OnInit {
  idMembre: number = 0;
  mois: Mois[] = [];
  annees: number[] = [2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030];
  cotisation: Cotisation = new Cotisation();
  cotisationsMembre: CotisationsMembre = new CotisationsMembre();

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private cotisationService: CotisationService
  ) {}

  ngOnInit(): void {
    this.idMembre = this.activatedRoute.snapshot.params['id'];
    this.cotisationService.getAllMois().subscribe((mois: Mois[]) => {
      this.mois = mois;
    });

    if (this.idMembre) {
      this.cotisationService
        .getCotisationsMembre(this.idMembre)
        .subscribe((cotisationsMembre: CotisationsMembre) => {
          this.cotisationsMembre = cotisationsMembre;
        });
    }
  }

  enregistrer(): void {
    if (this.cotisationsMembre.cotisations.length != 0) {
      this.cotisationService
        .addCotisations(
          this.cotisationsMembre.membre.id,
          this.cotisationsMembre.cotisations
        )
        .subscribe(() => {
          this.cancel();
        });
    }
  }

  soldeCompte(): number {
    let solde = 0;
    this.cotisationsMembre.cotisations.map((c) => {
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
      this.cotisationsMembre.cotisations.push(this.cotisation);
      this.resetForm();
    }
  }
}
