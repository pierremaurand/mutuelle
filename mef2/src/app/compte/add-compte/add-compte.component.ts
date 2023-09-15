import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Membre } from 'src/app/model/Membre';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-compte',
  templateUrl: './add-compte.component.html',
  styleUrls: ['./add-compte.component.scss'],
})
export class AddCompteComponent implements OnInit {
  membre: Membre = new Membre();

  constructor(private router: Router) {}

  ngOnInit(): void {}

  onSubmit(gabaritForm: NgForm): void {
    if (gabaritForm.valid) {
      // this.gabaritService.add(this.gabarit).subscribe(() => {
      //   Swal.fire({
      //     icon: 'success',
      //     title: 'Gabarit ajouté avec succès !',
      //     showConfirmButton: false,
      //     timer: 1500,
      //   });
      //   this.onCancel();
      // });
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
    this.router.navigate(['home/gabarits']);
  }
}
