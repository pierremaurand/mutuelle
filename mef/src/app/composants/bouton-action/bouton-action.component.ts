import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Cotisation } from 'src/app/model/cotisation';

@Component({
  selector: 'app-bouton-action',
  templateUrl: './bouton-action.component.html',
  styleUrls: ['./bouton-action.component.scss']
})
export class BoutonActionComponent implements OnInit {
  @Input() action: number = 0;
  @Output() actionChange = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

  clickAction(action:number): void {
    this.action = action;
    this.actionChange.emit(this.action);
  }

}
