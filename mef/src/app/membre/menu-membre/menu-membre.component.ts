import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Menu } from 'src/app/model/menu';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-menu-membre',
  templateUrl: './menu-membre.component.html',
  styleUrls: ['./menu-membre.component.scss']
})
export class MenuMembreComponent implements OnInit {
  public menuProperties: Array<Menu> = [
    {
      id: 'M1',
      titre: 'Membre',
      icon: 'fas fa-user',
      url: '',
      sousMenu: [
        {
          id: 'M11',
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

  private lastSelectedMenu: Menu | undefined;

  loggedinUser!: any;
  constructor(
    private alertify: AlertifyService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  loggedin() {
    this.loggedinUser = localStorage.getItem('userName');
    return this.loggedinUser;
  }

  onLogout() {
    localStorage.removeItem('token');
    localStorage.removeItem('userName');
    this.alertify.success("You are logged out !");
  }

  navigate(menu: Menu): void {
    if(this.lastSelectedMenu) {
      this.lastSelectedMenu.active = false;
    }
    menu.active = true;
    this.lastSelectedMenu = menu;
    this.router.navigate([menu.url]);
  }

}
