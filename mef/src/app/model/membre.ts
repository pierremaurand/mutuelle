import { Poste } from './poste';
import { Sexe } from './sexe';

export class Membre {
  id?: number;
  nom?: string;
  personnelId?: number;
  estActif?: boolean;
  sexe?: Sexe;
  poste?: Poste;
  photo?: string;
  photoUrl?: string;
  dateNaissance?: string;
  lieuNaissance?: string;
  contact?: string;
  email?: string;
}
