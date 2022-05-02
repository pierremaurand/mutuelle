import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Avance } from 'src/app/model/avance';

@Component({
  selector: 'app-avance-list',
  templateUrl: './avance-list.component.html',
  styleUrls: ['./avance-list.component.scss']
})
export class AvanceListComponent implements OnInit {
  @Input() avances: Avance[]=[];
  @Input() avance: Avance = {};
  @Output() avanceChange = new EventEmitter<Avance>();
  constructor() { }

  ngOnInit(): void {
  }

  modifAvance(avance: Avance): void {
    this.avanceChange.emit(avance);
  }

  nbrEcheances(avance: Avance): number {
    if(avance.echeanceAvances)
      return avance.echeanceAvances.length;
    return 0;
  }

}
