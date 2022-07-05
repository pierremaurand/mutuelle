import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Avance } from 'src/app/model/avance';
import { Cotisation } from 'src/app/model/cotisation';
import { Credit } from 'src/app/model/credit';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';
import { Membre } from 'src/app/model/membre';
import { Menu } from 'src/app/model/menu';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AvanceService } from 'src/app/services/avance.service';
import { CotisationService } from 'src/app/services/cotisation.service';
import { MembreService } from 'src/app/services/membre.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-membre-detail',
  templateUrl: './membre-detail.component.html',
  styleUrls: ['./membre-detail.component.scss'],
})
export class MembreDetailComponent implements OnInit {
  menuMembre: Array<Menu> = [
    {
      id: 'M1',
      titre: 'Infos Membre',
      icon: 'fas fa-user',
      url: 'membre-detail/infos-membre'
    },
    {
      id: 'M2',
      titre: 'Cotisations',
      icon: 'fa fa-sack-dollar',
      url: 'membre-detail/cotisations-membre'
    },
    {
      id: 'M3',
      titre: 'Avances',
      icon: 'fa fa-hand-holding-dollar',
      url: 'membre-detail/avances-membre'
    },
    {
      id: 'M4',
      titre: 'Credits',
      icon: 'fa fa-money-check',
      url: 'membre-detail/credits-membre'
    }
  ];

  membreId: number = 0;
  baseUrl = environment.imagesUrl;
  membre: Membre = {};
  titre: string = "Modification des informations d'un membre"
  imageUrl: string = "";
  cotisations: Cotisation[] = [];
  cotisation: Cotisation = new Cotisation();
  selectedCotisation: Cotisation = new Cotisation();
  avances: Avance[] = [];
  credit: Credit = new Credit();

  constructor(
    private avanceService: AvanceService,
    private cotisationService: CotisationService,
    private alertify: AlertifyService,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {

  }

  loadCotisations(): void {
    if (this.membreId) {
      this.cotisationService.getAllMembreCotisation(this.membreId).subscribe({
        next: (data) => {
          this.cotisations = data;
        },
      });
    }
  }

  loadAvances(): void {
    if (this.membreId) {
      this.avanceService.getAllMembreAvance(this.membreId).subscribe({
        next: (data) => {
          this.avances = data;
        },
      });
    }
  }

  deleteCotisation() {
    if(this.selectedCotisation.id) {
      this.cotisationService.update(this.selectedCotisation, this.selectedCotisation.id).subscribe({
        next: (data: any) => {
          this.alertify.success(
            'Félécitation, la cotisation a été supprimée avec succès'
          );
          this.loadCotisations();
        },
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

    return total;
  }

  montantCredit(): number {
    let montant: number = 100;

    return montant;
  }

  newCotisation(): void {
    this.cotisation = new Cotisation();
  }

  selectCotisation(cotisation: Cotisation): void {

  }

  selectAvance(avance: Avance): void {

  }

  selectCredit(credit: Credit): void {
    this.credit = credit;
  }

  addCotisation(): void {
   if(this.cotisation) {
      this.cotisation.estValide = true;
      /*this.membreService.addCotisationMembre(this.cotisation,this.membre.id).subscribe({
        next: (data: any) => {
          this.loadCotisations();
          this.alertify.success(
            'Félécitation, la cotisation a été enregistrée avec succès'
          );
        },
      });*/
    }
  }

   addCredit(): void {
    if(this.cotisation) {
       this.cotisation.estValide = true;
       /*this.membreService.addCotisationMembre(this.cotisation,this.membre.id).subscribe({
         next: (data: any) => {
           this.loadCotisations();
           this.alertify.success(
             'Félécitation, la cotisation a été enregistrée avec succès'
           );
         },
       });*/
     }
   }


  saveCreditChange(credit: Credit): void {

  }

  creditMessage(message: string): void {

  }

  cotisationMessage(message: string): void {
    this.alertify.success(message);
    //this.loadInfosMembre();
  }

  update(): void {
    if(this.membre) {
      /*this.membreService.updateInfos(this.membre, this.membre.id).subscribe({
        next: (data: any) => {
          //this.loadInfosMembre();
          this.alertify.success(
            'Félécitation, les modification du membre sont enregistrées avec succès'
          );
        },
      });*/
    }
  }
}
