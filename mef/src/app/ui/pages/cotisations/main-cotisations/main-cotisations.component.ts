import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import MenuCotisationsComponent from '../menu-cotisations/menu-cotisations.component';

@Component({
  selector: 'app-main-cotisations',
  imports: [MenuCotisationsComponent, RouterOutlet],
  templateUrl: './main-cotisations.component.html',
  styleUrl: './main-cotisations.component.scss',
})
export default class MainCotisationsComponent {}
