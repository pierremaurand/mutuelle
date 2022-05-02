import { EcheanceAvance } from "./echeanceAvance";

export interface Avance {
  id?: number;
  dateDebut?: string;
  dateFin?: string;
  montant?: number;
  echeanceAvances?: EcheanceAvance[];
}
