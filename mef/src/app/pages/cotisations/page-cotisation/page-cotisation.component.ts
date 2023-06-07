import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CotisationList } from 'src/app/model/cotisationList';
import { CotisationService } from 'src/app/services/cotisation.service';

@Component({
  selector: 'app-page-cotisation',
  templateUrl: './page-cotisation.component.html',
  styleUrls: ['./page-cotisation.component.scss'],
})
export class PageCotisationComponent implements OnInit {
  cotisations: CotisationList[] = [];

  constructor(
    private cotisationService: CotisationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.cotisationService
      .getAllCotisations()
      .subscribe((cotisations: CotisationList[]) => {
        this.cotisations = cotisations;
      });
  }

  nouveau(): void {
    this.router.navigate(['/nouvellecotisation']);
  }

  navigate(id: number): void {
    this.router.navigate(['/nouvellecotisation/' + id]);
  }
}
