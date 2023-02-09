import { Component, OnInit } from '@angular/core';
import { Menu } from '../model/menu';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  menuProperties: Array<Menu> = [
    {
      id: '1',
      titre: 'Tableau de bord',
      icon: 'fas fa-chart-line',
      url: '',
      sousMenu: [
        {
          id: '11',
          titre: "Vue d'ensemble",
          icon: 'fas fa-chart-pie',
          url: 'home',
        },
        {
          id: '12',
          titre: 'Statistiques',
          icon: 'fas fa-chart-bar',
          url: 'home/statistiques',
        },
      ],
    },
    {
      id: '2',
      titre: 'Membres',
      icon: 'fas fa-users',
      url: 'home/membres',
    },
    {
      id: '3',
      titre: 'Cotisations',
      icon: 'fa fa-coins',
      url: 'home/cotisations',
    },
    {
      id: '4',
      titre: 'Avances',
      icon: 'fab fa-stack-overflow',
      url: 'home/avances',
    },
    {
      id: '5',
      titre: 'Credits',
      icon: 'fa fa-money-check',
      url: 'home/credits',
    },
    {
      id: '7',
      titre: 'Comptes',
      icon: 'fa fa-money-check',
      url: 'home/comptes',
    },
    {
      id: '8',
      titre: 'Comptabilité',
      icon: 'fa fa-money-check',
      url: 'home/comptabilite',
    },
    {
      id: '6',
      titre: 'Paramétrages',
      icon: 'fas fa-cogs',
      url: '',
      sousMenu: [
        {
          id: '61',
          titre: 'Utilisateurs',
          icon: 'fas fa-users-cog',
          url: 'home/utilisateurs',
        },
        {
          id: '62',
          titre: 'Sexes',
          icon: 'fas fa-venus-mars',
          url: 'home/sexes',
        },
        {
          id: '63',
          titre: 'Poste',
          icon: 'fa fa-list',
          url: 'home/postes',
        },
        {
          id: '64',
          titre: 'Plan comptable',
          icon: 'fa fa-map',
          url: 'home/plan-comptable',
        },
        {
          id: '65',
          titre: 'Gabarits',
          icon: 'fa fa-list',
          url: 'home/gabarits',
        },
      ],
    },
  ];
  constructor() {}

  ngOnInit(): void {}
}
