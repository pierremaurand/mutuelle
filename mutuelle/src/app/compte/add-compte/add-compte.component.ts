import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Compte } from 'src/app/model/compte';
import { AlertifyService } from 'src/app/services/alertify.service';
import { CompteService } from 'src/app/services/compte.service';

@Component({
  selector: 'app-add-compte',
  templateUrl: './add-compte.component.html',
  styleUrls: ['./add-compte.component.scss']
})
export class AddCompteComponent implements OnInit {

  compteId?: number;
  compte: Compte = {};
  compteForm!: FormGroup;
  compteSubmitted: boolean = false;
  titreFormulaire: string = "Ajout d'un compte";

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private compteService: CompteService,
    private alertity: AlertifyService
  ) {}

  ngOnInit(): void {
    this.compteId = +this.route.snapshot.params['id'];
    if (this.compteId) {
      this.titreFormulaire = "Modification d'un sexe";
      this.compteService.getById(this.compteId).subscribe({
        next: (data) => {
          this.compte = data;
        },
        error: (error) => {
          this.router.navigate(['comptes']);
        },
      });
    }

    this.createcompteForm();
  }

  createcompteForm() {
    this.compteForm = this.fb.group({
      numero: [null, Validators.required],
      libelle: [null, Validators.required],
    });
  }

  //-------------------------------------
  // Getter methos for all form controls
  //-------------------------------------
  get numero() {
    return this.compteForm.get('numero') as FormControl;
  }

  get libelle() {
    return this.compteForm.get('libelle') as FormControl;
  }

  //---------------------------------------------------

  onSubmit() {
    this.compteSubmitted = true;
    if (this.compteForm.valid) {
      this.mapcompte();
      if (this.compteId) {
        this.update();
      } else {
        this.save();
      }
    } else {
      this.alertity.error('Veuillez remplir tous les champs obligatoires');
    }
  }

  save(): void {
    this.compteService.add(this.compte).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, compte enregistré avec succès');
        this.annuler();
      },
    });
  }

  update(): void {
    this.compteService.update(this.compte, this.compteId).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, compte modifié avec succès');
        this.annuler();
      },
    });
  }

  mapcompte(): void {
    this.compte.numero = this.numero.value;
    this.compte.libelle = this.libelle.value;
  }

  annuler() {
    this.router.navigate(['comptes']);
  }

}
