import { IMembreBase } from "./imembrebase";


export class Membre implements IMembreBase {
  id?: number;
  nom?: string;
  prenom?: string;
  sexeId?: number;
  photo?: string;
  agenceId?: number;
  serviceId?: number;
  estActif?: boolean;
  telephone?: string;
  email?: string;

  sexe?: string;
  agence?: string;
  service?: string;
  cotisations?: number = 0;
  credits?: number = 0;
  avances?: number = 0;
}
