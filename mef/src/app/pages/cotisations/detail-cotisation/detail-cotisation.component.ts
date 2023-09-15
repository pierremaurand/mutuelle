import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-detail-cotisation',
  templateUrl: './detail-cotisation.component.html',
  styleUrls: ['./detail-cotisation.component.scss'],
})
export class DetailCotisationComponent implements OnInit {
  @Input()
  membre: Membre = new Membre();
  @Input()
  solde: number = 0;

  constructor(private membreService: MembreService) {}

  ngOnInit(): void {
    this.membreService.getById(this.membre.id).subscribe((membre: Membre) => {
      this.membre = membre;
    });
  }
}
