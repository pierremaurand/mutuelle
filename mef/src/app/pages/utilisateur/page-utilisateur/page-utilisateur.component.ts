import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UtilisateurList } from 'src/app/model/utilisateurList';
import { UtilisateurService } from 'src/app/services/utilisateur.service';

@Component({
  selector: 'app-page-utilisateur',
  templateUrl: './page-utilisateur.component.html',
  styleUrls: ['./page-utilisateur.component.scss'],
})
export class PageUtilisateurComponent implements OnInit {
  utilisateurs: UtilisateurList[] = [];
  constructor(
    private router: Router,
    private utilisateurService: UtilisateurService
  ) {}

  ngOnInit(): void {
    this.utilisateurService.getAll().subscribe((data: UtilisateurList[]) => {
      this.utilisateurs = data;
    });
  }

  nouvelUtilisateur(): void {
    this.router.navigate(['nouvelutilisateur']);
  }

  navigate(id: number): void {
    this.router.navigate(['/nouvelutilisateur/' + id]);
  }
}
