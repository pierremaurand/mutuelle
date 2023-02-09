import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Sexe } from 'src/app/model/sexe';
import { LoaderService } from 'src/app/services/loader.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-sexe-list',
  templateUrl: './sexe-list.component.html',
  styleUrls: ['./sexe-list.component.scss'],
})
export class SexeListComponent implements OnInit {
  sexes: Sexe[] = [];

  constructor(
    private sexeService: SexeService,
    private loaderService: LoaderService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loaderService.show();
    this.sexeService.getAll().subscribe({
      next: (data) => {
        this.loaderService.hide();
        this.sexes = data;
      },
    });
  }

  showDetails(id?: number): void {
    if (id) {
      this.router.navigate(['home/sexes/show', id]);
    }
  }
}
