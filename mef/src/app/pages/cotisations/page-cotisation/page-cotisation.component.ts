import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cotisation } from 'src/app/model/cotisation';
import { CotisationList } from 'src/app/model/cotisationList';
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
  cotisations: CotisationList[] = [];

  constructor(
    private cotisationService: CotisationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.cotisationService
      .getAllCotisations()
      .subscribe((cotisations: CotisationList[]) => {
        this.cotisations = cotisations;
      });
  }

  nouveau(): void {
    this.router.navigate(['/nouvellecotisation']);
  }

  navigate(id: number): void {
    this.router.navigate(['/nouvellecotisation/' + id]);
  }
}
