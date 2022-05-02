import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Avance } from '../model/avance';
import { Cotisation } from '../model/cotisation';
import { Membre } from "../model/membre";
import { MembreList } from '../model/membreList';

@Injectable({
  providedIn: 'root'
})
export class MembreService {

  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getAll(): Observable<MembreList[]>{
    return this.http.get<MembreList[]>(this.baseUrl + '/membre/membres');
  }

  getById(id: number): Observable<Membre> {
    return this.http.get<Membre>(this.baseUrl + '/membre/get/' + id.toString());
  }

  getCotisations(id: number): Observable<Cotisation[]> {
    return this.http.get<Cotisation[]>(this.baseUrl + '/membre/get/cotisations/' + id.toString());
  }

  getAvances(id: number): Observable<Avance[]> {
    return this.http.get<Avance[]>(this.baseUrl + '/membre/get/avances/' + id.toString());
  }

  addAvance(id: number, avance: Avance): Observable<any> {
    return this.http.post<any>(this.baseUrl + '/membre/add/avance/' + id.toString(), avance);
  }

  updateAvance(id: number, avance: Avance): Observable<any> {
    return this.http.put<any>(this.baseUrl + '/membre/update/avance/' + id.toString(), avance);
  }

  addCotisation(id: number, cotisation: Cotisation): Observable<any> {
    return this.http.post<any>(this.baseUrl + '/membre/add/cotisation/' + id.toString(), cotisation);
  }

  updateCotisation(id: number, cotisation: Cotisation): Observable<any> {
    return this.http.put<any>(this.baseUrl + '/membre/update/cotisation/' + id.toString(), cotisation);
  }

  add(membre: Membre): Observable<any> {
    return this.http.post(this.baseUrl + '/membre/add', membre);
  }

  update(membre: Membre, id?: number): Observable<any> {
    return this.http.put(this.baseUrl + '/membre/update/' + id?.toString(),membre);
  }

  addPhoto(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file, file.name);
    return this.http.post(this.baseUrl + '/membre/add/photo', formData);
  }
}
