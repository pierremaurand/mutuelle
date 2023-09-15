import { Component, Input, OnInit } from '@angular/core';
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
  selector: 'app-detail-membre',
  templateUrl: './detail-membre.component.html',
  styleUrls: ['./detail-membre.component.scss'],
})
export class DetailMembreComponent implements OnInit {
  @Input()
  membreId: number = 0;
  @Input()
  width: number = 64;
  membre: Membre = new Membre();

  constructor(private membreService: MembreService) {}

  ngOnInit(): void {
    this.membreService.getById(this.membreId).subscribe((membre: Membre) => {
      this.membre = membre;
    });
  }
}
