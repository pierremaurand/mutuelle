import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MembreList } from '../model/membreList';
import { InfosCompte } from '../model/infosCompte';
import { InfosMembre } from '../model/infosMembre';
import { MvtCompte } from '../model/mvtCompte';
import { Membre } from '../model/Membre';
import { CompteList } from '../model/compteList';
import { Mouvement } from '../model/mouvement';

@Injectable({
  providedIn: 'root',
})
export class CompteService {
  baseUrl = environment.baseUrl;
  imagesUrl = environment.imagesUrl;

  constructor(private http: HttpClient) {}

  getAllMembres(): Observable<MembreList[]> {
    return this.http.get<MembreList[]>(this.baseUrl + '/compte/membres');
  }

  getAllComptes(): Observable<CompteList[]> {
    return this.http.get<CompteList[]>(this.baseUrl + '/compte/comptes');
  }

  getAllMvts(id: number): Observable<Mouvement[]> {
    return this.http.get<Mouvement[]>(
      this.baseUrl + '/compte/mvtsmembre/' + id.toString()
    );
  }

  getAllMvtsById(id?: number): Observable<MvtCompte[]> {
    return this.http.get<MvtCompte[]>(
      this.baseUrl + '/compte/mvtcomptes/' + id?.toString()
    );
  }

  getById(id?: number): Observable<Membre> {
    return this.http.get<Membre>(
      this.baseUrl + '/compte/get/' + id?.toString()
    );
  }

  addMvts(id: number, mvts: Mouvement[]): Observable<any> {
    return this.http.post<Mouvement[]>(
      this.baseUrl + '/compte/addmvts/' + id.toString(),
      mvts
    );
  }
}
