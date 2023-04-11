import { Mois } from './mois';
import { MvtCompte } from './mvtCompte';

export class Cotisation {
  id: number = 0;
  membreId?: number;
  moisId?: number;
  annee?: number;
  montant?: number;
  mvtComptes: MvtCompte[] = [];
}
