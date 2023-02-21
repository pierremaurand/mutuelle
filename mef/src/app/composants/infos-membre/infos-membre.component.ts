import { Component, Input, OnInit } from '@angular/core';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';

@Component({
  selector: 'app-infos-membre',
  templateUrl: './infos-membre.component.html',
  styleUrls: ['./infos-membre.component.scss'],
})
export class InfosMembreComponent implements OnInit {
  @Input()
  membre: Membre = new Membre();
  @Input()
  photo: string = '';
  @Input()
  poste: Poste = {};
  @Input()
  sexe: Sexe = {};
  @Input()
  lieuAffectation: LieuAffectation = {};

  constructor() {}

  ngOnInit(): void {}
}
