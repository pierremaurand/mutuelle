import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Compte } from 'src/app/model/compte';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-detail-compte',
  templateUrl: './detail-compte.component.html',
  styleUrls: ['./detail-compte.component.scss'],
})
export class DetailCompteComponent implements OnInit {
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
    this.router.navigate(['nouveaucompte', this.membre.id]);
  }
}
