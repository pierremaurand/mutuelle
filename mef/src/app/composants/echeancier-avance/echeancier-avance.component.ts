import { Component, Input, OnInit } from '@angular/core';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';

@Component({
  selector: 'app-echeancier-avance',
  templateUrl: './echeancier-avance.component.html',
  styleUrls: ['./echeancier-avance.component.scss'],
})
export class EcheancierAvanceComponent implements OnInit {
  @Input()
  echeancier: EcheanceAvance[] = [];
  @Input()
  nbrEcheances?: number = 0;

  constructor() {}

  ngOnInit(): void {}
}
