import { Component, OnInit } from '@angular/core';
import { EcheanceCredit } from 'src/app/model/echeanceCredit';
import { CreditService } from 'src/app/services/credit.service';

@Component({
  selector: 'app-page-echeances-credits',
  templateUrl: './page-echeances-credits.component.html',
  styleUrls: ['./page-echeances-credits.component.scss'],
})
export class PageEcheancesCreditsComponent implements OnInit {
  echeances: EcheanceCredit[] = [];
  dateEcheance: string = '';
  echeancier: EcheanceCredit[] = [];
  formulaire: number = 1;

  constructor(private creditService: CreditService) {}

  ngOnInit(): void {
    this.loadEcheances();
  }

  effacer(): void {
    this.dateEcheance = '';
    this.loadEcheances();
  }

  addEcheance(echeance: EcheanceCredit): void {
    if (this.echeancier.find((e) => e.id == echeance.id)) {
      this.echeancier = this.echeancier.filter((e) => e.id != echeance.id);
    } else {
      this.echeancier.push(echeance);
    }
  }

  payer(): void {
    this.formulaire = 1;
  }

  decaler(): void {
    this.formulaire = 2;
  }

  loadEcheances(): void {
    this.creditService
      .getAllEcheances()
      .subscribe((echeances: EcheanceCredit[]) => {
        this.echeances = echeances;
        this.echeancier.length = 0;
      });
  }
}
