import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Sexe } from 'src/app/model/sexe';
import { AlertifyService } from 'src/app/services/alertify.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-add-sexe',
  templateUrl: './add-sexe.component.html',
  styleUrls: ['./add-sexe.component.scss']
})
export class AddSexeComponent implements OnInit {

  sexeId?: number;
  sexe: Sexe = {};
  sexeForm!: FormGroup;
  sexeSubmitted: boolean = false;
  titreFormulaire: string = "Ajout d'un sexe";

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private sexeService: SexeService,
    private alertity: AlertifyService
  ) {}

  ngOnInit(): void {
    this.sexeId = +this.route.snapshot.params['id'];
    if (this.sexeId) {
      this.titreFormulaire = "Modification d'un sexe";
      this.sexeService.getById(this.sexeId).subscribe({
        next: (data) => {
          this.sexe = data;
        },
        error: (error) => {
          this.router.navigate(['sexes']);
        },
      });
    }

    this.createsexeForm();
  }

  createsexeForm() {
    this.sexeForm = this.fb.group({
      nom: [null, Validators.required],
    });
  }

  //-------------------------------------
  // Getter methos for all form controls
  //-------------------------------------
  get nom() {
    return this.sexeForm.get('nom') as FormControl;
  }

  //---------------------------------------------------

  onSubmit() {
    this.sexeSubmitted = true;
    if (this.sexeForm.valid) {
      this.mapsexe();
      if (this.sexeId) {
        this.update();
      } else {
        this.save();
      }
    } else {
      this.alertity.error('Veuillez remplir tous les champs obligatoires');
    }
  }

  save(): void {
    this.sexeService.add(this.sexe).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, sexe enregistré avec succès');
        this.router.navigate(['sexes']);
      },
    });
  }

  update(): void {
    this.sexeService.update(this.sexe, this.sexeId).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, sexe modifié avec succès');
        this.router.navigate(['sexes']);
      },
    });
  }

  mapsexe(): void {
    this.sexe.nom = this.nom.value;
  }

}
