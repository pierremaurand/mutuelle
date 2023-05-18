import { Poste } from './poste';
import { Sexe } from './sexe';

export class Membre {
  id: number = 0;
  nom: string = '';
  estActif: boolean = false;
  sexeId: number = 0;
  posteId: number = 0;
  lieuAffectationId: number = 0;
  photo: string = 'default_man.jpg';
  dateNaissance: Date = new Date();
  dateAdhesion: Date = new Date();
  lieuNaissance: string = '';
  contact: string = '';
  email: string = '';
}
