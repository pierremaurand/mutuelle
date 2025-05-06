import { Component } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { MenuUserComponent } from '../menu-user/menu-user.component';

@Component({
  selector: 'app-menu',
  imports: [RouterLink, RouterLinkActive, MenuUserComponent],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss',
})
export class MenuComponent {}
