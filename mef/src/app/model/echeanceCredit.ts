import { Mouvement } from './mouvement';

export class EcheanceCredit {
  id: number = 0;
  dateEcheance?: string | null = '';
  capital?: number;
  interet?: number;
  montantPaye?: number;
  creditId?: number;
}
