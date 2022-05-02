import { Component, OnInit } from '@angular/core';
import { Membre } from "src/app/model/membre";
import { MembreList } from 'src/app/model/membreList';
import { AlertifyService } from 'src/app/services/alertify.service';
import { MembreService } from 'src/app/services/membre.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-membre-list',
  templateUrl: './membre-list.component.html',
  styleUrls: ['./membre-list.component.scss']
})
export class MembreListComponent implements OnInit {

  listeMembres: MembreList[] = [];
  membre: MembreList = {};
  imageUrl: string = '';
  baseUrl = environment.imagesUrl;
  nom: string = '';
  searchNom: string = '';

  constructor(
    private membreService: MembreService,
    private alertity: AlertifyService
  ) { }

  ngOnInit(): void {
    this.loadMembres();
  }

  ajouterMembre(): void {
    this.membre = {};
  }

  editMembre(membre:Membre):void {
    this.membre = membre;
    this.imageUrl = this.baseUrl + this.membre.photo;
  }

  save(): void {
    this.membre.estActif = true;
    this.membreService.add(this.membre).subscribe({
      next: (data: any) => {
        this.loadMembres();
        this.alertity.success('Félécitation, membre enregistré avec succès');
      },
    });
  }

  update(): void {
    this.membreService.update(this.membre, this.membre.id).subscribe({
      next: (data: any) => {
        this.loadMembres();
        this.alertity.success('Félécitation, les modification du membre sont enregistrées avec succès');
      },
    });
  }

  saveChange(membre: Membre) {
    this.membre = membre;
    console.log(this.membre);
    if(this.membre.id) {
      this.update();
    } else {
      this.save();
    }
  }

  loadMembres():void {
    this.membreService.getAll().subscribe({
      next:(data) => {
        this.listeMembres = data;
        console.log(data);
      }
    });
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
