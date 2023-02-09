import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Poste } from 'src/app/model/poste';
import { LoaderService } from 'src/app/services/loader.service';
import { PosteService } from 'src/app/services/poste.service';

@Component({
  selector: 'app-poste-list',
  templateUrl: './poste-list.component.html',
  styleUrls: ['./poste-list.component.scss'],
})
export class PosteListComponent implements OnInit {
  postes: Poste[] = [];

  constructor(
    private posteService: PosteService,
    private loaderService: LoaderService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loaderService.show();
    this.posteService.getAll().subscribe({
      next: (data) => {
        this.loaderService.hide();
        this.postes = data;
      },
    });
  }

  showDetails(id?: number): void {
    if (id) {
      this.router.navigate(['home/postes/show', id]);
    }
  }
}
