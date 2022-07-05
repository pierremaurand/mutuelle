import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Avance } from '../model/avance';
import { Cotisation } from '../model/cotisation';
import { Credit } from '../model/credit';
import { Membre } from "../model/membre";

@Injectable({
  providedIn: 'root'
})
export class MembreService {

  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getAllMembres(): Observable<Membre[]>{
    return this.http.get<Membre[]>(this.baseUrl + '/membre/membres');
  }

  getMembreById(id: number): Observable<Membre> {
    return this.http.get<Membre>(this.baseUrl + '/membre/get/' + id.toString());
  }

  addMembre(membre: Membre): Observable<any> {
    return this.http.post(this.baseUrl + '/membre/add',membre);
  }

  updateInfos(membre: Membre, id?: number): Observable<any> {
    return this.http.put(this.baseUrl + '/membre/update/' + id?.toString(),membre);
  }

  addPhotoMembre(file: any): Observable<any> {
    const formData = new FormData();
    formData.append('file', file,'photoProfile.png');
    return this.http.post(this.baseUrl + '/membre/add/photo',formData);
  }

  addCotisationMembre(cotisation: Cotisation, membreId?: number): Observable<any> {
    return this.http.post(this.baseUrl + '/membre/add/cotisation/' +membreId?.toString(),cotisation);
  }

  addAvanceMembre(avance: Avance,membreId?: number): Observable<any> {
    return this.http.post(this.baseUrl + '/membre/add/avance/' +membreId?.toString(),avance);
  }

  addCreditMembre(credit: Credit,membreId?: number): Observable<any> {
    return this.http.post(this.baseUrl + '/membre/add/credit/' +membreId?.toString(),credit);
  }
}
