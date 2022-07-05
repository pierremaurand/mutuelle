import { Component, OnInit } from '@angular/core';
import { Credit } from 'src/app/model/credit';
import { EcheanceCredit } from 'src/app/model/echeanceCredit';
import { AlertifyService } from 'src/app/services/alertify.service';
import { CreditService } from 'src/app/services/credit.service';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-credit-page',
  templateUrl: './credit-page.component.html',
  styleUrls: ['./credit-page.component.scss']
})
export class CreditPageComponent implements OnInit {
  action: number = 0;
  membreId: number = 0;
  credits: Credit[] = [];
  echeances: EcheanceCredit[] = [];
  credit: Credit = new Credit();

  constructor(
    private creditService: CreditService,
    private alertify: AlertifyService,
    private membreService: MembreService
  ) { }

  ngOnInit(): void {
    if(localStorage.getItem('MembreId')) {
      this.membreId = +(localStorage.getItem('MembreId')||'');
      this.loadCredits();
    }
  }

  clickAction(): void {
    if(this.action === 1 || this.action === 4 || this.action === 7) {
      this.credit = new Credit();
    }
    if(this.action === 3) {
      this.saveCredit();
    }
    if(this.action === 5) {
      this.addChange();
    }
    if(this.action === 7) {
      this.echeances.length = 0;
    }
    if(this.action === 9) {
      this.deleteCredit();
    }
  }

  loadCredits(): void {
    if (this.membreId) {
      this.creditService.getAllMembreCredit(this.membreId).subscribe({
        next: (data) => {
          this.credits = data;
        },
      });
    }
  }

  saveCredit(): void {
    if(this.credit.id === null) {
      this.membreService.addCreditMembre(this.credit.id,this.membreId).subscribe({
        next: (data: any) => {
          this.loadCredits();
          this.credit = new Credit();
          this.alertify.success(
            'Félécitation, le crédit a été enregistrée avec succès'
          );
        },
      });
    }
  }

}
