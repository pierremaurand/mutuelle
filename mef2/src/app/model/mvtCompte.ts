import { TypeOperation } from './typeoperation';

export class MvtCompte {
  id: number = 0;
  membreId?: number;
  typeOperation?: TypeOperation;
  gabaritId?: number;
  libelle?: string;
  montant?: number;
  dateMvt?: string;
  avanceId?: number;
  creditId?: number;
  echeanceCreditId?: number;
  echeanceAvanceId?: number;
}
