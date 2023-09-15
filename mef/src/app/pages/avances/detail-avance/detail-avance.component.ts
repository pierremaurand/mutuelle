import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Avance } from 'src/app/model/avance';
import { AvanceDebourse } from 'src/app/model/avanceDebourse';
import { InfosAvance } from 'src/app/model/infosAvance';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { Mouvement } from 'src/app/model/mouvement';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { AvanceService } from 'src/app/services/avance.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-detail-avance',
  templateUrl: './detail-avance.component.html',
  styleUrls: ['./detail-avance.component.scss'],
})
export class DetailAvanceComponent implements OnInit {
  @Input()
  avanceId: number = 0;
  avance: Avance = new Avance();
  membre: Membre = new Membre();
  avanceDebourse: AvanceDebourse = new AvanceDebourse();
  solde: number = 0;
  status: string = 'Enregistré';
  mouvements: Mouvement[] = [];

  constructor(
    private membreService: MembreService,
    private avanceService: AvanceService
  ) {}

  ngOnInit(): void {
    this.avanceService.getById(this.avanceId).subscribe((avance: Avance) => {
      this.avance = avance;
      this.membreService
        .getById(avance.membreId)
        .subscribe((membre: Membre) => {
          this.membre = membre;
          this.avanceService
            .getInfosAvance(avance.id)
            .subscribe((infos: InfosAvance) => {
              this.solde = infos.solde;
              this.status = infos.status;
            });
        });
    });
  }

  calculSolde(): number {
    var solde = 0;
    this.mouvements.forEach((x) => {
      if (x.montant) {
        if (x.typeOperation == 0) {
          solde -= x.montant;
        } else {
          solde += x.montant;
        }
      }
    });
    return solde;
  }
}
