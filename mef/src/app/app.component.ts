import { Component } from '@angular/core';
import { Menu } from './model/menu';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'angular-app';
  menuProperties: Array<Menu> = [
    {
      id: '1',
      titre: 'Tableau de bord',
      icon: 'fas fa-chart-line',
      url: '',
      sousMenu: [
        {
          id: '11',
          titre: 'Vue d\'ensemble',
          icon: 'fas fa-chart-pie',
          url: 'dashboard'
        },
        {
          id: '12',
          titre: 'Statistiques',
          icon: 'fas fa-chart-bar',
          url: 'statistiques'
        }
      ]
    },
    {
      id: '2',
      titre: 'Membres',
      icon: 'fas fa-users',
      url: 'membres'
    },
    {
      id: '3',
      titre: 'Cotisations',
      icon: 'fa fa-coins',
      url: 'cotisations'
    },
    {
      id: '4',
      titre: 'Avances',
      icon: 'fab fa-stack-overflow',
      url: 'avances'
    },
    {
      id: '5',
      titre: 'Credits',
      icon: 'fa fa-money-check',
      url: 'credits'
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
          url: 'utilisateurs'
        },
        {
          id: '62',
          titre: 'Sexes',
          icon: 'fas fa-cogs',
          url: 'sexes'
        },
        {
          id: '63',
          titre: 'Agences',
          icon: 'fas fa-cogs',
          url: 'agences'
        },
        {
          id: '64',
          titre: 'Services',
          icon: 'fas fa-cogs',
          url: 'services'
        },
        {
          id: '65',
          titre: 'Parametres',
          icon: 'fas fa-cogs',
          url: 'parametres'
        },
        {
          id: '66',
          titre: 'Comptes',
          icon: 'fas fa-cogs',
          url: 'comptes'
        },
        {
          id: '67',
          titre: 'Periodes',
          icon: 'fas fa-cogs',
          url: 'periodes'
        }
      ]
    }
  ];
}
