import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Gabarit } from 'src/app/model/gabarit';
import { InfosCompte } from 'src/app/model/infosCompte';
import { InfosMembre } from 'src/app/model/infosMembre';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MvtCompte } from 'src/app/model/mvtCompte';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { TypeOperation } from 'src/app/model/typeoperation';
import { CompteService } from 'src/app/services/compte.service';
import { GabaritService } from 'src/app/services/gabarit.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-nouveau-compte',
  templateUrl: './nouveau-compte.component.html',
  styleUrls: ['./nouveau-compte.component.scss'],
})
export class NouveauCompteComponent implements OnInit {
  membre: Membre = new Membre();
  sexe: Sexe = new Sexe();
  poste: Poste = new Poste();
  lieuAffectation: LieuAffectation = new LieuAffectation();
  mvtCompte: MvtCompte = new MvtCompte();
  mvtComptes: MvtCompte[] = [];
  gabarits: Gabarit[] = [];
  membreId?: number;
  photo: string = '';
  SortbyParam = 'dateMvt';
  SortDirection = 'desc';

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private gabaritService: GabaritService,
    private compteService: CompteService,
    private sexeService: SexeService,
    private posteService: PosteService,
    private lieuAffectationService: LieuAffectationService,
    private membreService: MembreService
  ) {}

  ngOnInit(): void {
    this.gabaritService.getAll().subscribe((gabarits: Gabarit[]) => {
      this.gabarits = gabarits;
      this.membreId = this.activatedRoute.snapshot.params['id'];
      this.compteService
        .getAllMvtsById(this.membreId)
        .subscribe((mvtComptes: MvtCompte[]) => {
          this.mvtComptes = mvtComptes;
          this.compteService
            .getById(this.membreId)
            .subscribe((membre: Membre) => {
              this.membre = membre;
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
    if (this.membreId && this.mvtComptes.length > 0) {
      this.compteService.addMvts(this.mvtComptes).subscribe((value: any) => {
        this.cancel();
      });
    }
  }

  ajouterMvtCompte(): void {
    if (this.checkInfosMvt()) {
      this.mvtCompte.membreId = this.membreId;
      this.mvtCompte.gabaritId = 1;
      this.mvtComptes.push(this.mvtCompte);
      this.mvtCompte = new MvtCompte();
    }
  }

  soldeCompte(): number {
    let solde = 0;
    this.mvtComptes.map((mvtCompte) => {
      if (mvtCompte.typeOperation == TypeOperation.Credit) {
        solde += mvtCompte.montant ? mvtCompte.montant : 0;
      } else {
        solde -= mvtCompte.montant ? mvtCompte.montant : 0;
      }
    });
    return solde;
  }

  getTypeOperation(typeOperation: number): string {
    const operation: string =
      'Note de ' + (typeOperation == TypeOperation.Credit ? 'Crédit' : 'Débit');
    return operation;
  }

  checkInfosMvt(): boolean {
    if (
      !this.mvtCompte.dateMvt ||
      !this.mvtCompte.gabaritId ||
      !this.mvtCompte.typeOperation ||
      !this.mvtCompte.libelle ||
      !this.mvtCompte.montant
    ) {
      return false;
    }

    return true;
  }

  cancel(): void {
    this.router.navigate(['/comptes']);
  }
}
