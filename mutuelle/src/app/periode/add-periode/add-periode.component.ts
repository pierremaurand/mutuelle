import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Periode } from 'src/app/model/periode';
import { AlertifyService } from 'src/app/services/alertify.service';
import { PeriodeService } from 'src/app/services/periode.service';

@Component({
  selector: 'app-add-periode',
  templateUrl: './add-periode.component.html',
  styleUrls: ['./add-periode.component.scss']
})
export class AddPeriodeComponent implements OnInit {

  periodeId?: number;
  periode: Periode = {};
  periodeForm!: FormGroup;
  periodeSubmitted: boolean = false;
  titreFormulaire: string = "Ajout d'un periode";

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private periodeService: PeriodeService,
    private alertity: AlertifyService
  ) {}

  ngOnInit(): void {
    this.periodeId = +this.route.snapshot.params['id'];
    if (this.periodeId) {
      this.titreFormulaire = "Modification d'une période";
      this.periodeService.getById(this.periodeId).subscribe({
        next: (data) => {
          this.periode = data;
        },
        error: (error) => {
          this.router.navigate(['periodes']);
        },
      });
    }

    this.createperiodeForm();
  }

  createperiodeForm() {
    this.periodeForm = this.fb.group({
      libelle: [null, Validators.required]
    });
  }

  //-------------------------------------
  // Getter methos for all form controls
  //-------------------------------------

  get libelle() {
    return this.periodeForm.get('libelle') as FormControl;
  }

  //---------------------------------------------------

  onSubmit() {
    this.periodeSubmitted = true;
    if (this.periodeForm.valid) {
      this.mapperiode();
      if (this.periodeId) {
        this.update();
      } else {
        this.save();
      }
    } else {
      this.alertity.error('Veuillez remplir tous les champs obligatoires');
    }
  }

  save(): void {
    this.periodeService.add(this.periode).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, periode enregistré avec succès');
        this.annuler();
      },
    });
  }

  update(): void {
    this.periodeService.update(this.periode, this.periodeId).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, periode modifié avec succès');
        this.annuler();
      },
    });
  }

  mapperiode(): void {
    this.periode.libelle = this.libelle.value;
  }

  annuler() {
    this.router.navigate(['periodes']);
  }

}
