import { Component, OnInit } from '@angular/core';
import { Action } from 'src/app/model/action';
import { InfosPage } from 'src/app/model/infosPage';

@Component({
  selector: 'app-poste-page',
  templateUrl: './poste-page.component.html',
  styleUrls: ['./poste-page.component.scss'],
})
export class PostePageComponent implements OnInit {
  infosPage: InfosPage = {
    title: 'Gestion des postes',
    url: 'home/postes',
  };

  actions: Action[] = [
    {
      title: 'Nouveau',
      url: 'home/postes/add',
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
