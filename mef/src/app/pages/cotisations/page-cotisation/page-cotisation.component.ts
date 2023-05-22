import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cotisation } from 'src/app/model/cotisation';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
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
  membres: MembreList[] = [];
  cotisations: Cotisation[] = [];

  constructor(
    private cotisationService: CotisationService,
    private membreService: MembreService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.membreService.getAll().subscribe((membres: MembreList[]) => {
      this.membres = membres;
    });
  }

  nouveau(): void {
    this.router.navigate(['/nouvellecotisation']);
  }

  navigate(id: number): void {
    this.router.navigate(['/nouvellecotisation/' + id]);
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
