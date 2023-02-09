import { Component, OnInit } from '@angular/core';
import { Action } from 'src/app/model/action';
import { InfosPage } from 'src/app/model/infosPage';

@Component({
  selector: 'app-compte-page',
  templateUrl: './compte-page.component.html',
  styleUrls: ['./compte-page.component.scss'],
})
export class ComptePageComponent implements OnInit {
  infosPage: InfosPage = {
    title: 'gestion des comptes',
    url: 'home/comptes',
  };

  actions: Action[] = [
    {
      title: 'Nouveau',
      url: 'home/comptes/add',
      icon: 'fa fa-plus',
      class: 'primary',
    },
  ];

  constructor() {}

  ngOnInit(): void {}
}
