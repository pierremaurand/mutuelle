import { Component, Input, OnInit } from '@angular/core';
import { Membre } from 'src/app/model/Membre';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { MembreList } from 'src/app/model/membreList';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-details-membre',
  templateUrl: './details-membre.component.html',
  styleUrls: ['./details-membre.component.scss'],
})
export class DetailsMembreComponent implements OnInit {
  @Input()
  membre: MembreList = new MembreList();
  @Input()
  solde: number = 0;
  @Input()
  afficheSolde: boolean = false;
  imagesUrl = environment.imagesUrl;

  constructor() {}

  ngOnInit(): void {}
}
