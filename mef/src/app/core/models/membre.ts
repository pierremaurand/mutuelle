import { Sexe } from 'src/app/models/sexe';
import { Agence } from './agence';

export class Membre {
  id: number;
  nom: string;
  email: string;
  telephone: string;
  dateNaissance: Date;
  lieuNaissance: string;
  sexe: Sexe;
  lieuAffectation: Agence;
  dateAdhesion: Date;
  estActif: boolean;
  photo: string;

  constructor(
    id: number,
    nom: string,
    email: string,
    telephone: string,
    dateNaissance: Date,
    lieuNaissance: string,
    sexe: Sexe,
    lieuAffectation: Agence,
    dateAdhesion: Date,
    estActif: boolean,
    photo: string
  ) {
    this.id = id;
    this.nom = nom;
    this.email = email;
    this.telephone = telephone;
    this.dateNaissance = dateNaissance;
    this.lieuNaissance = lieuNaissance;
    this.sexe = sexe;
    this.lieuAffectation = lieuAffectation;
    this.dateAdhesion = dateAdhesion;
    this.estActif = estActif;
    this.photo = photo;
  }
}
