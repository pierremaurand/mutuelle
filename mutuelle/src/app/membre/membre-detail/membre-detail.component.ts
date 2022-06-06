import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Avance } from 'src/app/model/avance';
import { CotisationList } from 'src/app/model/cotisationList';
import { Credit } from 'src/app/model/credit';
import { Membre } from 'src/app/model/membre';
import { MembreList } from 'src/app/model/membreList';
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
  membreId?: number;
  baseUrl = environment.imagesUrl;
  membre: Membre = {};
  titre: string = "Modification des informations d'un membre"
  imageUrl!: string;
  cotisations?: CotisationList[];
  cotisation!: CotisationList;
  avance: Avance = {};
  credit: Credit = {};

  constructor(
    private route: ActivatedRoute,
    private membreService: MembreService,
    private avanceService: AvanceService,
    private cotisationService: CotisationService,
    private alertity: AlertifyService
  ) {}

  ngOnInit(): void {
    this.membreId = +this.route.snapshot.params['id'];
    this.loadInfosMembre();
  }

  loadInfosMembre(): void {
    if (this.membreId) {
      this.membreService.getById(this.membreId).subscribe({
        next: (data) => {
          this.membre = data;
          this.imageUrl = this.baseUrl + this.membre.photo;
          this.cotisations = this.membre.cotisations;
        },
      });
    }
  }

  loadCotisations(): void {
    if (this.membre && this.membre.id) {
      this.cotisationService
        .getAllMembreCotisation(this.membre.id)
        .subscribe({
          next:(data:CotisationList[])  => {
            this.cotisations = data;
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

    return total;
  }

  montantCredit(): number {
    let montant: number = 100;

    return montant;
  }

  newCotisation(): void {

  }

  newAvance(): void {

  }

  selectCotisation(cotisation: CotisationList): void {
    this.cotisation = cotisation;
  }

  selectAvance(avance: Avance): void {

  }

  selectCredit(credit: Credit): void {
    this.credit = credit;
  }

  saveCotisationChange(cotisation: CotisationList): void {

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

  update(): void {
    if(this.membre) {
      this.membreService.update(this.membre, this.membre.id).subscribe({
        next: (data: any) => {
          this.loadInfosMembre();
          this.alertity.success(
            'Félécitation, les modification du membre sont enregistrées avec succès'
          );
        },
      });
    }
  }
}
