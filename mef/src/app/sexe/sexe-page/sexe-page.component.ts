import { Component, OnInit } from '@angular/core';
import { Action } from 'src/app/model/action';
import { InfosPage } from 'src/app/model/infosPage';

@Component({
  selector: 'app-sexe-page',
  templateUrl: './sexe-page.component.html',
  styleUrls: ['./sexe-page.component.scss'],
})
export class SexePageComponent implements OnInit {
  infosPage: InfosPage = {
    title: 'Gestion des sexes',
    url: 'home/sexes',
  };

  actions: Action[] = [
    {
      title: 'Nouveau',
      url: 'home/sexes/add',
      icon: 'fa fa-plus',
      class: 'primary',
    },
    {
      title: 'Importer',
      url: 'home/membres/import',
      icon: 'fa fa-download',
      class: 'success',
    },
    {
      title: 'Exporter',
      url: 'home/membres/export',
      icon: 'fa fa-upload',
      class: 'info',
    },
    {
      title: 'Imprimer',
      url: 'home/membres/print',
      icon: 'fa fa-print',
      class: 'warning',
    },
  ];

  constructor() {}

  ngOnInit(): void {}
}
