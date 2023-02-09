import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Action } from 'src/app/model/action';
import { InfosPage } from 'src/app/model/infosPage';

@Component({
  selector: 'app-bouton-action',
  templateUrl: './bouton-action.component.html',
  styleUrls: ['./bouton-action.component.scss'],
})
export class BoutonActionComponent implements OnInit {
  @Input() actions?: Action[];
  @Input() infosPage?: InfosPage;

  constructor() {}

  ngOnInit(): void {}
}
