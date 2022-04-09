import { Component, OnInit } from '@angular/core';
import { Membre } from 'src/app/model/membre';

@Component({
  selector: 'app-membre-list',
  templateUrl: './membre-list.component.html',
  styleUrls: ['./membre-list.component.scss']
})
export class MembreListComponent implements OnInit {

  listeMembres: Membre[] = [
    {
      id: 1,
      nom: 'ovassa',
      prenom: 'pierre maurand',
      dateAdhesion: new Date('12/06/2018'),
      sexe: 'Masculin',
      lieuAffectation: 'Direction',
      estActif: true,
      cotisations: 120000.55
    },
    {
      id: 1,
      nom: 'ovassa',
      prenom: 'pierre maurand',
      dateAdhesion: new Date('12/06/2018'),
      sexe: 'Feminin',
      lieuAffectation: 'Direction',
      estActif: true
    },
    {
      id: 1,
      nom: 'ovassa',
      prenom: 'pierre maurand',
      dateAdhesion: new Date('12/06/2018'),
      lieuAffectation: 'Direction',
      estActif: true
    },
    {
      id: 1,
      nom: 'ovassa',
      prenom: 'pierre maurand',
      dateAdhesion: new Date('12/06/2018'),
      lieuAffectation: 'Direction',
      estActif: true
    },
    {
      id: 1,
      nom: 'ovassa',
      prenom: 'pierre maurand',
      dateAdhesion: new Date('12/06/2018'),
      lieuAffectation: 'Direction',
      estActif: true
    },
    {
      id: 1,
      nom: 'ovassa',
      prenom: 'pierre maurand',
      dateAdhesion: new Date('12/06/2018'),
      lieuAffectation: 'Direction',
      estActif: true
    },
    {
      id: 1,
      nom: 'ovassa',
      prenom: 'pierre maurand',
      dateAdhesion: new Date('12/06/2018'),
      lieuAffectation: 'Direction',
      estActif: true
    },
    {
      id: 1,
      nom: 'ovassa',
      prenom: 'pierre maurand',
      dateAdhesion: new Date('12/06/2018'),
      lieuAffectation: 'Direction',
      estActif: true
    },
    {
      id: 1,
      nom: 'ovassa',
      prenom: 'pierre maurand',
      dateAdhesion: new Date('12/06/2018'),
      lieuAffectation: 'Direction',
      estActif: true
    },
    {
      id: 1,
      nom: 'ovassa',
      prenom: 'pierre maurand',
      dateAdhesion: new Date('12/06/2018'),
      lieuAffectation: 'Direction',
      estActif: true
    },
    {
      id: 1,
      nom: 'ovassa',
      prenom: 'pierre maurand',
      dateAdhesion: new Date('12/06/2018'),
      lieuAffectation: 'Direction',
      estActif: true
    },
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
