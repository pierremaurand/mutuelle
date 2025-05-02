import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MenuMembresComponent } from '../menu-membres/menu-membres.component';

@Component({
  selector: 'app-main-membres',
  imports: [MenuMembresComponent, RouterOutlet],
  templateUrl: './main-membres.component.html',
  styleUrl: './main-membres.component.scss',
})
export default class MainMembresComponent {}
