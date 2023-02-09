import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CompteComptable } from 'src/app/model/comptecomptable';
import { CompteComptableService } from 'src/app/services/compte-comptable.service';
import { LoaderService } from 'src/app/services/loader.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-compte-comptable',
  templateUrl: './compte-comptable.component.html',
  styleUrls: ['./compte-comptable.component.scss'],
})
export class CompteComptableComponent implements OnInit {
  compte!: CompteComptable;
  compteId!: number;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private compteComptableService: CompteComptableService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    this.compteId = this.route.snapshot.params['id'];
    if (this.compteId) {
      this.loaderService.show();
      this.compteComptableService.getById(this.compteId).subscribe((data) => {
        this.loaderService.hide();
        this.compte = data;
      });
    }
  }

  onDelete(): void {
    Swal.fire({
      title: 'Êtes-vous sûr de vouloir supprimer ce compte comptable?',
      text: 'Vous ne pourrez pas revenir en arrière !',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      cancelButtonText: 'Annuler',
      confirmButtonText: 'Oui, supprimez-le !',
    }).then((result) => {
      if (result.isConfirmed) {
        this.compteComptableService.deleteSexe(this.compteId).subscribe({
          next: () => {
            Swal.fire({
              icon: 'success',
              title: 'Compte comptable supprimé avec succès !',
              showConfirmButton: false,
              timer: 1500,
            });
            this.router.navigate(['home/plan-comptable']);
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
    this.router.navigate(['home/plan-comptable/update/', this.compteId]);
  }
}
