import { Component, OnInit } from '@angular/core';
import { Avance } from 'src/app/model/avance';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AvanceService } from 'src/app/services/avance.service';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-avance-page',
  templateUrl: './avance-page.component.html',
  styleUrls: ['./avance-page.component.scss']
})
export class AvancePageComponent implements OnInit {
  action: number = 0;
  membreId: number = 0;
  avances: Avance[] = [];
  echeances: EcheanceAvance[] = [];
  avance: Avance = new Avance();

  constructor(
    private avanceService: AvanceService,
    private alertify: AlertifyService,
    private membreService: MembreService
  ) { }

  ngOnInit(): void {
    if(localStorage.getItem('MembreId')) {
      this.membreId = +(localStorage.getItem('MembreId')||'');
      this.loadAvances();
    }
  }

  clickAction(): void {
    if(this.action === 1 || this.action === 4 || this.action === 7) {
      this.avance = new Avance();
    }
    if(this.action === 3) {
      this.saveAvance();
    }
    if(this.action === 5) {
      this.addChange();
    }
    if(this.action === 7) {
      this.echeances.length = 0;
    }
    if(this.action === 9) {
      this.deleteAvance();
    }
  }

  loadAvances(): void {
    if (this.membreId) {
      this.avanceService.getAllMembreAvance(this.membreId).subscribe({
        next: (data) => {
          this.avances = data;
        },
      });
    }
  }

  loadAvance(): void {
    if (this.avance.id) {
      this.avanceService.getAvanceById(this.avance.id).subscribe({
        next: (data) => {
          this.avance = data;
        },
      });
    }
  }

  saveAvance(): void {
    if(this.avance.id === null) {
      this.membreService.addAvanceMembre(this.avance,this.membreId).subscribe({
        next: (data: any) => {
          this.loadAvances();
          this.avance = new Avance();
          this.alertify.success(
            'Félécitation, l\'avance a été enregistrée avec succès'
          );
        },
      });
    }
  }

  addChange(): void {
    if(this.echeances.length > 0) {
      this.echeances.forEach(e => {
        let pos = this.avance.echeanceAvances.indexOf(e);
        this.avance.echeanceAvances[pos].estNouveau = true;
      });
      this.echeances.length = 0;
      this.updateAvance();
    }
  }

  saveChanges(avance: Avance): void {
    this.avanceService.updateAvance(avance).subscribe({
      next: (data: any) => {
        //this.avancesChange.emit(this.avances);
        this.alertify.success(
          'Félécitation, les modification apportées à cette avance ont été enregistrées avec succès'
        );
      },
    });
  }

  updateAvance(): void {
    if(this.avance.id) {
      console.log(this.avance);
      this.avanceService.updateAvance(this.avance).subscribe({
        next: (data: any) => {
          this.loadAvances();
          this.loadAvance();
          this.alertify.success(
            'Félécitation, les modification du membre sont enregistrées avec succès'
          );
        },
      });
    }
  }

  deleteAvance(): void {
    var confirmValue = confirm("Voulez-vous vraiment supprimer cette avance");
    if(confirmValue) {
      if(this.avance.id) {
        this.avanceService.deleteAvance(this.avance.id).subscribe({
          next: (data: any) => {
            this.loadAvances();
            this.alertify.success(
              'Félécitation, l\'avance a été supprimer avec succès'
            );
          },
        });
      }
    }
  }

}
