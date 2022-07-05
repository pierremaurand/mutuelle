import { Component, OnInit } from '@angular/core';
import { Cotisation } from 'src/app/model/cotisation';
import { Membre } from 'src/app/model/membre';
import { AlertifyService } from 'src/app/services/alertify.service';
import { CotisationService } from 'src/app/services/cotisation.service';
import { MembreService } from 'src/app/services/membre.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-membre-list',
  templateUrl: './membre-list.component.html',
  styleUrls: ['./membre-list.component.scss'],
})
export class MembreListComponent implements OnInit {
  listeMembres: Membre[] = [];
  membre: Membre = {};
  cotisations: Cotisation[] = [];
  imageUrl: string = '';
  baseUrl = environment.imagesUrl;
  nom: string = '';
  searchNom: string = '';
  titre: string = 'Ajout d\'un membre';

  constructor(
    private membreService: MembreService,
    private cotisationService: CotisationService,
    private alertity: AlertifyService
  ) {}

  ngOnInit(): void {
    this.loadMembres();
  }

  ajouterMembre(): void {
    this.membre = {};
  }

  select(id: number): void {
    this.loadMembre(id);
    this.loadCotisations(id);
    localStorage.setItem('MembreId',id.toString());
  }

  loadMembres(): void {
    this.membreService.getAllMembres().subscribe({
      next: (data) => {
        this.listeMembres = data;
        console.log(data);
      },
    });
  }

  loadMembre(id: number): void {
    this.membreService.getMembreById(id).subscribe({
      next: (data) => {
        this.membre = data;
      },
    });
  }

  loadCotisations(id: number): void {
    this.cotisationService.getAllMembreCotisation(id).subscribe({
      next: (data) => {
        this.cotisations = data;
      },
    });
  }

  editMembre(membre: Membre): void {
    this.membre = membre;
    this.imageUrl = this.baseUrl + this.membre.photo;
  }

  save(): void {
    if (this.membre) {
      this.membre.estActif = true;
      var membreToSave = this.membre;
      this.membre = {};
      this.membreService.addMembre(membreToSave).subscribe({
        next: (data: any) => {
          this.loadMembres();
          this.alertity.success('Félécitation, membre enregistré avec succès');
        },
      });
    }
  }

  afficheMois(): void {
    console.log(this.nom);
  }

  onSearch(): void {
    this.searchNom = this.nom;
  }

  onSearchClear(): void {
    this.searchNom = '';
    this.nom = '';
  }
}
