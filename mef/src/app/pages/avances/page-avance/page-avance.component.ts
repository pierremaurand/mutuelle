import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Avance } from 'src/app/model/avance';
import { AvanceService } from 'src/app/services/avance.service';

@Component({
  selector: 'app-page-avance',
  templateUrl: './page-avance.component.html',
  styleUrls: ['./page-avance.component.scss'],
})
export class PageAvanceComponent implements OnInit {
  avances: Avance[] = [];

  constructor(private avanceService: AvanceService, private router: Router) {}

  ngOnInit(): void {
    this.avanceService.getAll().subscribe((avances: Avance[]) => {
      this.avances = avances;
    });
  }

  nouveauAvance(): void {
    this.router.navigate(['/nouvelleavance']);
  }

  navigate(id: number): void {
    this.router.navigate(['/nouvelleavance/' + id]);
  }

  exportAvance(): void {}

  importAvance(): void {}
}
