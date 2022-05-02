import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Avance } from 'src/app/model/avance';
import { Cotisation } from 'src/app/model/cotisation';
import { Membre } from "src/app/model/membre";
import { MembreList } from 'src/app/model/membreList';
import { AvanceService } from 'src/app/services/avance.service';
import { CotisationService } from 'src/app/services/cotisation.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-membre',
  templateUrl: './membre.component.html',
  styleUrls: ['./membre.component.scss']
})
export class MembreComponent implements OnInit {

  @Input() membre: MembreList = {};
  @Output() membreChange = new EventEmitter<Membre>();
  cotisations: Cotisation[] = [];
  avances: Avance[] = [];
  baseUrl = environment.imagesUrl;

  constructor(
    private cotisationService: CotisationService,
    private avanceService: AvanceService
  ) { }

  ngOnInit(): void {
    this.loadCotisations();
    this.loadAvances();
    this.loadCredits();
  }


  editMembre(): void {
    this.membreChange.emit(this.membre);
  }

  loadCotisations(): void {
    if (this.membre.id) {
      this.cotisationService
        .getAllMembreCotisation(this.membre.id)
        .subscribe({
          next:(data:Cotisation[])  => {
            this.cotisations = data;
          }
        });
    }
  }

  calculCotisation(): number {
    let total = 0;
    if(this.cotisations.length > 0) {
      for(let cotisation of this.cotisations) {
        if(cotisation.montant)
          total += cotisation.montant;
      }
    }
    return total;
  }

  loadAvances(): void {
    if (this.membre.id) {
      this.avanceService
        .getAllMembreAvance(this.membre.id)
        .subscribe({
          next:(data:Avance[])  => {
            this.avances = data;
          }
        });
    }
  }

  calculAvance(): number {
    let total = 0;
    if(this.avances.length > 0) {
      for(let avance of this.avances) {
        if(avance.montant) {
          total += avance.montant;
        }

        if(avance.echeanceAvances && avance.echeanceAvances.length > 0){
          for(let echeance of avance.echeanceAvances) {
            if(echeance.estPaye==true) {
              if(echeance.montant) {
                total -= echeance.montant;
              }
            }
          }
        }
      }
    }
    return total;
  }

  loadCredits(): void {

  }

  calculCredit(): number {
    let total = 0;

    return total;
  }

}
