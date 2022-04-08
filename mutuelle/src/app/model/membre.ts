export interface Membre {
  id?: number;
  nom?: string;
  prenom?: string;
  dateDeNaissance?: Date;
  sexe?: string;
  dateAdhesion?: Date;
  photo?: string;
  lieuAffectation?: string;
  estActif?: boolean;
}
