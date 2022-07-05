import { Agence } from "./agence";
import { Service } from "./service";
import { Sexe } from "./sexe";


export class Membre {
  id?: number;
  nom?: string;
  prenom?: string;
  sexeId?: number;
  sexe?: Sexe;
  photo?: string;
  agenceId?: number;
  agence?: Agence;
  serviceId?: number;
  service?: Service;
  estActif?: boolean;
  dateAdhesion?: string;
  adhesionOn?: Date;
  fraisAdhesion?: number;
  telephone?: string;
  email?: string;
}
