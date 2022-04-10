import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Agence } from '../model/agence';

@Injectable({
  providedIn: 'root'
})
export class AgenceService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Agence[]>{
    return this.http.get<Agence[]>(this.baseUrl + '/agence/agences');
  }

  getById(id: number): Observable<Agence> {
    return this.http.get<Agence>(this.baseUrl + '/agence/get/' + id.toString());
  }

  save(agence: Agence): Observable<any> {
    return this.http.post(this.baseUrl + '/agence/add', agence);
  }

  update(agence: Agence, id?: number): Observable<any> {
    return this.http.put(this.baseUrl + '/agence/update/' + id?.toString(),agence);
  }
}
