import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Poste } from 'src/app/model/poste';
import { LoaderService } from 'src/app/services/loader.service';
import { PosteService } from 'src/app/services/poste.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-poste',
  templateUrl: './poste.component.html',
  styleUrls: ['./poste.component.scss'],
})
export class PosteComponent implements OnInit {
  poste!: Poste;
  posteId!: number;

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

  onDelete(): void {
    Swal.fire({
      title: 'Êtes-vous sûr de vouloir supprimer ce poste?',
      text: 'Vous ne pourrez pas revenir en arrière !',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      cancelButtonText: 'Annuler',
      confirmButtonText: 'Oui, supprimez-le !',
    }).then((result) => {
      if (result.isConfirmed) {
        this.posteService.deletePoste(this.posteId).subscribe({
          next: () => {
            Swal.fire({
              icon: 'success',
              title: 'Poste supprimé avec succès !',
              showConfirmButton: false,
              timer: 1500,
            });
            this.router.navigate(['home/postes']);
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
    this.router.navigate(['home/postes/update/', this.posteId]);
  }
}
