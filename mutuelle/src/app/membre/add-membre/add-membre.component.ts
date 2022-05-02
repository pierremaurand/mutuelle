import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Agence } from 'src/app/model/agence';
import { Membre } from "src/app/model/membre";
import { Service } from 'src/app/model/service';
import { Sexe } from 'src/app/model/sexe';
import { AgenceService } from 'src/app/services/agence.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { MembreService } from 'src/app/services/membre.service';
import { ServiceService } from 'src/app/services/service.service';
import { SexeService } from 'src/app/services/sexe.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-add-membre',
  templateUrl: './add-membre.component.html',
  styleUrls: ['./add-membre.component.scss']
})
export class AddMembreComponent implements OnInit {

  membreId?: number;
  @ViewChild("closeMembreFormModal") modalClose:any;
  @Input() membre: Membre = {};
  @Output() membreChange = new EventEmitter<Membre>();
  sexes: Sexe[] = [];
  fichier?: any;
  agences: Agence[] = [];
  services: Service[] = [];
  baseUrl = environment.imagesUrl;
  photo?: string;

  constructor(
    private agenceService: AgenceService,
    private sexeService: SexeService,
    private serviceService: ServiceService,
    private alertity: AlertifyService) { }

  ngOnInit(): void {
    this.agenceService.getAll().subscribe({
      next:(data) => {
        this.agences = data;
      }
    });

    this.serviceService.getAll().subscribe({
      next:(data) => {
        this.services = data;
      }
    });

    this.sexeService.getAll().subscribe({
      next:(data) => {
        this.sexes = data;
      }
    });
  }

  onSubmit(membreForm: NgForm) {
    if (membreForm.valid) {
      this.membreChange.emit(this.membre);
      this.modalClose.nativeElement.click();
    } else {
      this.alertity.error('Veuillez remplir tous les champs obligatoires');
    }
  }



  changerPhotoProfil():void {
    if(!this.fichier) {
      if(this.membre.sexeId == 1) {
        this.membre.photo = 'assets/images/default_man.jpg';
      } else {
        this.membre.photo = 'assets/images/default_woman.jpg';
      }
    }
  }

  /**
   * handle file from browsing
   */


  annuler(): void {
    this.photo = undefined;
  }

}
