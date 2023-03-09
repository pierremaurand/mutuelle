import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-detail-avance',
  templateUrl: './detail-avance.component.html',
  styleUrls: ['./detail-avance.component.scss'],
})
export class DetailAvanceComponent implements OnInit {
  @Input()
  avanceId?: number;
  @Input()
  membre?: Membre;
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
    this.photo = this.membreService.getPhotoUrl(this.membre?.photo);
  }

  modifier(): void {
    this.router.navigate(['nouvelleavance', this.avanceId]);
  }
}
