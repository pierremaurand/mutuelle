import { Component, Input, OnInit } from '@angular/core';
import { InfosCompte } from 'src/app/model/infosCompte';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';

@Component({
  selector: 'app-infos-membre',
  templateUrl: './infos-membre.component.html',
  styleUrls: ['./infos-membre.component.scss'],
})
export class InfosMembreComponent implements OnInit {
  @Input()
  membre: any;
  @Input()
  photo: string = '';
  @Input()
  sexe?: Sexe;
  @Input()
  poste?: Poste;
  @Input()
  lieuAffectation?: LieuAffectation;

  constructor() {}

  ngOnInit(): void {}
}
