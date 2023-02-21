import { MvtCompte } from './mvtCompte';

export class Compte {
  id: number = 0;
  libelle: string = '';
  membreId: number = 0;
  mvtComptes: MvtCompte[] = [];
}
