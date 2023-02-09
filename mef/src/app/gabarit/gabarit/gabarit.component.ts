import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CompteComptable } from 'src/app/model/comptecomptable';
import { Gabarit } from 'src/app/model/gabarit';
import { CompteComptableService } from 'src/app/services/compte-comptable.service';
import { GabaritService } from 'src/app/services/gabarit.service';
import { LoaderService } from 'src/app/services/loader.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-gabarit',
  templateUrl: './gabarit.component.html',
  styleUrls: ['./gabarit.component.scss'],
})
export class GabaritComponent implements OnInit {
  gabarit!: Gabarit;
  gabaritId!: number;
  compteComptables: CompteComptable[] = [];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private gabaritService: GabaritService,
    private loaderService: LoaderService,
    private compteComptableService: CompteComptableService
  ) {}

  ngOnInit(): void {
    this.gabaritId = this.route.snapshot.params['id'];
    if (this.gabaritId) {
      this.loaderService.show();
      this.gabaritService.getById(this.gabaritId).subscribe((data) => {
        this.loaderService.hide();
        (this.gabarit = data),
          this.compteComptableService.getAll().subscribe((data) => {
            (this.compteComptables = data),
              this.gabarit.operations.map((o, i) => {
                this.gabarit.operations[i].tOperation =
                  this.gabaritService.getTypeOperation(o.typeOperation);
                this.gabarit.operations[i].compte =
                  this.gabaritService.getCompte(
                    o.compteComptableId,
                    this.compteComptables
                  );
              });
          });
      });
    }
  }

  onDelete(): void {
    Swal.fire({
      title: 'Êtes-vous sûr de vouloir supprimer ce gabarit?',
      text: 'Vous ne pourrez pas revenir en arrière !',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      cancelButtonText: 'Annuler',
      confirmButtonText: 'Oui, supprimez-le !',
    }).then((result) => {
      if (result.isConfirmed) {
        this.gabaritService.deleteGabarit(this.gabaritId).subscribe({
          next: () => {
            Swal.fire({
              icon: 'success',
              title: 'Gabarit supprimé avec succès !',
              showConfirmButton: false,
              timer: 1500,
            });
            this.router.navigate(['home/gabarits']);
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
    this.router.navigate(['home/gabarits/update/', this.gabaritId]);
  }
}
