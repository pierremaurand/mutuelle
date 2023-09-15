import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';
import { AvanceService } from 'src/app/services/avance.service';

@Component({
  selector: 'app-page-echeances-avances',
  templateUrl: './page-echeances-avances.component.html',
  styleUrls: ['./page-echeances-avances.component.scss'],
})
export class PageEcheancesAvancesComponent implements OnInit {
  echeances: EcheanceAvance[] = [];
  dateEcheance: string = '';
  echeancier: EcheanceAvance[] = [];
  formulaire: number = 1;

  constructor(private avanceService: AvanceService) {}

  ngOnInit(): void {
    this.loadEcheances();
  }

  effacer(): void {
    this.dateEcheance = '';
    this.loadEcheances();
  }

  addEcheance(echeance: EcheanceAvance): void {
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
    this.avanceService
      .getAllEcheances()
      .subscribe((echeances: EcheanceAvance[]) => {
        this.echeances = echeances;
        this.echeancier.length = 0;
      });
  }
}
