import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Cotisation } from 'src/app/model/cotisation';
import { InfosCotisation } from 'src/app/model/infosCotisation';
import { InfosMembre } from 'src/app/model/infosMembre';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { Mois } from 'src/app/model/mois';
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
  mvtCompte: MvtCompte = new MvtCompte();
  sexe: Sexe = new Sexe();
  poste: Poste = new Poste();
  lieuAffectation: LieuAffectation = new LieuAffectation();
  membreId?: number;
  photo: string = '';
  SortbyParam = 'annee';
  SortDirection = 'desc';
  mois: Mois[] = [];
  annees: number[] = [2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030];
  cotisations: Cotisation[] = [];

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private cotisationService: CotisationService,
    private sexeService: SexeService,
    private posteService: PosteService,
    private lieuAffectationService: LieuAffectationService,
    private membreService: MembreService
  ) {}

  ngOnInit(): void {
    this.cotisationService.getAllMois().subscribe((mois: Mois[]) => {
      this.mois = mois;
      this.membreId = this.activatedRoute.snapshot.params['id'];
      this.cotisationService
        .getAllCotisationsById(this.membreId)
        .subscribe((cotisations: Cotisation[]) => {
          this.cotisations = cotisations;
          this.membreService
            .getById(this.membreId)
            .subscribe((membre: Membre) => {
              // this.membre = membre;
              this.photo = this.membreService.getPhotoUrl(this.membre.photo);
              this.sexeService
                .getById(membre.sexeId)
                .subscribe((sexe: Sexe) => {
                  this.sexe = sexe;
                });
              this.posteService
                .getById(membre.posteId)
                .subscribe((poste: Poste) => {
                  this.poste = poste;
                });
              this.lieuAffectationService
                .getById(membre.lieuAffectationId)
                .subscribe((lieuAffectation: LieuAffectation) => {
                  this.lieuAffectation = lieuAffectation;
                });
            });
        });
    });
  }

  enregistrerCompte(): void {
    if (this.membreId && this.cotisations.length > 0) {
      this.cotisationService
        .addCotisations(this.cotisations)
        .subscribe((value: any) => {
          this.cancel();
        });
    }
  }

  ajouter(): void {
    if (this.checkInfosCotisation()) {
      // MOUVEMENT D"ENREGISTREMENT DE LA COTISATION DU MOIS
      this.mvtCompte.dateMvt =
        this.cotisation.annee +
        '-' +
        this.getMoisNum(this.cotisation.moisId) +
        '-25';
      this.mvtCompte.typeOperation = TypeOperation.Credit;
      this.mvtCompte.gabaritId = 1;
      this.mvtCompte.libelle =
        'Cotisation du ' +
        this.getMoisNum(this.cotisation.moisId) +
        '/' +
        this.cotisation.annee;
      if (this.cotisation.montant)
        this.mvtCompte.montant = this.cotisation.montant;
      // this.mvtCompte.membreId = this.membreId;
      this.cotisation.mvtComptes.push(this.mvtCompte);

      // MOUVEMENT DE RETENU DES 10%
      this.mvtCompte = new MvtCompte();
      this.mvtCompte.dateMvt =
        this.cotisation.annee +
        '-' +
        this.getMoisNum(this.cotisation.moisId) +
        '-25';
      this.mvtCompte.typeOperation = TypeOperation.Debit;
      this.mvtCompte.gabaritId = 1;
      this.mvtCompte.libelle =
        'Retenu des 10% sur cotisation du ' +
        this.getMoisNum(this.cotisation.moisId) +
        '/' +
        this.cotisation.annee;
      if (this.cotisation.montant)
        this.mvtCompte.montant = (this.cotisation.montant * 1) / 10;
      // this.mvtCompte.membreId = this.membreId;
      this.cotisation.mvtComptes.push(this.mvtCompte);

      this.cotisation.membreId = this.membreId;
      this.cotisations.push(this.cotisation);
      this.cotisation = new Cotisation();
      this.mvtCompte = new MvtCompte();
    }
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
}
