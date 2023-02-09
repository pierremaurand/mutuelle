import { Component, OnInit } from '@angular/core';
import { Action } from 'src/app/model/action';
import { InfosPage } from 'src/app/model/infosPage';

@Component({
  selector: 'app-avance-page',
  templateUrl: './avance-page.component.html',
  styleUrls: ['./avance-page.component.scss'],
})
export class AvancePageComponent implements OnInit {
  infosPage: InfosPage = {
    title: 'gestion des avances',
    url: 'home/avances',
  };

  actions: Action[] = [
    {
      title: 'Nouveau',
      url: 'home/avances/add',
      icon: 'fa fa-plus',
      class: 'primary',
    },
    {
      title: 'Importer',
      url: 'home/avances/import',
      icon: 'fa fa-download',
      class: 'success',
    },
  ];
  constructor() {}

  ngOnInit(): void {}
}
