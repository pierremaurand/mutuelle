import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Avance } from 'src/app/model/avance';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { AvanceService } from 'src/app/services/avance.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-page-avance',
  templateUrl: './page-avance.component.html',
  styleUrls: ['./page-avance.component.scss'],
})
export class PageAvanceComponent implements OnInit {
  avances: Avance[] = [];
  membres: Membre[] = [];
  sexes: Sexe[] = [];
  postes: Poste[] = [];
  lieuAffectations: LieuAffectation[] = [];
  echeances: EcheanceAvance[] = [];

  constructor(private avanceService: AvanceService, private router: Router) {}

  ngOnInit(): void {
    this.avanceService
      .getAllEcheances()
      .subscribe((echeances: EcheanceAvance[]) => {
        this.echeances = echeances;
        this.avanceService.getAll().subscribe((avances: Avance[]) => {
          this.avances = avances;
        });
      });
  }

  nouveauAvance(): void {
    this.router.navigate(['/nouvelleavance']);
  }

  navigate(id: number): void {
    this.router.navigate(['/nouvelleavance/' + id]);
  }

  getSolde(avance: Avance): number {
    let solde = avance?.montant ?? 0;
    this.echeances
      .filter(({ estPaye, avanceId }) => estPaye && avanceId == avance?.id)
      .forEach((e) => {
        if (solde) solde -= e.montant ?? 0;
      });

    return solde;
  }
}
