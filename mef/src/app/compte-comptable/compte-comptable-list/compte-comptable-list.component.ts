import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CompteComptable } from 'src/app/model/comptecomptable';
import { CompteComptableService } from 'src/app/services/compte-comptable.service';
import { LoaderService } from 'src/app/services/loader.service';

@Component({
  selector: 'app-compte-comptable-list',
  templateUrl: './compte-comptable-list.component.html',
  styleUrls: ['./compte-comptable-list.component.scss'],
})
export class CompteComptableListComponent implements OnInit {
  comptes: CompteComptable[] = [];

  constructor(
    private compteComptableService: CompteComptableService,
    private loaderService: LoaderService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loaderService.show();
    this.compteComptableService.getAll().subscribe({
      next: (data) => {
        this.loaderService.hide();
        this.comptes = data;
      },
    });
  }

  showDetails(id?: number): void {
    if (id) {
      this.router.navigate(['home/plan-comptable/show', id]);
    }
  }
}
