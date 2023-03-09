import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-detail-cotisation',
  templateUrl: './detail-cotisation.component.html',
  styleUrls: ['./detail-cotisation.component.scss'],
})
export class DetailCotisationComponent implements OnInit {
  @Input()
  membre: Membre = new Membre();
  photo: string = '';
  @Input()
  sexe?: Sexe;
  @Input()
  poste?: Poste;
  @Input()
  lieuAffectation?: LieuAffectation;
  @Input()
  solde?: number;

  constructor(private membreService: MembreService, private router: Router) {}

  ngOnInit(): void {
    this.photo = this.membreService.getPhotoUrl(this.membre.photo);
  }

  modifier(): void {
    this.router.navigate(['nouvellecotisation', this.membre.id]);
  }
}
