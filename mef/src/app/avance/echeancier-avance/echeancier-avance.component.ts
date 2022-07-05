import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';

@Component({
  selector: 'app-echeancier-avance',
  templateUrl: './echeancier-avance.component.html',
  styleUrls: ['./echeancier-avance.component.scss']
})
export class EcheancierAvanceComponent implements OnInit {
  @Input() echeances: EcheanceAvance[] = [];
  @Input() echeance!: EcheanceAvance;
  @Output() echeanceChange = new EventEmitter<EcheanceAvance>();
  @Input() debut: number = 1;
  @Input() checked: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  toggleCheck(echeance: EcheanceAvance): void {
    this.echeance = echeance;
    this.echeanceChange.emit(this.echeance);
  }

}
