import { Component, OnInit } from '@angular/core';
import { MembreList } from 'src/app/model/membreList';
import { UtilisateurService } from 'src/app/services/utilisateur.service';

@Component({
  selector: 'app-page-profile',
  templateUrl: './page-profile.component.html',
  styleUrls: ['./page-profile.component.scss'],
})
export class PageProfileComponent implements OnInit {
  membre: MembreList = new MembreList();

  constructor(private utilisateurService: UtilisateurService) {}

  ngOnInit(): void {
    this.utilisateurService.getMembre().subscribe((membre: MembreList) => {
      this.membre = membre;
    });
  }
}
