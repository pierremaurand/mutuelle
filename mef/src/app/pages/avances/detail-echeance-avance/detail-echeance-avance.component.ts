import { Component, Input, OnInit } from '@angular/core';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';

@Component({
  selector: 'app-detail-echeance-avance',
  templateUrl: './detail-echeance-avance.component.html',
  styleUrls: ['./detail-echeance-avance.component.scss'],
})
export class DetailEcheanceAvanceComponent implements OnInit {
  @Input()
  echeance: EcheanceAvance = new EcheanceAvance();
  constructor() {}

  ngOnInit(): void {}
}
