import { Component, OnInit } from '@angular/core';
import { Action } from 'src/app/model/action';
import { InfosPage } from 'src/app/model/infosPage';

@Component({
  selector: 'app-membre-page',
  templateUrl: './membre-page.component.html',
  styleUrls: ['./membre-page.component.scss'],
})
export class MembrePageComponent implements OnInit {
  infosPage: InfosPage = {
    title: 'Gestion des membres',
    url: 'home/membres',
  };

  actions: Action[] = [
    {
      title: 'Nouveau',
      url: 'home/membres/add',
      icon: 'fa fa-plus',
      class: 'primary',
    },
    {
      title: 'Importer',
      url: 'home/membres/import',
      icon: 'fa fa-download',
      class: 'success',
    },
  ];

  constructor() {}

  ngOnInit(): void {}
}
