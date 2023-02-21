import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Menu } from 'src/app/model/menu';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent implements OnInit {
  public menuProperties: Menu[] = [
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
          url: '',
        },
        {
          id: '12',
          titre: 'Statistiques',
          icon: 'fas fa-chart-bar',
          url: 'statistiques',
        },
      ],
    },
    {
      id: '2',
      titre: 'Membres',
      icon: 'fas fa-users',
      url: '',
      sousMenu: [
        {
          id: '21',
          titre: 'Membres',
          icon: 'fas fa-users',
          url: 'membres',
        },
        {
          id: '22',
          titre: 'Comptes',
          icon: 'fa fa-money-check',
          url: 'comptes',
        },
        {
          id: '23',
          titre: 'Cotisations',
          icon: 'fa fa-coins',
          url: 'cotisations',
        },
        {
          id: '24',
          titre: 'Avances',
          icon: 'fab fa-stack-overflow',
          url: 'avances',
        },
        {
          id: '25',
          titre: 'Credits',
          icon: 'fa fa-money-check',
          url: 'credits',
        },
      ],
    },
    {
      id: '3',
      titre: 'Comptabilité',
      icon: 'fa fa-money-check',
      url: '',
      sousMenu: [],
    },
    {
      id: '4',
      titre: 'Paramétrages',
      icon: 'fas fa-cogs',
      url: '',
      sousMenu: [
        {
          id: '41',
          titre: 'Utilisateurs',
          icon: 'fas fa-users-cog',
          url: 'utilisateurs',
        },
        {
          id: '42',
          titre: 'Sexes',
          icon: 'fas fa-venus-mars',
          url: 'sexes',
        },
        {
          id: '43',
          titre: 'Postes',
          icon: 'fa fa-list',
          url: 'postes',
        },
        {
          id: '44',
          titre: 'Comptes comptables',
          icon: 'fa fa-map',
          url: 'comptecomptables',
        },
        {
          id: '45',
          titre: 'Gabarits',
          icon: 'fa fa-list',
          url: 'gabarits',
        },
        {
          id: '46',
          titre: 'Lieu Affectation',
          icon: 'far fa-building',
          url: 'lieuaffectations',
        },
      ],
    },
  ];

  private lastSelectedMenu: Menu | undefined;

  constructor(private router: Router) {}

  ngOnInit(): void {}

  navigate(menu: Menu): void {
    if (this.lastSelectedMenu) {
      this.lastSelectedMenu.active = false;
    }

    menu.active = true;
    this.lastSelectedMenu = menu;
    this.router.navigate([menu.url]);
  }
}
