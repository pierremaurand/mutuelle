import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Sexe } from '../model/sexe';

@Injectable({
  providedIn: 'root',
})
export class SexeService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Sexe[]> {
    return this.http.get<Sexe[]>(this.baseUrl + '/sexe/sexes');
  }

  getById(id: number): Observable<Sexe> {
    return this.http.get<Sexe>(this.baseUrl + '/sexe/get/' + id.toString());
  }

  add(sexe: Sexe): Observable<any> {
    return this.http.post(this.baseUrl + '/sexe/add', sexe);
  }

  update(sexe: Sexe, id: number): Observable<any> {
    return this.http.put(this.baseUrl + '/sexe/update/' + id.toString(), sexe);
  }

  deleteSexe(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + '/sexe/delete/' + id.toString());
  }
}
