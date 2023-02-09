import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Sexe } from 'src/app/model/sexe';
import { AlertifyService } from 'src/app/services/alertify.service';
import { LoaderService } from 'src/app/services/loader.service';
import { SexeService } from 'src/app/services/sexe.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-update-sexe',
  templateUrl: './update-sexe.component.html',
  styleUrls: ['./update-sexe.component.scss'],
})
export class UpdateSexeComponent implements OnInit {
  sexeId!: number;
  sexe: Sexe = new Sexe();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private sexeService: SexeService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    this.sexeId = this.route.snapshot.params['id'];
    if (this.sexeId) {
      this.loaderService.show();
      this.sexeService.getById(this.sexeId).subscribe((data) => {
        this.loaderService.hide();
        this.sexe = data;
      });
    }
  }

  onSubmit(sexeForm: NgForm): void {
    if (sexeForm.valid) {
      this.sexeService.update(this.sexe, this.sexeId).subscribe(() => {
        Swal.fire({
          icon: 'success',
          title: 'Sexe modifié avec succès !',
          showConfirmButton: false,
          timer: 1500,
        });
        this.onCancel();
      });
    } else {
      Swal.fire({
        icon: 'error',
        title: 'Veuillez remplir tous les champs obligatoires',
        showConfirmButton: false,
        timer: 1500,
      });
    }
  }

  onCancel(): void {
    this.router.navigate(['home/sexes/show', this.sexeId]);
  }
}
