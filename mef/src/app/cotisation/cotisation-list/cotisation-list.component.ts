import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Cotisation } from 'src/app/model/cotisation';
import { AlertifyService } from 'src/app/services/alertify.service';
import { CotisationService } from 'src/app/services/cotisation.service';

@Component({
  selector: 'app-cotisation-list',
  templateUrl: './cotisation-list.component.html',
  styleUrls: ['./cotisation-list.component.scss']
})
export class CotisationListComponent implements OnInit {
  @Input() action: number = 0;
  @Output() actionChange = new EventEmitter<number>();
  @Input() cotisations: Cotisation[]|null = null;
  @Input() cotisation: Cotisation = new Cotisation();
  @Output() cotisationChange = new EventEmitter<Cotisation>();


  constructor() { }

  ngOnInit(): void {

  }

  clickAction(cotisation: Cotisation, action: number): void {
    this.action = action;
    this.cotisation = cotisation;
    this.cotisationChange.emit(this.cotisation);
    this.actionChange.emit(this.action);
  }

  deleteCotisation(cotisation: Cotisation) {
    var confirmValue = confirm("Voulez-vous vraiment supprimer cette cotisation");
    if(confirmValue) {
      cotisation.estValide = false;
      this.cotisation = cotisation;
      this.cotisationChange.emit(this.cotisation);
    }
  }

  calcul90Pourcent(montant: number | null): number {
    let reponse: number = 0;
    if(montant!=null) {
      reponse = +montant*9/10;
    }
    return reponse;
  }

  calcul10Pourcent(montant: number | null): number {
    let reponse: number = 0;
    if(montant!=null) {
      reponse = +montant*1/10;
    }
    return reponse;
  }

}
