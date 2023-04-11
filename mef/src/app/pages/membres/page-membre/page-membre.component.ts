import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-page-membre',
  templateUrl: './page-membre.component.html',
  styleUrls: ['./page-membre.component.scss'],
})
export class PageMembreComponent implements OnInit {
  membres: Membre[] = [];
  sexes: Sexe[] = [];
  postes: Poste[] = [];
  lieuAffectations: LieuAffectation[] = [];

  constructor(
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
            this.membreService.getAll().subscribe((data: Membre[]) => {
              this.membres = data;
            });
          });
      });
    });
  }

  nouveauMembre(): void {
    this.router.navigate(['/nouveaumembre']);
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

  getPhoto(photo?: string): string {
    return this.membreService.getPhotoUrl(photo);
  }
}
