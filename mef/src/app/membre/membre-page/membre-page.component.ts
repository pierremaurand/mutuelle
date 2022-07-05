import { Component, OnInit } from '@angular/core';
import { Menu } from 'src/app/model/menu';

@Component({
  selector: 'app-membre-page',
  templateUrl: './membre-page.component.html',
  styleUrls: ['./membre-page.component.scss']
})
export class MembrePageComponent implements OnInit {
  menuMembre: Array<Menu> = [
    {
      id: 'M1',
      titre: 'Infos Membre',
      icon: 'fas fa-user',
      url: 'membre-page/infos-membre'
    },
    {
      id: 'M2',
      titre: 'Cotisations',
      icon: 'fa fa-sack-dollar',
      url: 'membre-page/cotisations-membre'
    },
    {
      id: 'M3',
      titre: 'Avances',
      icon: 'fa fa-hand-holding-dollar',
      url: 'membre-page/avances-membre'
    },
    {
      id: 'M4',
      titre: 'Credits',
      icon: 'fa fa-money-check',
      url: 'membre-page/credits-membre'
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }



}
