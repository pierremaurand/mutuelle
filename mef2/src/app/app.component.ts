import { Component } from '@angular/core';
import { Menu } from './model/menu';
import { LoaderService } from './services/loader.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'angular-app';

  constructor(public loaderService: LoaderService) {}
}
