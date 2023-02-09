import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Sexe } from 'src/app/model/sexe';
import { AlertifyService } from 'src/app/services/alertify.service';
import { SexeService } from 'src/app/services/sexe.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-sexe',
  templateUrl: './add-sexe.component.html',
  styleUrls: ['./add-sexe.component.scss'],
})
export class AddSexeComponent implements OnInit {
  sexe: Sexe = new Sexe();

  constructor(
    private alertify: AlertifyService,
    private router: Router,
    private sexeService: SexeService
  ) {}

  ngOnInit(): void {}

  onSubmit(sexeForm: NgForm): void {
    if (sexeForm.valid) {
      this.sexeService.add(this.sexe).subscribe(() => {
        Swal.fire({
          icon: 'success',
          title: 'Sexe ajouté avec succès !',
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
    this.router.navigate(['home/sexes']);
  }
}
