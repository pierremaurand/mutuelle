import { Component, OnInit } from '@angular/core';
import { Action } from 'src/app/model/action';
import { InfosPage } from 'src/app/model/infosPage';

@Component({
  selector: 'app-compte-comptable-page',
  templateUrl: './compte-comptable-page.component.html',
  styleUrls: ['./compte-comptable-page.component.scss'],
})
export class CompteComptablePageComponent implements OnInit {
  infosPage: InfosPage = {
    title: 'Plan comptable',
    url: 'home/plan-comptable',
  };

  actions: Action[] = [
    {
      title: 'Nouveau',
      url: 'home/plan-comptable/add',
      icon: 'fa fa-plus',
      class: 'primary',
    },
    {
      title: 'Importer',
      url: 'home/plan-comptable/import',
      icon: 'fa fa-download',
      class: 'success',
    },
    {
      title: 'Exporter',
      url: 'home/plan-comptable/export',
      icon: 'fa fa-upload',
      class: 'info',
    },
    {
      title: 'Imprimer',
      url: 'home/plan-comptable/print',
      icon: 'fa fa-print',
      class: 'warning',
    },
  ];

  constructor() {}

  ngOnInit(): void {}
}
