import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { EcheanceCredit } from 'src/app/model/echeanceCredit';
import { InfosRemboursements } from 'src/app/model/infosRemboursements';
import { CreditService } from 'src/app/services/credit.service';

@Component({
  selector: 'app-payer-echeances-credits',
  templateUrl: './payer-echeances-credits.component.html',
  styleUrls: ['./payer-echeances-credits.component.scss'],
})
export class PayerEcheancesCreditsComponent implements OnInit {
  @Input()
  echeancier: EcheanceCredit[] = [];
  dateMouvement: string = '';
  @Output()
  echeancesPayer = new EventEmitter();

  constructor(private creditService: CreditService) {}

  ngOnInit(): void {}

  totalCapital(): number {
    let total = 0;
    this.echeancier.forEach((e) => {
      if (e.capital) {
        total += e.capital;
      }
    });

    return total;
  }

  totalInteret(): number {
    let total = 0;
    this.echeancier.forEach((e) => {
      if (e.interet) {
        total += e.interet;
      }
    });

    return total;
  }

  enregistrer(): void {
    const infos = new InfosRemboursements();
    infos.dateMouvement = this.dateMouvement;
    infos.echeancier = this.echeancier;
    this.creditService.rembourserEcheances(infos).subscribe(() => {
      this.echeancesPayer.emit();
    });
  }
}
