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
  constructor(private avanceService: AvanceService) {}

  ngOnInit(): void {
    this.avanceService.getAllEcheances().subscribe(() => {});
  }
}
