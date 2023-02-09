import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Poste } from 'src/app/model/poste';
import { AlertifyService } from 'src/app/services/alertify.service';
import { PosteService } from 'src/app/services/poste.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-poste',
  templateUrl: './add-poste.component.html',
  styleUrls: ['./add-poste.component.scss'],
})
export class AddPosteComponent implements OnInit {
  poste: Poste = new Poste();

  constructor(
    private alertify: AlertifyService,
    private router: Router,
    private posteService: PosteService
  ) {}

  ngOnInit(): void {}

  onSubmit(posteForm: NgForm): void {
    if (posteForm.valid) {
      this.posteService.add(this.poste).subscribe(() => {
        Swal.fire({
          icon: 'success',
          title: 'Poste ajouté avec succès !',
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
    this.router.navigate(['home/postes']);
  }
}
