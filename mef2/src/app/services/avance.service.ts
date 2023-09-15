import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Avance } from '../model/avance';
import { EcheanceAvance } from '../model/echeanceAvance';
import { Membre } from '../model/Membre';
import { MvtCompte } from '../model/mvtCompte';

@Injectable({
  providedIn: 'root',
})
export class AvanceService {
  baseUrl = environment.baseUrl;
  imagesUrl = environment.imagesUrl;

  constructor(private http: HttpClient) {}

  getAllMembres(): Observable<Membre[]> {
    return this.http.get<Membre[]>(this.baseUrl + '/avance/membres');
  }

  getAllEcheances(): Observable<EcheanceAvance[]> {
    return this.http.get<EcheanceAvance[]>(this.baseUrl + '/avance/echeances');
  }

  getAllEcheancesAvance(avanceId?: number): Observable<EcheanceAvance[]> {
    return this.http.get<EcheanceAvance[]>(
      this.baseUrl + '/avance/echeances/' + avanceId?.toString()
    );
  }

  getAll(): Observable<Avance[]> {
    return this.http.get<Avance[]>(this.baseUrl + '/avance/avances');
  }

  getById(id: number): Observable<Avance> {
    return this.http.get<Avance>(this.baseUrl + '/avance/get/' + id.toString());
  }

  getPhotoUrl(photo?: string): string {
    if (photo && photo !== '') {
      return this.imagesUrl + '/assets/images/' + photo;
    }
    return this.imagesUrl + '/assets/images/default_man.jpg';
  }

  add(avance: Avance): Observable<any> {
    return this.http.post<Avance>(this.baseUrl + '/avance/add', avance);
  }

  update(id?: number, avance?: Avance): Observable<any> {
    return this.http.put(
      this.baseUrl + '/avance/update/' + id?.toString(),
      avance
    );
  }

  addEcheances(echeances: EcheanceAvance[]): Observable<any> {
    return this.http.post<EcheanceAvance[]>(
      this.baseUrl + '/avance/addecheances',
      echeances
    );
  }

  addMvtComptes(mvts: MvtCompte[]): Observable<any> {
    return this.http.post<MvtCompte[]>(
      this.baseUrl + '/avance/addmvtcomptes',
      mvts
    );
  }
}
