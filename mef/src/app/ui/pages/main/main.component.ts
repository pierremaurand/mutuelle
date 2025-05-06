import { RouterOutlet } from '@angular/router';
import { Component } from '@angular/core';
import { MenuComponent } from '../../composants/menu/menu.component';
import { RechercheComponent } from '../../composants/recherche/recherche.component';

@Component({
  selector: 'app-main',
  imports: [RouterOutlet, MenuComponent, RechercheComponent],
  templateUrl: './main.component.html',
  styleUrl: './main.component.scss',
})
export default class MainComponent {}
