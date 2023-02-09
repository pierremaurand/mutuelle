import { Component, OnInit } from '@angular/core';
import { Action } from 'src/app/model/action';
import { InfosPage } from 'src/app/model/infosPage';

@Component({
  selector: 'app-gabarit-page',
  templateUrl: './gabarit-page.component.html',
  styleUrls: ['./gabarit-page.component.scss'],
})
export class GabaritPageComponent implements OnInit {
  infosPage: InfosPage = {
    title: 'Gestion des gabarits',
    url: 'home/gabarits',
  };

  actions: Action[] = [
    {
      title: 'Nouveau',
      url: 'home/gabarits/add',
      icon: 'fa fa-plus',
      class: 'primary',
    },
    {
      title: 'Importer',
      url: 'home/gabarits/import',
      icon: 'fa fa-download',
      class: 'success',
    },
    {
      title: 'Exporter',
      url: 'home/gabarits/export',
      icon: 'fa fa-upload',
      class: 'info',
    },
    {
      title: 'Imprimer',
      url: 'home/gabarits/print',
      icon: 'fa fa-print',
      class: 'warning',
    },
  ];

  constructor() {}

  ngOnInit(): void {}
}
