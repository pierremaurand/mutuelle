import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Gabarit } from 'src/app/model/gabarit';
import { GabaritService } from 'src/app/services/gabarit.service';
import { LoaderService } from 'src/app/services/loader.service';

@Component({
  selector: 'app-gabarit-list',
  templateUrl: './gabarit-list.component.html',
  styleUrls: ['./gabarit-list.component.scss'],
})
export class GabaritListComponent implements OnInit {
  gabarits: Gabarit[] = [];

  constructor(
    private gabariStervice: GabaritService,
    private loaderService: LoaderService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loaderService.show();
    this.gabariStervice.getAll().subscribe({
      next: (data) => {
        this.loaderService.hide();
        this.gabarits = data;
      },
    });
  }

  showDetails(id?: number): void {
    if (id) {
      this.router.navigate(['home/gabarits/show', id]);
    }
  }
}
