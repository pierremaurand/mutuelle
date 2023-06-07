import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-page-membre',
  templateUrl: './page-membre.component.html',
  styleUrls: ['./page-membre.component.scss'],
})
export class PageMembreComponent implements OnInit {
  membres: Membre[] = [];

  constructor(private membreService: MembreService, private router: Router) {}

  ngOnInit(): void {
    this.membreService.getAll().subscribe((membres: Membre[]) => {
      this.membres = membres;
    });
  }

  nouveauMembre(): void {
    this.router.navigate(['/nouveaumembre']);
  }

  navigate(id: number): void {
    this.router.navigate(['/nouveaumembre/' + id]);
  }

  exportMembre(): void {}

  importMembre(): void {}
}
