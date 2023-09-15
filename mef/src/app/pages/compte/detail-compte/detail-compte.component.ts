import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Compte } from 'src/app/model/compte';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { AvanceService } from 'src/app/services/avance.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-detail-compte',
  templateUrl: './detail-compte.component.html',
  styleUrls: ['./detail-compte.component.scss'],
})
export class DetailCompteComponent implements OnInit {
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
