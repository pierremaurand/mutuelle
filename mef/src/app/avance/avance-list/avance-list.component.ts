import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Avance } from 'src/app/model/avance';

@Component({
  selector: 'app-avance-list',
  templateUrl: './avance-list.component.html',
  styleUrls: ['./avance-list.component.scss']
})
export class AvanceListComponent implements OnInit {
  @Input() action: number = 0;
  @Output() actionChange = new EventEmitter<number>();
  @Input() avances: Avance[]=[];
  @Input() avance: Avance = new Avance();
  @Output() avanceChange = new EventEmitter<Avance>();

  constructor() { }

  ngOnInit(): void {
  }

  clickAction(avance: Avance, action: number): void {
    this.action = action;
    this.avance = avance;
    this.avanceChange.emit(this.avance);
    this.actionChange.emit(this.action);
  }

  nbrEcheances(avance: Avance): number {
    if(avance.echeanceAvances)
      return avance.echeanceAvances.length;
    return 0;
  }

  soldeRestant(avance: Avance): number {
    let reste = avance.montant;
    const echeances = avance.echeanceAvances;
    if(reste) {
      if(echeances) {
        echeances.forEach(echeance => {
          if(echeance.montant && echeance.estPaye && echeance.estPaye === true && reste)
            reste -= +echeance.montant;
        });
      }
      return reste;
    }
    return 0;
  }

  nbrEcheancesR(avance: Avance): number {
    let reste = avance.echeanceAvances?.length;
    const echeances = avance.echeanceAvances;
    if(reste) {
      if(echeances) {
        echeances.forEach(echeance => {
          if(echeance.estPaye && echeance.estPaye === true && reste)
            reste -= 1;
        });
      }
      return reste;
    }
    return 0;
  }

}
