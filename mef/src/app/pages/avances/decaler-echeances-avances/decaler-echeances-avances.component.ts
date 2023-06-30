import { Component, Input, OnInit } from '@angular/core';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';

@Component({
  selector: 'app-decaler-echeances-avances',
  templateUrl: './decaler-echeances-avances.component.html',
  styleUrls: ['./decaler-echeances-avances.component.scss'],
})
export class DecalerEcheancesAvancesComponent implements OnInit {
  @Input()
  echeancier: EcheanceAvance[] = [];
  constructor() {}

  ngOnInit(): void {}
}
