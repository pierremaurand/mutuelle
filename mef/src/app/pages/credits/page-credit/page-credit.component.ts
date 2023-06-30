import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Credit } from 'src/app/model/credit';
import { EcheanceCredit } from 'src/app/model/echeanceCredit';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { CreditService } from 'src/app/services/credit.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-page-credit',
  templateUrl: './page-credit.component.html',
  styleUrls: ['./page-credit.component.scss'],
})
export class PageCreditComponent implements OnInit {
  credits: Credit[] = [];

  constructor(private creditService: CreditService, private router: Router) {}

  ngOnInit(): void {
    this.creditService.getAll().subscribe((credits: Credit[]) => {
      this.credits = credits;
    });
  }

  nouveauCredit(): void {
    this.router.navigate(['/nouveaucredit']);
  }

  navigate(id: number): void {
    this.router.navigate(['/nouveaucredit/' + id]);
  }

  exportCredits(): void {}

  importCredits(): void {}
}
