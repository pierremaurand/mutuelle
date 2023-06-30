import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Membre } from 'src/app/model/Membre';
import { Credit } from 'src/app/model/credit';
import { EcheanceCredit } from 'src/app/model/echeanceCredit';
import { InfosCredit } from 'src/app/model/infosCredit';
import { CreditService } from 'src/app/services/credit.service';
import { MembreService } from 'src/app/services/membre.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-detail-echeance-credit',
  templateUrl: './detail-echeance-credit.component.html',
  styleUrls: ['./detail-echeance-credit.component.scss'],
})
export class DetailEcheanceCreditComponent implements OnInit {
  @Input()
  echeance: EcheanceCredit = new EcheanceCredit();
  @Output()
  echeanceChoisie = new EventEmitter<EcheanceCredit>();
  credit: Credit = new Credit();
  solde: number = 0;
  status: string = '';
  membre: Membre = new Membre();
  imagesUrl = environment.imagesUrl;

  constructor(
    private creditService: CreditService,
    private membreService: MembreService
  ) {}

  ngOnInit(): void {
    if (this.echeance.creditId) {
      this.creditService
        .getInfosCredit(this.echeance.creditId)
        .subscribe((infos: InfosCredit) => {
          this.solde = infos.solde;
          this.status = infos.status;
        });
      this.creditService
        .getById(this.echeance.creditId)
        .subscribe((credit: Credit) => {
          this.credit = credit;
          this.membreService
            .getById(credit.membreId)
            .subscribe((membre: Membre) => {
              this.membre = membre;
            });
        });
    }
  }

  sendEcheance(): void {
    this.echeanceChoisie.emit(this.echeance);
  }

  montantEcheance(): number {
    let total = (this.echeance.capital ?? 0) + (this.echeance.interet ?? 0);
    return total;
  }
}
