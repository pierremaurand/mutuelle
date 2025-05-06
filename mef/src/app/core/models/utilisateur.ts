import { Role } from './role';

export class Utilisateur {
  id: number;
  login: string;
  pasword: string;
  role: Role;
  photo: string;

  constructor(
    id: number,
    login: string,
    password: string,
    role: Role,
    photo: string
  ) {
    this.id = id;
    this.login = login;
    this.pasword = password;
    this.role = role;
    this.photo = photo;
  }
}
