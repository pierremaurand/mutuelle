import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Parametre } from 'src/app/model/parametre';
import { AlertifyService } from 'src/app/services/alertify.service';
import { ParametreService } from 'src/app/services/parametre.service';

@Component({
  selector: 'app-add-parametre',
  templateUrl: './add-parametre.component.html',
  styleUrls: ['./add-parametre.component.scss']
})
export class AddParametreComponent implements OnInit {

  parametreId?: number;
  parametre: Parametre = {};
  parametreForm!: FormGroup;
  parametreSubmitted: boolean = false;
  titreFormulaire: string = "Ajout d'un parametre";

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private parametreService: ParametreService,
    private alertity: AlertifyService
  ) {}

  ngOnInit(): void {
    this.parametreId = +this.route.snapshot.params['id'];
    if (this.parametreId) {
      this.titreFormulaire = "Modification d'un sexe";
      this.parametreService.getById(this.parametreId).subscribe({
        next: (data) => {
          this.parametre = data;
        },
        error: (error) => {
          this.router.navigate(['parametres']);
        },
      });
    }

    this.createparametreForm();
  }

  createparametreForm() {
    this.parametreForm = this.fb.group({
      nom: [null, Validators.required],
      valeur: [null, Validators.required],
    });
  }

  //-------------------------------------
  // Getter methos for all form controls
  //-------------------------------------
  get nom() {
    return this.parametreForm.get('nom') as FormControl;
  }

  get valeur() {
    return this.parametreForm.get('valeur') as FormControl;
  }

  //---------------------------------------------------

  onSubmit() {
    this.parametreSubmitted = true;
    if (this.parametreForm.valid) {
      this.mapparametre();
      if (this.parametreId) {
        this.update();
      } else {
        this.save();
      }
    } else {
      this.alertity.error('Veuillez remplir tous les champs obligatoires');
    }
  }

  save(): void {
    this.parametreService.add(this.parametre).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, parametre enregistré avec succès');
        this.annuler();
      },
    });
  }

  update(): void {
    this.parametreService.update(this.parametre, this.parametreId).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, parametre modifié avec succès');
        this.annuler();
      },
    });
  }

  mapparametre(): void {
    this.parametre.nom = this.nom.value;
    this.parametre.valeur = this.valeur.value;
  }

  annuler() {
    this.router.navigate(['parametres']);
  }

}
