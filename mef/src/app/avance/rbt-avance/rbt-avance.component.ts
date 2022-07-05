import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Avance } from 'src/app/model/avance';
import { EcheanceAvance } from 'src/app/model/echeanceAvance';

@Component({
  selector: 'app-rbt-avance',
  templateUrl: './rbt-avance.component.html',
  styleUrls: ['./rbt-avance.component.scss']
})
export class RbtAvanceComponent implements OnInit {
  @Input() action: number = 0;
  @Output() actionChange = new EventEmitter<number>();
  @Input() avance: Avance = new Avance();
  echeance!: EcheanceAvance;
  @Input() echeances: EcheanceAvance[] = [];
  @Output() echeancesChange = new EventEmitter<EcheanceAvance[]>();


  constructor() { }

  ngOnInit(): void {
  }

  clickAction(action:number): void {
    this.action = action;
    this.actionChange.emit(this.action);
  }

  onSubmit(): void {
    this.echeancesChange.emit(this.echeances);
  }

  toggleCheck(): void {
    let pos = this.echeances.indexOf(this.echeance);
    if(pos!=-1) {
      this.echeances.splice(pos,1);
    } else {
      this.echeances.push(this.echeance);
    }
  }

  annuler(): void {
    this.echeances.length = 0;
    this.echeancesChange.emit(this.echeances);
    //this.avanceChange.emit(this.avance);
    //this.modalClose.click();
  }


}
