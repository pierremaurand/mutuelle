import { TypeOperation } from './typeoperation';

export class MvtCompte {
  id: number = 0;
  typeOperation: TypeOperation = 0;
  compteId: number = 0;
  gabaritId: number = 0;
  libelle: string = '';
  montant: number = 0;
  dateMvt: Date = new Date();
}
