import { Component, OnInit } from '@angular/core';
import { Action } from 'src/app/model/action';
import { InfosPage } from 'src/app/model/infosPage';

@Component({
  selector: 'app-credit-page',
  templateUrl: './credit-page.component.html',
  styleUrls: ['./credit-page.component.scss'],
})
export class CreditPageComponent implements OnInit {
  infosPage: InfosPage = {
    title: 'gestion des crédits',
    url: 'home/credits',
  };

  actions: Action[] = [
    {
      title: 'Nouveau',
      url: 'home/credits/add',
      icon: 'fa fa-plus',
      class: 'primary',
    },
    {
      title: 'Importer',
      url: 'home/credits/import',
      icon: 'fa fa-download',
      class: 'success',
    },
  ];

  constructor() {}

  ngOnInit(): void {}
}
