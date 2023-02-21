import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { LoaderService } from 'src/app/services/loader.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-profil-membre',
  templateUrl: './profil-membre.component.html',
  styleUrls: ['./profil-membre.component.scss'],
})
export class ProfilMembreComponent implements OnInit {
  membreInfos: Membre = {};
  membre: Membre = {};
  photo: string = '';
  sexe: Sexe = {};
  poste: Poste = {};
  lieuAffectation: LieuAffectation = {};

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private membreService: MembreService,
    private sexeService: SexeService,
    private posteService: PosteService,
    private lieuAffectationService: LieuAffectationService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    const idMembre = this.activatedRoute.snapshot.params['id'];
    if (idMembre) {
      this.membreService.getById(idMembre).subscribe((membre: Membre) => {
        this.membre = membre;
        this.sexeService.getById(this.membre.sexeId).subscribe((sexe: Sexe) => {
          this.sexe = sexe;
        });
        this.posteService
          .getById(this.membre.posteId)
          .subscribe((poste: Poste) => {
            this.poste = poste;
          });
        this.lieuAffectationService
          .getById(this.membre.lieuAffectationId)
          .subscribe((lieuAffectation: LieuAffectation) => {
            this.lieuAffectation = lieuAffectation;
          });
        this.photo = this.membreService.getPhotoUrl(this.membre.photo);
      });
    }
  }

  activer(): void {
    this.membre.estActif = !this.membre.estActif;
    this.membreService
      .update(this.membre, this.membre.id)
      .subscribe((value: any) => {});
  }

  cancel(): void {
    this.router.navigate(['/membres']);
  }
}
