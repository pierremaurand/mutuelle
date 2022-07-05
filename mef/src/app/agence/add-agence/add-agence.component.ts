import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Agence } from 'src/app/model/agence';
import { AgenceService } from 'src/app/services/agence.service';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-add-agence',
  templateUrl: './add-agence.component.html',
  styleUrls: ['./add-agence.component.scss'],
})
export class AddAgenceComponent implements OnInit {
  agenceId?: number;
  agence: Agence = {};
  agenceForm!: FormGroup;
  agenceSubmitted: boolean = false;
  titreFormulaire: string = "Ajout d'une agence";

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private agenceService: AgenceService,
    private alertity: AlertifyService
  ) {}

  ngOnInit(): void {
    this.agenceId = +this.route.snapshot.params['id'];
    if (this.agenceId) {
      this.titreFormulaire = "Modification d'une agence";
      this.agenceService.getById(this.agenceId).subscribe({
        next: (data) => {
          this.agence = data;
        },
        error: (error) => {
          this.router.navigate(['agences']);
        },
      });
    }

    this.createAgenceForm();
  }

  createAgenceForm() {
    this.agenceForm = this.fb.group({
      nom: [null, Validators.required],
    });
  }

  //-------------------------------------
  // Getter methos for all form controls
  //-------------------------------------
  get nom() {
    return this.agenceForm.get('nom') as FormControl;
  }

  //---------------------------------------------------

  onSubmit() {
    this.agenceSubmitted = true;
    if (this.agenceForm.valid) {
      this.mapAgence();
      if (this.agenceId) {
        this.update();
      } else {
        this.save();
      }
    } else {
      this.alertity.error('Veuillez remplir tous les champs obligatoires');
    }
  }

  save(): void {
    this.agenceService.add(this.agence).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, agence enregistré avec succès');
        this.router.navigate(['agences']);
      },
    });
  }

  update(): void {
    this.agenceService.update(this.agence, this.agenceId).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, agence modifié avec succès');
        this.router.navigate(['agences']);
      },
    });
  }

  mapAgence(): void {
    this.agence.nom = this.nom.value;
  }
}
