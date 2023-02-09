import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Membre } from 'src/app/model/Membre';
import { LoaderService } from 'src/app/services/loader.service';
import { MembreService } from 'src/app/services/membre.service';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-membre',
  templateUrl: './membre.component.html',
  styleUrls: ['./membre.component.scss'],
})
export class MembreComponent implements OnInit {
  imagesUrl = environment.imagesUrl;
  membre!: Membre;
  membreId!: number;
  actifBtnLabel: string = 'Désactiver';

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private membreService: MembreService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    (this.membreId = this.route.snapshot.params['id']), this.loadInfosMembre();
  }

  loadInfosMembre(): void {
    if (this.membreId) {
      this.loaderService.show();
      this.membreService.getById(this.membreId).subscribe((data) => {
        this.loaderService.hide();
        (this.membre = data),
          (this.membre.photoUrl = this.membreService.getPhotoUrl(this.membre)),
          (this.actifBtnLabel = this.membre.estActif
            ? 'Désactiver'
            : 'Activer');
      });
    }
  }

  onDelete(): void {
    Swal.fire({
      title: 'Êtes-vous sûr de vouloir supprimer ce membre?',
      text: 'Vous ne pourrez pas revenir en arrière !',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      cancelButtonText: 'Annuler',
      confirmButtonText: 'Oui, supprimez-le !',
    }).then((result) => {
      if (result.isConfirmed) {
        this.membreService.deleteMembre(this.membreId).subscribe({
          next: () => {
            Swal.fire({
              icon: 'success',
              title: 'Membre supprimé avec succès !',
              showConfirmButton: false,
              timer: 1500,
            });
            this.router.navigate(['home/membres']);
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
    this.router.navigate(['home/membres/update/', this.membreId]);
  }

  onImageChange(): void {
    this.router.navigate(['home/membres/add-image/', this.membreId]);
  }

  onActivateToggle(): void {
    this.membre.estActif = !this.membre.estActif;
    this.membreService.update(this.membre, this.membreId).subscribe(() => {
      Swal.fire({
        icon: 'success',
        title: 'Membre modifié avec succès !',
        showConfirmButton: false,
        timer: 1500,
      }),
        this.loadInfosMembre();
    });
  }
}
