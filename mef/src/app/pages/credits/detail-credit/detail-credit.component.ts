import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Credit } from 'src/app/model/credit';
import { CreditDebourse } from 'src/app/model/creditDebourse';
import { InfosCredit } from 'src/app/model/infosCredit';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { Mouvement } from 'src/app/model/mouvement';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { CreditService } from 'src/app/services/credit.service';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-detail-credit',
  templateUrl: './detail-credit.component.html',
  styleUrls: ['./detail-credit.component.scss'],
})
export class DetailCreditComponent implements OnInit {
  @Input()
  creditId: number = 0;
  credit: Credit = new Credit();
  membre: Membre = new Membre();
  creditDebourse: CreditDebourse = new CreditDebourse();
  solde: number = 0;
  status: string = 'Enregistré';
  mouvements: Mouvement[] = [];

  constructor(
    private membreService: MembreService,
    private creditService: CreditService
  ) {}

  ngOnInit(): void {
    this.creditService.getById(this.creditId).subscribe((credit: Credit) => {
      this.credit = credit;
      this.membreService
        .getById(credit.membreId)
        .subscribe((membre: Membre) => {
          this.membre = membre;
          this.creditService
            .getInfosCredit(credit.id)
            .subscribe((infos: InfosCredit) => {
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
