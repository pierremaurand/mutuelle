import { Operation } from './operation';

export class Gabarit {
  id: number = 0;
  libelle: string = '';
  operations: Operation[] = [];
  creePar: number = 1;
  modifieLe: string = '';
  modifiePar: number = 1;
}