import { MvtMembre } from './mvtMembre';

export class Compte {
  id: number = 0;
  libelle: string = '';
  mvtMembres: MvtMembre[] = [];
  creePar: number = 1;
  modifieLe: string = '';
  modifiePar: number = 1;
}
