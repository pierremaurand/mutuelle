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
  @Input() avance: Avance = {};
  @Output() avanceChange = new EventEmitter<Avance>();
  @Input() echeanceAvance: EcheanceAvance[] = [];
  @Output() echeanceAvanceChange = new EventEmitter<EcheanceAvance[]>();
  @ViewChild("closeAvanceFormModal") modalClose:any;

  constructor(
    private alertity: AlertifyService
  ) { }

  ngOnInit(): void {

  }

  onSubmit(avanceForm: NgForm): void {
    if(avanceForm.valid) {
      //this.avance.echeances = this.echeances;
      this.avanceChange.emit(this.avance);
      this.modalClose.nativeElement.click();
    } else {
      this.alertity.error('Veuillez remplir tous les champs obligatoires');
    }
  }

  annuler(): void {

  }

  chargeEcheancier():void {
    if(!this.avance.id){
      this.echeanceAvance = [];
    }
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
    console.log(curDate.getMonth());
    if(this.avance.montant) {
      montantEcheance = this.avance.montant/(nbrEcheances+1);
      reste = this.avance.montant - (montantEcheance*(nbrEcheances+1));
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
      console.log(echeance);
      this.echeanceAvance.push(echeance);
    }
  }

  payCheck(i: number): void {
    this.echeanceAvance[i].estPaye = true;
  }

}
