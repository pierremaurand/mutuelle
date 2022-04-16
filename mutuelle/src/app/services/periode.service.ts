import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Periode } from '../model/periode';

@Injectable({
  providedIn: 'root'
})
export class PeriodeService {

  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Periode[]>{
    return this.http.get<Periode[]>(this.baseUrl + '/periode/periodes');
  }

  getById(id: number): Observable<Periode> {
    return this.http.get<Periode>(this.baseUrl + '/periode/get/' + id.toString());
  }

  add(periode: Periode): Observable<any> {
    console.log(periode);
    return this.http.post(this.baseUrl + '/periode/add', periode,);
  }

  update(periode: Periode, id?: number): Observable<any> {
    return this.http.put(this.baseUrl + '/periode/update/' + id?.toString(),periode);
  }
}
