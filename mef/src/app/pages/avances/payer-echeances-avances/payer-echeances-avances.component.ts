import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';
import { InfosRemboursements } from 'src/app/model/infosRemboursements';
import { AvanceService } from 'src/app/services/avance.service';

@Component({
  selector: 'app-payer-echeances-avances',
  templateUrl: './payer-echeances-avances.component.html',
  styleUrls: ['./payer-echeances-avances.component.scss'],
})
export class PayerEcheancesAvancesComponent implements OnInit {
  @Input()
  echeancier: EcheanceAvance[] = [];
  dateMouvement: string = '';
  @Output()
  echeancesPayer = new EventEmitter();

  constructor(private avanceService: AvanceService) {}

  ngOnInit(): void {}

  total(): number {
    let total = 0;
    this.echeancier.forEach((e) => {
      if (e.montantEcheance) {
        total += e.montantEcheance;
      }
    });

    return total;
  }

  enregistrer(): void {
    const infos = new InfosRemboursements();
    infos.dateMouvement = this.dateMouvement;
    infos.echeancier = this.echeancier;
    this.avanceService.rembourserEcheances(infos).subscribe(() => {
      this.echeancesPayer.emit();
    });
  }
}
