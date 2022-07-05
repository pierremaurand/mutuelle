import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Avance } from 'src/app/model/avance';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-add-avance',
  templateUrl: './add-avance.component.html',
  styleUrls: ['./add-avance.component.scss']
})
export class AddAvanceComponent implements OnInit {
  @Input() action: number = 0;
  @Output() actionChange = new EventEmitter<number>();
  @Input() avance: Avance = new Avance();
  @Output() avanceChange = new EventEmitter<Avance>();
  @ViewChild("closeAvanceFormModal") modalClose:any;

  constructor(
    private alertify: AlertifyService
  ) { }

  ngOnInit(): void {

  }

  onSubmit(avanceForm: NgForm): void {
    if(avanceForm.valid && this.avance.echeanceAvances.length > 0) {
      this.avance.estValide = true;
      this.avanceChange.emit(this.avance);
    } else {
      this.alertify.error('Veuillez remplir tous les champs obligatoires');
    }
  }

  clickAction(action: number): void {
    this.action = action;
    this.actionChange.emit(this.action);
  }

  annuler(): void {

  }

  chargeEcheancier():void {
    let dateDebut = new Date();
    let dateFin = new Date();
    let curDate = new Date();
    let nbrEcheances = 0;
    let montantEcheance: number = 0;
    let reste: number = 0;
    if(this.avance.dateDebut) {
      dateDebut = new Date(this.avance.dateDebut);
    }
    if(this.avance.dateFin) {
      dateFin = new Date(this.avance.dateFin);
    }
    curDate = dateDebut;
    nbrEcheances = ((dateFin.getFullYear()-dateDebut.getFullYear())*12)+(dateFin.getMonth() - dateDebut.getMonth());
    if(this.avance.montant) {
      reste = this.avance.montant % (nbrEcheances+1);
      montantEcheance = Math.floor(this.avance.montant/(nbrEcheances+1));
    }
    for(let i = 0; i<= nbrEcheances; i++) {
      if(curDate.getMonth() == 11) {
        curDate.setFullYear(curDate.getFullYear()+1);
        curDate.setMonth(0);
      } else {
        curDate.setMonth(curDate.getMonth()+1);
      }
      let echeance: EcheanceAvance = {
        dateEcheance: curDate.getFullYear() + '-' + curDate.getMonth(),
        montant: montantEcheance,
        estPaye: false
      }
      if(i===0) {
        echeance.montant = montantEcheance + reste;
      }
      this.avance.echeanceAvances.push(echeance);
    }
  }


}
