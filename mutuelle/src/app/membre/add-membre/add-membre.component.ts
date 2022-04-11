import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Agence } from 'src/app/model/agence';
import { Membre } from 'src/app/model/membre';
import { MembreInfos } from 'src/app/model/membreInfos';
import { Service } from 'src/app/model/service';
import { Sexe } from 'src/app/model/sexe';
import { AgenceService } from 'src/app/services/agence.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { MembreService } from 'src/app/services/membre.service';
import { ServiceService } from 'src/app/services/service.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-add-membre',
  templateUrl: './add-membre.component.html',
  styleUrls: ['./add-membre.component.scss']
})
export class AddMembreComponent implements OnInit {

  membreId?: number;
  membre: MembreInfos = {};
  membreForm!: FormGroup;
  membreSubmitted: boolean = false;
  photo: string = 'assets/images/default_man.jpg';
  titreFormulaire: string = "Ajoute d'un membre";
  sexes: Sexe[] = [];

  agences: Agence[] = [];

  services: Service[] = [];

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private membreService: MembreService,
    private agenceService: AgenceService,
    private sexeService: SexeService,
    private serviceService: ServiceService,
    private alertity: AlertifyService) { }

  ngOnInit(): void {
    this.membreId = +this.route.snapshot.params['id'];
    this.membre.photo = 'assets/images/default_man.jpg';
    if(this.membreId) {
      this.titreFormulaire = "Modification d'un membre";
      this.membreService.getById(this.membreId).subscribe({
        next:(data) => {
          this.membre = data;
          if(!this.membre.photo) {
            if(this.membre.sexeId==1) {
              this.membre.photo = 'assets/images/default_man.jpg';
            }else {
              this.membre.photo = 'assets/images/default_woman.jpg';
            }
          }
        }
      });
    }

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


    this.createMembreForm();
  }

  createMembreForm(){
    this.membreForm = this.fb.group({
      nom: [null,Validators.required],
      prenom: [null, Validators.required],
      sexe: [null, Validators.required],
      agence: [null, Validators.required],
      service: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      telephone: [null, Validators.required],
      dateAdhesion: [null, Validators.required]
    })
  }

  //-------------------------------------
  // Getter methos for all form controls
  //-------------------------------------
  get nom() {
    return this.membreForm.get('nom') as FormControl;
  }

  get prenom() {
    return this.membreForm.get('prenom') as FormControl;
  }

  get dateAdhesion() {
    return this.membreForm.get('dateAdhesion') as FormControl;
  }

  get sexe() {
    return this.membreForm.get('sexe') as FormControl;
  }

  get agence() {
    return this.membreForm.get('agence') as FormControl;
  }

  get service() {
    return this.membreForm.get('service') as FormControl;
  }

  get email() {
    return this.membreForm.get('email') as FormControl;
  }

  get telephone() {
    return this.membreForm.get('telephone') as FormControl;
  }

  //---------------------------------------------------


  onSubmit() {
    this.membreSubmitted = true;
    if (this.membreForm.valid) {
      this.mapMembre();
      if (this.membreId) {
        this.update();
      } else {
        this.save();
      }
    } else {
      this.alertity.error('Veuillez remplir tous les champs obligatoires');
    }
  }

  save(): void {
    this.membreService.add(this.membre).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, membre enregistré avec succès');
        this.router.navigate(['membres']);
      },
    });
  }

  update(): void {
    this.membreService.update(this.membre, this.membreId).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, membre modifié avec succès');
        this.router.navigate(['membres']);
      },
    });
  }

  mapMembre(): void {
    this.membre.nom = this.nom.value;
    this.membre.prenom = this.prenom.value;
    this.membre.sexeId = this.sexe.value;
    this.membre.agenceId = this.agence.value;
    this.membre.serviceId = this.service.value;
    this.membre.dateAdhesion = this.dateAdhesion.value;
    this.membre.email = this.email.value;
    this.membre.telephone = this.telephone.value;
  }

}
