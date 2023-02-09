import { Component, OnInit } from '@angular/core';
import { Action } from 'src/app/model/action';
import { InfosPage } from 'src/app/model/infosPage';

@Component({
  selector: 'app-cotisation-page',
  templateUrl: './cotisation-page.component.html',
  styleUrls: ['./cotisation-page.component.scss'],
})
export class CotisationPageComponent implements OnInit {
  infosPage: InfosPage = {
    title: 'Gestion des Cotisations',
    url: 'home/cotisations',
  };

  actions: Action[] = [
    {
      title: 'Nouveau',
      url: 'home/cotisations/add',
      icon: 'fa fa-plus',
      class: 'primary',
    },
    {
      title: 'Importer',
      url: 'home/cotisations/import',
      icon: 'fa fa-download',
      class: 'success',
    },
  ];

  constructor() {}

  ngOnInit(): void {}
}
