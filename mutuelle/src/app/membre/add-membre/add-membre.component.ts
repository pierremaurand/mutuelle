import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Agence } from 'src/app/model/agence';
import { Membre } from 'src/app/model/membre';
import { MembreInfos } from 'src/app/model/membreInfos';
import { Service } from 'src/app/model/service';
import { Sexe } from 'src/app/model/sexe';
import { MembreService } from 'src/app/services/membre.service';

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
  sexes: Sexe[] = [
    {
      id: 1,
      nom: 'Masculin'
    },
    {
      id: 2,
      nom: 'Feminin'
    }
  ];

  agences: Agence[] = [
    {
      id: 1,
      nom: 'Abeché'
    },
    {
      id: 2,
      nom: 'Abena'
    }
  ];

  services: Service[] = [
    {
      id: 1,
      nom: 'Informatique'
    },
    {
      id: 2,
      nom: 'Recouvrement'
    }
  ];

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private membreService: MembreService) { }

  ngOnInit(): void {
    this.membreId = +this.route.snapshot.params['id'];
    this.membre.photo = 'assets/images/default_man.jpg';
    if(this.membreId) {

    }

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

  get dateDeNaissance() {
    return this.membreForm.get('dateDeNaissance') as FormControl;
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
    console.log(this.membreForm.value);
    this.membreSubmitted = true;
    if(this.membreForm.valid) {
      this.router.navigate(['membres']);
    }
  }

}
