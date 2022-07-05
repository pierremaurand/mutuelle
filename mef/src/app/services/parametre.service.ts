import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Parametre } from '../model/parametre';

@Injectable({
  providedIn: 'root'
})
export class ParametreService {

  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Parametre[]>{
    return this.http.get<Parametre[]>(this.baseUrl + '/parametre/parametres');
  }

  getById(id: number): Observable<Parametre> {
    return this.http.get<Parametre>(this.baseUrl + '/parametre/get/' + id.toString());
  }

  add(parametre: Parametre): Observable<any> {
    console.log(parametre);
    return this.http.post(this.baseUrl + '/parametre/add', parametre,);
  }

  update(parametre: Parametre, id?: number): Observable<any> {
    return this.http.put(this.baseUrl + '/parametre/update/' + id?.toString(),parametre);
  }
}
