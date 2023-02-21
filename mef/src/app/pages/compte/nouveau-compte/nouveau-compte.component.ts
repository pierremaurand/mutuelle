import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Compte } from 'src/app/model/compte';
import { Gabarit } from 'src/app/model/gabarit';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MvtCompte } from 'src/app/model/mvtCompte';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { CompteService } from 'src/app/services/compte.service';
import { GabaritService } from 'src/app/services/gabarit.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { LoaderService } from 'src/app/services/loader.service';
import { MembreService } from 'src/app/services/membre.service';
import { MvtCompteService } from 'src/app/services/mvt-compte.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-nouveau-compte',
  templateUrl: './nouveau-compte.component.html',
  styleUrls: ['./nouveau-compte.component.scss'],
})
export class NouveauCompteComponent implements OnInit {
  compte: Compte = new Compte();
  newMvtComptes: MvtCompte[] = [];
  mvtComptes: MvtCompte[] = [];
  mvtCompte: MvtCompte = new MvtCompte();
  gabarits: Gabarit[] = [];
  membres: Membre[] = [];
  membre: Membre = {};
  postes: Poste[] = [];
  poste: Poste = {};
  sexes: Sexe[] = [];
  sexe: Sexe = {};
  lieuAffectations: LieuAffectation[] = [];
  lieuAffectation: LieuAffectation = {};
  photo: string = '';

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private compteService: CompteService,
    private mvtCompteService: MvtCompteService,
    private gabaritService: GabaritService,
    private membreService: MembreService,
    private sexeService: SexeService,
    private posteService: PosteService,
    private lieuAffectationService: LieuAffectationService
  ) {}

  ngOnInit(): void {
    this.gabaritService.getAll().subscribe((gabarits: Gabarit[]) => {
      this.gabarits = gabarits;
      this.membreService.getAllActifs().subscribe((membres: Membre[]) => {
        this.membres = membres;
        this.sexeService.getAll().subscribe((sexes: Sexe[]) => {
          this.sexes = sexes;
          this.posteService.getAll().subscribe((postes: Poste[]) => {
            this.postes = postes;
            this.lieuAffectationService
              .getAll()
              .subscribe((lieuAffectations: LieuAffectation[]) => {
                this.lieuAffectations = lieuAffectations;
                this.photo = this.membreService.getPhotoUrl();
                const idCompte = this.activatedRoute.snapshot.params['id'];
                if (idCompte) {
                  this.compteService
                    .getById(idCompte)
                    .subscribe((compte: Compte) => {
                      this.compte = compte;
                      this.changeMembre();
                    });
                }
              });
          });
        });
      });
    });
  }

  enregistrerCompte(): void {
    if (this.compte.id) {
      this.compteService
        .update(this.compte, this.compte.id)
        .subscribe((value: any) => {
          this.cancel();
        });
    } else {
      this.compteService.add(this.compte).subscribe((id: number) => {
        this.cancel();
      });
    }
  }

  ajouterMvtCompte(): void {
    this.mvtComptes.push(this.mvtCompte);
    this.newMvtComptes.push(this.mvtCompte);
    this.mvtCompte = new MvtCompte();
  }

  supprimerMvtCompte(mvtCompte: MvtCompte): void {
    let position = this.mvtComptes.indexOf(mvtCompte);
    this.mvtComptes.splice(position, 1);
    position = this.newMvtComptes.indexOf(mvtCompte);
    this.newMvtComptes.splice(position, 1);
  }

  cancel(): void {
    this.router.navigate(['/comptes']);
  }

  changeMembre(): void {
    this.membres.map((membre) => {
      if (membre.id == this.compte.membreId) {
        this.membre = membre;
        this.sexes.map((sexe) => {
          if (sexe.id == this.membre.sexeId) {
            this.sexe = sexe;
            this.postes.map((poste) => {
              if (poste.id == this.membre.posteId) {
                this.poste = poste;
                this.lieuAffectations.map((lieuAffectation) => {
                  if (lieuAffectation.id == this.membre.lieuAffectationId) {
                    this.lieuAffectation = lieuAffectation;
                  }
                });
              }
            });
          }
        });

        this.photo = this.membreService.getPhotoUrl(this.membre.photo);
      }
    });
  }
}
