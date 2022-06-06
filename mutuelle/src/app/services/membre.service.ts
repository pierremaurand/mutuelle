import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retry } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Agence } from '../model/agence';
import { Avance } from '../model/avance';
import { Cotisation } from '../model/cotisation';
import { ImageResponse } from '../model/imageResponse';
import { Membre } from "../model/membre";
import { MembreList } from '../model/membreList';
import { Service } from '../model/service';
import { Sexe } from '../model/sexe';

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

  add(membre: Membre): Observable<any> {
    return this.http.post(this.baseUrl + '/membre/add',membre);
  }

  update(membre: Membre, id?: number): Observable<any> {
    return this.http.put(this.baseUrl + '/membre/update/' + id?.toString(),membre);
  }

  addPhoto(file: any): Observable<any> {
    const formData = new FormData();
    formData.append('file', file,'photoProfile.png');
    return this.http.post(this.baseUrl + '/membre/add/photo',formData);
  }

  afficheSexe(sexe:Sexe|undefined): string|undefined {
    if(sexe) {
      return sexe.nom;
    }
    return undefined;
  }

  afficheAgence(agence:Agence|undefined): string|undefined {
    if(agence) {
      return agence.nom;
    }
    return undefined;
  }

  afficheService(service:Service|undefined): string|undefined {
    if(service) {
      return service.nom;
    }
    return undefined;
  }
}
