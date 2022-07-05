import { EcheanceCredit } from "./echeanceCredit";

export class Credit {
  id: number|null = null;
  dateDebut: string|null = null;
  dateFin: string|null = null;
  capital: number|null = null;
  interet: number|null = null;
  commission: number|null = null;
  echeanceCredits: EcheanceCredit[] = [];
}
