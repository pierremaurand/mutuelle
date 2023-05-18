import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UtilisateurList } from '../model/utilisateurList';
import { environment } from 'src/environments/environment';
import { Utilisateur } from '../model/utilisateur';
import { MembreList } from '../model/membreList';

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

  getMembre(): Observable<MembreList> {
    return this.http.get<MembreList>(this.baseUrl + '/utilisateur/getmembre');
  }

  add(utilisateur: Utilisateur): Observable<any> {
    return this.http.post(this.baseUrl + '/utilisateur/add', utilisateur);
  }

  update(utilisateur: Utilisateur, id: number): Observable<any> {
    return this.http.put(
      this.baseUrl + '/utilisateur/update/' + id.toString(),
      utilisateur
    );
  }
}
