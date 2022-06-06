import { Component, Input, OnInit } from '@angular/core';
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
  baseUrl = environment.imagesUrl;

  constructor(private membreService:MembreService) { }

  ngOnInit(): void {
  }



  calculCotisation(): number {
    let total = 0;
    if(this.membre && this.membre.cotisations && this.membre.cotisations.length > 0) {
      for(let cotisation of this.membre.cotisations) {
        if(cotisation.montant)
          total += cotisation.montant;
      }
    }
    return total;
  }

  cotisationsNbr(): number {
    let nombre = 0;
    if(this.membre && this.membre.cotisations) {
      nombre = this.membre.cotisations.length;
    }
    return nombre;
  }



  calculAvance(): number {
    let total = 0;
    if(this.membre && this.membre.avances && this.membre.avances.length > 0) {
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
    }
    return total;
  }

  avancesNbr(): number {
    let nombre = 0;
    if(this.membre && this.membre.avances) {
      nombre = this.membre.avances.length;
    }
    return nombre;
  }


  calculCredit(): number {
    let total = 0;

    return total;
  }

  creditsNbr(): number {
    let nombre = 0;
    if(this.membre && this.membre.credits) {
      nombre = this.membre.credits.length;
    }
    return nombre;
  }

  afficheAgence(): string|undefined {
    return this.membreService.afficheAgence(this.membre.agence);
  }

  afficheService(): string|undefined {
    return this.membreService.afficheService(this.membre.service);
  }

}
