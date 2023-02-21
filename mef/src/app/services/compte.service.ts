import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Compte } from '../model/compte';

@Injectable({
  providedIn: 'root',
})
export class CompteService {
  baseUrl = environment.baseUrl;
  imagesUrl = environment.imagesUrl;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Compte[]> {
    return this.http.get<Compte[]>(this.baseUrl + '/compte/comptes');
  }

  getById(id: number): Observable<Compte> {
    return this.http.get<Compte>(this.baseUrl + '/compte/get/' + id.toString());
  }

  add(compte: Compte): Observable<any> {
    return this.http.post(this.baseUrl + '/compte/add', compte);
  }

  update(compte: Compte, id: number): Observable<any> {
    return this.http.put(
      this.baseUrl + '/compte/update/' + id.toString(),
      compte
    );
  }

  delete(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + '/compte/delete/' + id.toString());
  }
}
