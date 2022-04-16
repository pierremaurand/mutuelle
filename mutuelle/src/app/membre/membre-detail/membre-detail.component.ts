import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cotisation } from 'src/app/model/cotisation';
import { CotisationList } from 'src/app/model/cotisationList';
import { Membre } from 'src/app/model/membre';
import { AlertifyService } from 'src/app/services/alertify.service';
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
  photo?: string;
  cotisations!: CotisationList[];
  cotisation: CotisationList = {
    id:0,
    periodeId: 0,
    membreId: 0,
    montant: 0
  };
  emptyCotisation: Cotisation = {
    id:0,
    periodeId: 0,
    membreId: 0,
    montant: 0
  };
  avancesList: [] = [];
  creditsList: [] = [];

  constructor(
    private route: ActivatedRoute,
    private membreService: MembreService,
    private cotisationService: CotisationService,
    private alertity: AlertifyService
  ) {}

  ngOnInit(): void {
    this.membreId = +this.route.snapshot.params['id'];
    this.membreId = +this.route.snapshot.params['id'];
    if (this.membreId) {
      this.membreService.getById(this.membreId).subscribe({
        next: (data) => {
          this.membre = data;
          this.photo = this.baseUrl + this.membre.photo;
          this.loadCotisations();
        },
      });
    }
  }

  loadCotisations(): void {
    if (this.membre.id) {
      this.cotisationService
        .getAllMembreCotisation(this.membre.id)
        .subscribe({
          next:(data:Cotisation[])  => {
            this.cotisations = data;
            console.log(data);
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

  ajouterCotisation(): void {
    this.cotisation = this.emptyCotisation;
  }

  saveCotisationChange(cotisation: Cotisation): void {
    let infos: Cotisation = {};
    if(this.membre.id)
      infos.membreId = this.membre.id;
    if(cotisation.periodeId)
      infos.periodeId = +cotisation.periodeId;
    if(cotisation.montant)
      infos.montant = +cotisation.montant;
    if(cotisation.id)
      infos.id = +cotisation.id;
    this.cotisationService.add(infos).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, cotisation enregistré avec succès');
        this.loadCotisations();
      }
    });
  }
}
