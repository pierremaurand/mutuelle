import { Component, OnInit } from '@angular/core';
import { Cotisation } from 'src/app/model/cotisation';
import { AlertifyService } from 'src/app/services/alertify.service';
import { CotisationService } from 'src/app/services/cotisation.service';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-cotisation-page',
  templateUrl: './cotisation-page.component.html',
  styleUrls: ['./cotisation-page.component.scss']
})
export class CotisationPageComponent implements OnInit {
  action: number = 0;
  membreId: number = 0;
  cotisations: Cotisation[] = [];
  cotisation: Cotisation = new Cotisation();
  selectedCotisation: Cotisation = new Cotisation();

  constructor(
    private cotisationService: CotisationService,
    private membreService: MembreService,
    private alertify: AlertifyService
  ) { }

  ngOnInit(): void {
    if(localStorage.getItem('MembreId')) {
      this.membreId = +(localStorage.getItem('MembreId')||'');
      this.loadCotisations();
    }
  }

  clickAction(): void {
    if(this.action === 1) {
      this.cotisation = new Cotisation();
    }
    if(this.action === 3) {
      this.deleteCotisation();
    }
  }

  deleteCotisation(): void {
    var confirmValue = confirm("Voulez-vous vraiment supprimer cette cotisation");
    if(confirmValue) {
      if(this.cotisation.id) {
        this.cotisationService.deleteCotisation(this.cotisation.id).subscribe({
          next: (data) => {
            this.loadCotisations();
            this.alertify.success(
              'Félécitation, la cotisation a été supprimer avec succès'
            );
          },
        });
      }
    }
  }

  loadCotisations(): void {
    if (this.membreId!=0) {
      this.cotisationService.getAllMembreCotisation(this.membreId).subscribe({
        next: (data) => {
          this.cotisations = data;
        },
      });
    }
  }

  addCotisation(): void {
    if(this.cotisation) {
       this.cotisation.estValide = true;
       this.membreService.addCotisationMembre(this.cotisation,this.membreId).subscribe({
         next: (data: any) => {
           this.loadCotisations();
           this.alertify.success(
             'Félécitation, la cotisation a été enregistrée avec succès'
           );
         },
       });
     }
   }

}
