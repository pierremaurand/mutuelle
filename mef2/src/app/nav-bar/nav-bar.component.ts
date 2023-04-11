import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Menu } from '../model/menu';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  @Input() menuProperties: Array<Menu> = [];

  private lastSelectedMenu: Menu | undefined;

  loggedinUser!: any;
  constructor(private alertify: AlertifyService, private router: Router) { }

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
