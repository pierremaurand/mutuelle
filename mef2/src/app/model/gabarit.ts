import { Operation } from './operation';
import { TypeMouvement } from './typeMouvement';

export class Gabarit {
  id: number = 0;
  libelle: string = '';
  typeMouvement?: TypeMouvement;
  operations: Operation[] = [];
}
