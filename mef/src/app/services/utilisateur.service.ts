import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UtilisateurList } from '../model/utilisateurList';
import { environment } from 'src/environments/environment';
import { Utilisateur } from '../model/utilisateur';
import { MembreList } from '../model/membreList';
import { Membre } from '../model/Membre';
import { InfosPassword } from '../model/infosPassword';

@Injectable({
  providedIn: 'root',
})
export class UtilisateurService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) {}

  getAll(): Observable<UtilisateurList[]> {
    return this.http.get<UtilisateurList[]>(
      this.baseUrl + '/utilisateur/utilisateurs'
    );
  }

  getById(id?: number): Observable<Utilisateur> {
    return this.http.get<Utilisateur>(
      this.baseUrl + '/utilisateur/get/' + id?.toString()
    );
  }

  getMembre(): Observable<Membre> {
    return this.http.get<Membre>(this.baseUrl + '/utilisateur/getmembre');
  }

  add(utilisateur: Utilisateur): Observable<any> {
    return this.http.post(this.baseUrl + '/utilisateur/add', utilisateur);
  }

  initPassword(id: number, utilisateur: Utilisateur): Observable<any> {
    return this.http.put(
      this.baseUrl + '/utilisateur/initPassword/' + id.toString(),
      utilisateur
    );
  }

  changePassword(infosPassword: InfosPassword): Observable<any> {
    return this.http.put(
      this.baseUrl + '/utilisateur/changePassword',
      infosPassword
    );
  }

  update(utilisateur: Utilisateur, id: number): Observable<any> {
    return this.http.put(
      this.baseUrl + '/utilisateur/update/' + id.toString(),
      utilisateur
    );
  }
}
