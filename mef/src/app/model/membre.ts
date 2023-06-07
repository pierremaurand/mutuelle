import { LieuAffectation } from './lieuAffectation';
import { Mouvement } from './mouvement';
import { Poste } from './poste';
import { Sexe } from './sexe';

export class Membre {
  id: number = 0;
  nom: string = '';
  estActif: boolean = false;
  sexeId: number = 0;
  sexe: Sexe = new Sexe();
  posteId: number = 0;
  poste: Poste = new Poste();
  lieuAffectationId: number = 0;
  lieuAffectation: LieuAffectation = new LieuAffectation();
  photo: string = 'default_man.jpg';
  dateNaissance: string = '';
  dateAdhesion: string = '';
  lieuNaissance: string = '';
  contact: string = '';
  email: string = '';
}
