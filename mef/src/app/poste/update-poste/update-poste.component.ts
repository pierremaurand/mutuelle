import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Poste } from 'src/app/model/poste';
import { AlertifyService } from 'src/app/services/alertify.service';
import { LoaderService } from 'src/app/services/loader.service';
import { PosteService } from 'src/app/services/poste.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-update-poste',
  templateUrl: './update-poste.component.html',
  styleUrls: ['./update-poste.component.scss'],
})
export class UpdatePosteComponent implements OnInit {
  posteId!: number;
  poste: Poste = new Poste();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private posteService: PosteService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    this.posteId = this.route.snapshot.params['id'];
    if (this.posteId) {
      this.loaderService.show();
      this.posteService.getById(this.posteId).subscribe((data) => {
        this.loaderService.hide();
        this.poste = data;
      });
    }
  }

  onSubmit(posteForm: NgForm): void {
    if (posteForm.valid) {
      this.posteService.update(this.poste, this.posteId).subscribe(() => {
        Swal.fire({
          icon: 'success',
          title: 'Poste modifié avec succès !',
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
    this.router.navigate(['home/postes/show', this.posteId]);
  }
}
