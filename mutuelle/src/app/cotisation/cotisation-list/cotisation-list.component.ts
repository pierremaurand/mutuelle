import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Cotisation } from 'src/app/model/cotisation';
import { CotisationList } from 'src/app/model/cotisationList';

@Component({
  selector: 'app-cotisation-list',
  templateUrl: './cotisation-list.component.html',
  styleUrls: ['./cotisation-list.component.scss']
})
export class CotisationListComponent implements OnInit {
  @Input() cotisations!: CotisationList[];
  @Input() cotisation!: CotisationList;
  @Output() cotisationChange = new EventEmitter<Cotisation>();


  constructor() { }

  ngOnInit(): void {

  }

  modifCotisation(cotisation: Cotisation) {
    this.cotisationChange.emit(cotisation);
  }

  calcul90Pourcent(montant?: number): number {
    let reponse: number = 0;
    if(montant) {
      reponse = +montant*9/10;
    }
    return reponse;
  }

  calcul10Pourcent(montant?: number): number {
    let reponse: number = 0;
    if(montant) {
      reponse = +montant*1/10;
    }
    return reponse;
  }

}
