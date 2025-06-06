import { Component, Input, OnInit } from '@angular/core';
import { Echeance } from 'src/app/models/echeance.model';
import { EcheanceAvance } from 'src/app/models/echeanceAvance';

@Component({
    selector: 'app-decaler-echeances-avances',
    templateUrl: './decaler-echeances-avances.component.html',
    styleUrls: ['./decaler-echeances-avances.component.scss'],
    standalone: false
})
export class DecalerEcheancesAvancesComponent implements OnInit {
  @Input()
  echeancier: Echeance[] = [];
  constructor() {}

  ngOnInit(): void {}
}
