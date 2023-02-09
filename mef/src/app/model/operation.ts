import { TypeOperation } from './typeoperation';

export class Operation {
  id: number = 0;
  compteComptableId: number = -1;
  compte: string = '';
  gabaritId?: number;
  typeOperation: TypeOperation = -1;
  tOperation: string = '';
  taux?: number;
}
