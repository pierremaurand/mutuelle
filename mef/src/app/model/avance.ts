import { EcheanceAvance } from "./echeanceAvance";

export class Avance {
  id: number|null = null;
  dateDeblocage: string|null = null;
  dateDebut: string|null = null;
  dateFin: string|null = null;
  montant: number|null = null;
  estValide: boolean|null = null;
  echeanceAvances: EcheanceAvance[] = [];
}
