import { TypeOperation } from './typeoperation';

export class MvtMembre {
  id: number = 0;
  compteComptableId: number = -1;
  compteLibelle: string = '';
  typeOperation: TypeOperation = -1;
  gabaritId?: number;
  tOperation: string = '';
  taux?: number;
}
