import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MembreList } from 'src/app/model/membreList';
import { AuthService } from 'src/app/services/auth.service';
import { UtilisateurService } from 'src/app/services/utilisateur.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-entete',
  templateUrl: './entete.component.html',
  styleUrls: ['./entete.component.scss'],
})
export class EnteteComponent implements OnInit {
  membre: MembreList = new MembreList();
  imagesUrl = environment.imagesUrl;
  constructor(
    private utilisateurService: UtilisateurService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.utilisateurService.getMembre().subscribe((membre: MembreList) => {
      this.membre = membre;
    });
  }

  logout(): void {
    localStorage.clear();
    this.router.navigate(['login']);
  }

  goProfile(): void {
    this.router.navigate(['profile']);
  }
}
