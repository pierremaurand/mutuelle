import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Avance } from '../model/avance';
import { EcheanceAvance } from '../model/echeanceAvance';

@Injectable({
  providedIn: 'root'
})
export class AvanceService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getAll(){

  }

  getAllMembreAvance(membreId: number): Observable<Avance[]>{
    return this.http.get<Avance[]>(this.baseUrl + '/avance/avances/membre/' + membreId.toString());
  }

  getEcheancesAvance(avanceId: number): Observable<EcheanceAvance[]>{
    return this.http.get<EcheanceAvance[]>(this.baseUrl + '/avance/get/echeances/' + avanceId.toString());
  }

  updateAvance(avance: Avance): Observable<any>{
    return this.http.put(this.baseUrl + '/avance/update/' +avance.id?.toString(), avance);
  }

  getAvanceById(id: number): Observable<Avance> {
    return this.http.get<Avance>(this.baseUrl + '/avance/get/' + id.toString());
  }

  deleteAvance(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + '/avance/delete/' + id.toString());
  }

}
