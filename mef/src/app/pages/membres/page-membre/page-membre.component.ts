import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-page-membre',
  templateUrl: './page-membre.component.html',
  styleUrls: ['./page-membre.component.scss'],
})
export class PageMembreComponent implements OnInit {
  membres: MembreList[] = [];

  constructor(private membreService: MembreService, private router: Router) {}

  ngOnInit(): void {
    this.membreService.getAll().subscribe((data: MembreList[]) => {
      this.membres = data;
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
