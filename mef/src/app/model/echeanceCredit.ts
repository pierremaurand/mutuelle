import { Mouvement } from './mouvement';

export class EcheanceCredit {
  id?: number;
  creditId?: number;
  moisId?: number;
  annee?: number;
  montantCapital?: number;
  montantInteret?: number;
  mouvements?: Mouvement[];
}
