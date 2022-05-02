import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Avance } from 'src/app/model/avance';
import { Cotisation } from 'src/app/model/cotisation';
import { Credit } from 'src/app/model/credit';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';
import { MembreList } from 'src/app/model/membreList';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AvanceService } from 'src/app/services/avance.service';
import { MembreService } from 'src/app/services/membre.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-membre-detail',
  templateUrl: './membre-detail.component.html',
  styleUrls: ['./membre-detail.component.scss'],
})
export class MembreDetailComponent implements OnInit {
  membreId?: number;
  baseUrl = environment.imagesUrl;
  membre: MembreList = {};
  photo?: string;
  cotisations!: Cotisation[];
  cotisation: Cotisation = {};
  avances!: Avance[];
  avance: Avance = {};
  echeanceAvance: EcheanceAvance[] = [];
  credits!: Credit[];
  credit: Credit = {};

  constructor(
    private route: ActivatedRoute,
    private membreService: MembreService,
    private avanceService: AvanceService,
    private alertity: AlertifyService
  ) {}

  ngOnInit(): void {
    this.membreId = +this.route.snapshot.params['id'];
    if (this.membreId) {
      this.membreService.getById(this.membreId).subscribe({
        next: (data) => {
          this.membre = data;
          this.photo = this.baseUrl + this.membre.photo;
          this.loadCotisations();
          this.loadAvances();
        },
      });
    }
  }

  loadCotisations(): void {
    if (this.membre.id) {
      this.membreService
        .getCotisations(this.membre.id)
        .subscribe({
          next:(data:Cotisation[])  => {
            this.cotisations = data;
          }
        });
    }
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



  montantCotisation():number {
    let montant:number = 0;
    if(this.cotisations) {
      this.cotisations.forEach(cotisation => {
        if(cotisation.montant)
          montant += +cotisation.montant;
      });
    }
    return (montant*90)/100;
  }

  montantAvance(): number {
    let total = 0;
    if(this.avances && this.avances.length > 0) {
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

  montantCredit(): number {
    let montant: number = 100;

    return montant;
  }

  newCotisation(): void {
    this.cotisation = {};
  }

  newAvance(): void {
    this.avance = {};
    this.echeanceAvance = [];
  }

  selectCotisation(cotisation: Cotisation): void {
    this.cotisation = cotisation;
  }

  selectAvance(avance: Avance): void {
    this.avance = avance;
    if(this.avance.echeanceAvances) {
      this.echeanceAvance = this.avance.echeanceAvances;
    } else {
      this.echeanceAvance = [];
    }
  }

  selectCredit(credit: Credit): void {
    this.credit = credit;
  }

  saveCotisationChange(cotisation: Cotisation): void {
    this.cotisation = {};
    if(cotisation.id) {
      if(this.membre.id) {
        this.membreService.updateCotisation(this.membre.id,cotisation).subscribe({
          next: (data: any) => {
            this.cotisationMessage('Félécitation, cotisation modifié avec succès');
          }
        });
      }
    } else {
      if(this.membre.id) {
        this.membreService.addCotisation(this.membre.id,cotisation).subscribe({
          next: (data: any) => {
            this.cotisationMessage('Félécitation, cotisation enregistré avec succès');
          }
        });
      }
    }
  }

  saveAvanceChange(avance: Avance): void {

  }

  saveCreditChange(credit: Credit): void {

  }

  avanceMessage(message: string): void {

  }

  creditMessage(message: string): void {

  }

  cotisationMessage(message: string): void {
    this.alertity.success(message);
    this.loadCotisations();
  }
}
