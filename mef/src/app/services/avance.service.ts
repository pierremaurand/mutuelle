import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Avance } from '../model/avance';
import { EcheanceAvance } from '../model/echeanceAvance';
import { Membre } from '../model/Membre';
import { MvtCompte } from '../model/mvtCompte';
import { AvanceList } from '../model/avanceList';
import { AvanceDebourse } from '../model/avanceDebourse';
import { InfosAvanceDebourse } from '../model/infosAvanceDeblocage';
import { Mouvement } from '../model/mouvement';
import { InfosAvance } from '../model/infosAvance';

@Injectable({
  providedIn: 'root',
})
export class AvanceService {
  baseUrl = environment.baseUrl;
  imagesUrl = environment.imagesUrl;

  constructor(private http: HttpClient) {}

  getAllEcheances(): Observable<EcheanceAvance[]> {
    return this.http.get<EcheanceAvance[]>(this.baseUrl + '/avance/echeances');
  }

  getDeboursement(avanceId: number): Observable<AvanceDebourse> {
    return this.http.get<AvanceDebourse>(
      this.baseUrl + '/avance/deboursement/' + avanceId.toString()
    );
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

  getMouvements(id: number): Observable<Mouvement[]> {
    return this.http.get<Mouvement[]>(
      this.baseUrl + '/avance/getmouvements/' + id.toString()
    );
  }

  getSolde(id: number): Observable<number> {
    return this.http.get<number>(
      this.baseUrl + '/avance/getsolde/' + id.toString()
    );
  }

  getStatus(id: number): Observable<string> {
    return this.http.get<string>(
      this.baseUrl + '/avance/getstatus/' + id.toString()
    );
  }

  getInfosAvance(id: number): Observable<InfosAvance> {
    return this.http.get<InfosAvance>(
      this.baseUrl + '/avance/getinfosavance/' + id.toString()
    );
  }

  getEcheancier(id: number): Observable<EcheanceAvance[]> {
    return this.http.get<EcheanceAvance[]>(
      this.baseUrl + '/avance/getecheancier/' + id.toString()
    );
  }

  getPhotoUrl(photo?: string): string {
    if (photo && photo !== '') {
      return this.imagesUrl + '/assets/images/' + photo;
    }
    return this.imagesUrl + '/assets/images/default_man.jpg';
  }

  add(avance: Avance): Observable<Avance> {
    return this.http.post<Avance>(this.baseUrl + '/avance/add', avance);
  }

  debourserAvance(
    id: number,
    avanceDebourse: AvanceDebourse
  ): Observable<AvanceDebourse> {
    return this.http.post<AvanceDebourse>(
      this.baseUrl + '/avance/debourseravance/' + id.toString(),
      avanceDebourse
    );
  }

  update(id: number, avanceDebourse: AvanceDebourse): Observable<Avance> {
    return this.http.put<Avance>(
      this.baseUrl + '/avance/update/' + id.toString(),
      avanceDebourse
    );
  }

  addApprobation(avance: AvanceDebourse): Observable<AvanceDebourse> {
    return this.http.post<AvanceDebourse>(
      this.baseUrl + '/avance/addApprobation',
      avance
    );
  }

  addEcheancier(
    id: number,
    echeances: EcheanceAvance[]
  ): Observable<EcheanceAvance[]> {
    return this.http.post<EcheanceAvance[]>(
      this.baseUrl + '/avance/addecheancier/' + id.toString(),
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
