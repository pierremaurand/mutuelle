import { EcheanceAvance } from './echeanceAvance';
import { MvtCompte } from './mvtCompte';

export class Avance {
  id?: number;
  membreId?: number;
  montant?: number;
  nombreEcheances?: number;
  dateEnregistrement?: string;
  dateDeblocage?: string;
  dateSolde?: string;
}
