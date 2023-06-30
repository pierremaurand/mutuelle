import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Membre } from 'src/app/model/Membre';
import { Avance } from 'src/app/model/avance';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';
import { InfosAvance } from 'src/app/model/infosAvance';
import { AvanceService } from 'src/app/services/avance.service';
import { MembreService } from 'src/app/services/membre.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-detail-echeance-avance',
  templateUrl: './detail-echeance-avance.component.html',
  styleUrls: ['./detail-echeance-avance.component.scss'],
})
export class DetailEcheanceAvanceComponent implements OnInit {
  @Input()
  echeance: EcheanceAvance = new EcheanceAvance();
  @Output()
  echeanceChoisie = new EventEmitter<EcheanceAvance>();
  avance: Avance = new Avance();
  solde: number = 0;
  status: string = '';
  membre: Membre = new Membre();
  imagesUrl = environment.imagesUrl;

  constructor(
    private avanceService: AvanceService,
    private membreService: MembreService
  ) {}

  ngOnInit(): void {
    if (this.echeance.avanceId) {
      this.avanceService
        .getInfosAvance(this.echeance.avanceId)
        .subscribe((infos: InfosAvance) => {
          this.solde = infos.solde;
          this.status = infos.status;
        });
      this.avanceService
        .getById(this.echeance.avanceId)
        .subscribe((avance: Avance) => {
          this.avance = avance;
          this.membreService
            .getById(avance.membreId)
            .subscribe((membre: Membre) => {
              this.membre = membre;
            });
        });
    }
  }

  sendEcheance(): void {
    this.echeanceChoisie.emit(this.echeance);
  }
}
