import { Component, Input, OnInit } from '@angular/core';
import { EcheanceCredit } from 'src/app/model/echeanceCredit';

@Component({
  selector: 'app-echeancier-credit',
  templateUrl: './echeancier-credit.component.html',
  styleUrls: ['./echeancier-credit.component.scss'],
})
export class EcheancierCreditComponent implements OnInit {
  @Input()
  echeancier: EcheanceCredit[] = [];
  @Input()
  nbrEcheances?: number = 0;

  constructor() {}

  ngOnInit(): void {}
}
