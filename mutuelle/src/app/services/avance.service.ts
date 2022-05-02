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

  getById() {

  }

  save() {

  }
}
