import { RouterOutlet } from '@angular/router';
import { Component } from '@angular/core';
import { EnteteComponent } from 'src/app/composants/entete/entete.component';

@Component({
  selector: 'app-main',
  imports: [RouterOutlet, EnteteComponent],
  templateUrl: './main.component.html',
  styleUrl: './main.component.scss',
})
export default class MainComponent {}
