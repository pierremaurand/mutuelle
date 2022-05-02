import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cotisation } from '../model/cotisation';

@Injectable({
  providedIn: 'root'
})
export class CotisationService {

  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Cotisation[]>{
    return this.http.get<Cotisation[]>(this.baseUrl + '/cotisation/cotisations');
  }

  getAllMembreCotisation(membreId: number): Observable<Cotisation[]>{
    return this.http.get<Cotisation[]>(this.baseUrl + '/cotisation/cotisations/membre/' + membreId.toString());
  }

  getById(id: number): Observable<Cotisation> {
    return this.http.get<Cotisation>(this.baseUrl + '/cotisation/get/' + id.toString());
  }

  add(cotisation: Cotisation): Observable<any> {
    console.log(cotisation);
    return this.http.post(this.baseUrl + '/cotisation/add', cotisation,);
  }

  update(cotisation: Cotisation, id?: number): Observable<any> {
    return this.http.put(this.baseUrl + '/cotisation/update/' + id?.toString(),cotisation);
  }
}
