import { Component, Input, OnInit } from '@angular/core';
import { Membre } from 'src/app/model/Membre';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-infos-membre',
  templateUrl: './infos-membre.component.html',
  styleUrls: ['./infos-membre.component.scss'],
})
export class InfosMembreComponent implements OnInit {
  @Input()
  membre: Membre = new Membre();
  imagesUrl = environment.imagesUrl;

  constructor() {}

  ngOnInit(): void {}
}
