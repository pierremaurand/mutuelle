import { Agence } from "./agence";
import { Avance } from "./avance";
import { CotisationList } from "./cotisationList";
import { Credit } from "./credit";
import { IMembreBase } from "./imembrebase";
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
  dateAdhesion?: Date;
  fraisAdhesion?: number;
  telephone?: string;
  email?: string;
  cotisations?: CotisationList[];
  avances?: Avance[];
  credits?: Credit[];
}
