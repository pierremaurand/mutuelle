import { TypeOperation } from './typeoperation';

export class Mouvement {
  id: number = 0;
  typeOperation: TypeOperation = TypeOperation.Debit;
  gabaritId: number = 0;
  libelle: string = '';
  montant?: number;
  dateMvt: string = '';
}
