import { Poste } from './poste';
import { Sexe } from './sexe';

export class Membre {
  id?: number;
  nom?: string;
  personnelId?: number;
  estActif?: boolean;
  sexeId?: number;
  posteId?: number;
  lieuAffectationId?: number;
  photo?: string;
  dateNaissance?: Date;
  dateAdhesion?: Date;
  lieuNaissance?: string;
  contact?: string;
  email?: string;
}
