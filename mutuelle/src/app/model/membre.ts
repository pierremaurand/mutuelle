export interface Membre {
  id?: number;
  nom?: string;
  prenom?: string;
  sexe?: string;
  dateAdhesion?: Date;
  photo?: string;
  agence?: string;
  estActif?: boolean;
  cotisations?: number;
  credits?: number;
  avances?: number;
}
