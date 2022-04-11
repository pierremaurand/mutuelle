import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Service } from 'src/app/model/service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { ServiceService } from 'src/app/services/service.service';

@Component({
  selector: 'app-add-service',
  templateUrl: './add-service.component.html',
  styleUrls: ['./add-service.component.scss']
})
export class AddServiceComponent implements OnInit {

  serviceId?: number;
  service: Service = {};
  serviceForm!: FormGroup;
  serviceSubmitted: boolean = false;
  titreFormulaire: string = "Ajout d'un service";

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private serviceService: ServiceService,
    private alertity: AlertifyService
  ) {}

  ngOnInit(): void {
    this.serviceId = +this.route.snapshot.params['id'];
    if (this.serviceId) {
      this.titreFormulaire = "Modification d'un sexe";
      this.serviceService.getById(this.serviceId).subscribe({
        next: (data) => {
          this.service = data;
        },
        error: (error) => {
          this.router.navigate(['services']);
        },
      });
    }

    this.createserviceForm();
  }

  createserviceForm() {
    this.serviceForm = this.fb.group({
      nom: [null, Validators.required],
    });
  }

  //-------------------------------------
  // Getter methos for all form controls
  //-------------------------------------
  get nom() {
    return this.serviceForm.get('nom') as FormControl;
  }

  //---------------------------------------------------

  onSubmit() {
    this.serviceSubmitted = true;
    if (this.serviceForm.valid) {
      this.mapservice();
      if (this.serviceId) {
        this.update();
      } else {
        this.save();
      }
    } else {
      this.alertity.error('Veuillez remplir tous les champs obligatoires');
    }
  }

  save(): void {
    this.serviceService.add(this.service).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, service enregistré avec succès');
        this.router.navigate(['services']);
      },
    });
  }

  update(): void {
    this.serviceService.update(this.service, this.serviceId).subscribe({
      next: (data: any) => {
        this.alertity.success('Félécitation, service modifié avec succès');
        this.router.navigate(['services']);
      },
    });
  }

  mapservice(): void {
    this.service.nom = this.nom.value;
  }

}
