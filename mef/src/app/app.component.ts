import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoaderService } from './services/loader.service';
import { LoaderComponent } from './composants/loader/loader.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, LoaderComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'angular-app';

  constructor(public loaderService: LoaderService) {}
  ngOnInit(): void {
    this.loaderService.isLoading.next(false);
  }
}
