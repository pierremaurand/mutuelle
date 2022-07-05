import { Component, Input, OnInit } from '@angular/core';
import { Cotisation } from 'src/app/model/cotisation';
import { Membre } from "src/app/model/membre";
import { MembreService } from 'src/app/services/membre.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-membre',
  templateUrl: './membre.component.html',
  styleUrls: ['./membre.component.scss']
})
export class MembreComponent implements OnInit {

  @Input() membre: Membre = {};
  @Input() cotisations: Cotisation[] = [];
  baseUrl = environment.imagesUrl;

  constructor(private membreService:MembreService) { }

  ngOnInit(): void {
  }



  calculCotisation(): number {
    let total = 0;
    if(this.membre && this.cotisations && this.cotisations.length > 0) {
      for(let cotisation of this.cotisations) {
        if(cotisation.montant && cotisation.estValide)
          total += cotisation.montant;
      }
    }
    return total;
  }

  cotisationsNbr(): number {
    let nombre = 0;
    if(this.membre && this.cotisations) {
      nombre = this.cotisations.length;
    }
    return nombre;
  }



  calculAvance(): number {
    let total = 0;
    /*if(this.membre && this.membre.avances && this.membre.avances.length > 0) {
      for(let avance of this.membre.avances) {
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
    }*/
    return total;
  }

  avancesNbr(): number {
    let nombre = 0;
    /*if(this.membre && this.membre.avances) {
      nombre = this.membre.avances.length;
    }*/
    return nombre;
  }


  calculCredit(): number {
    let total = 0;

    return total;
  }

  creditsNbr(): number {
    let nombre = 0;
    /*if(this.membre && this.membre.credits) {
      nombre = this.membre.credits.length;
    }*/
    return nombre;
  }

}
