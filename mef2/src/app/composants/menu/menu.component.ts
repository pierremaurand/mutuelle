import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Menu } from 'src/app/model/menu';
import { HeaderService } from 'src/app/services/header.service';

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
      icon: 'fas fa-fw fa-tachometer-alt',
      url: '',
    },
    {
      id: '2',
      titre: 'Gestion Membres',
      icon: 'fas fa-fw fa-users',
      url: '',
      sousMenu: [
        {
          id: '21',
          titre: 'Membres',
          icon: 'fas fa-fw fa-users',
          url: 'membres',
        },
        {
          id: '22',
          titre: 'Comptes',
          icon: 'fa fa-fw fa-money-check',
          url: 'comptes',
        },
        {
          id: '23',
          titre: 'Cotisations',
          icon: 'fa fa-fw fa-coins',
          url: 'cotisations',
        },
      ],
    },
    {
      id: '3',
      titre: ' Gestion prèts',
      icon: 'fab fa-fw fa-stack-overflow',
      url: '',
      sousMenu: [
        {
          id: '31',
          titre: 'Avances',
          icon: 'fab fa-fw fa-stack-overflow',
          url: 'avances',
        },
        {
          id: '32',
          titre: 'Credits',
          icon: 'fa fa-fw fa-money-check',
          url: 'credits',
        },
      ],
    },
    {
      id: '5',
      titre: 'Comptabilité',
      icon: 'fa fa-fw fa-money-check',
      url: '',
      sousMenu: [],
    },
    {
      id: '6',
      titre: 'Paramétrages',
      icon: 'fas fa-fw fa-cogs',
      url: '',
      sousMenu: [
        {
          id: '61',
          titre: 'Utilisateurs',
          icon: 'fas fa-fw fa-users-cog',
          url: 'utilisateurs',
        },
        {
          id: '62',
          titre: 'Sexes',
          icon: 'fas fa-fw fa-venus-mars',
          url: 'sexes',
        },
        {
          id: '63',
          titre: 'Postes',
          icon: 'fa fa-fw fa-list',
          url: 'postes',
        },
        {
          id: '64',
          titre: 'Comptes comptables',
          icon: 'fa fa-fw fa-map',
          url: 'comptecomptables',
        },
        {
          id: '65',
          titre: 'Gabarits',
          icon: 'fa fa-fw fa-list',
          url: 'gabarits',
        },
        {
          id: '66',
          titre: 'Lieu Affectation',
          icon: 'far fa-fw fa-building',
          url: 'lieuaffectations',
        },
      ],
    },
  ];

  private lastSelectedMenu: Menu | undefined;

  constructor(private router: Router, private headerService: HeaderService) {}

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
