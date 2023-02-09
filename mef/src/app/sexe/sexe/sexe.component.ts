import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Sexe } from 'src/app/model/sexe';
import { LoaderService } from 'src/app/services/loader.service';
import { SexeService } from 'src/app/services/sexe.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-sexe',
  templateUrl: './sexe.component.html',
  styleUrls: ['./sexe.component.scss'],
})
export class SexeComponent implements OnInit {
  sexe!: Sexe;
  sexeId!: number;

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

  onDelete(): void {
    Swal.fire({
      title: 'Êtes-vous sûr de vouloir supprimer ce sexe?',
      text: 'Vous ne pourrez pas revenir en arrière !',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      cancelButtonText: 'Annuler',
      confirmButtonText: 'Oui, supprimez-le !',
    }).then((result) => {
      if (result.isConfirmed) {
        this.sexeService.deleteSexe(this.sexeId).subscribe({
          next: () => {
            Swal.fire({
              icon: 'success',
              title: 'Sexe supprimé avec succès !',
              showConfirmButton: false,
              timer: 1500,
            });
            this.router.navigate(['home/sexes']);
          },
          error: () => {
            Swal.fire({
              icon: 'error',
              title: "Une erreur s'est produite!",
              showConfirmButton: false,
              timer: 1500,
            });
          },
        });
      }
    });
  }

  onUpdate(): void {
    this.router.navigate(['home/sexes/update/', this.sexeId]);
  }
}
