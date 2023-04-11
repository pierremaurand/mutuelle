import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Credit } from '../model/credit';
import { EcheanceCredit } from '../model/echeanceCredit';
import { Membre } from '../model/Membre';
import { MvtCompte } from '../model/mvtCompte';

@Injectable({
  providedIn: 'root',
})
export class CreditService {
  baseUrl = environment.baseUrl;
  imagesUrl = environment.imagesUrl;

  constructor(private http: HttpClient) {}

  getAllMembres(): Observable<Membre[]> {
    return this.http.get<Membre[]>(this.baseUrl + '/credit/membres');
  }

  getAllEcheances(): Observable<EcheanceCredit[]> {
    return this.http.get<EcheanceCredit[]>(this.baseUrl + '/credit/echeances');
  }

  getAllEcheancesCredit(creditId?: number): Observable<EcheanceCredit[]> {
    return this.http.get<EcheanceCredit[]>(
      this.baseUrl + '/credit/echeances/' + creditId?.toString()
    );
  }

  getAll(): Observable<Credit[]> {
    return this.http.get<Credit[]>(this.baseUrl + '/credit/credits');
  }

  getById(id: number): Observable<Credit> {
    return this.http.get<Credit>(this.baseUrl + '/credit/get/' + id.toString());
  }

  getPhotoUrl(photo?: string): string {
    if (photo && photo !== '') {
      return this.imagesUrl + '/assets/images/' + photo;
    }
    return this.imagesUrl + '/assets/images/default_man.jpg';
  }

  add(credit: Credit): Observable<any> {
    return this.http.post<Credit>(this.baseUrl + '/credit/add', credit);
  }

  update(id?: number, credit?: Credit): Observable<any> {
    return this.http.put(
      this.baseUrl + '/credit/update/' + id?.toString(),
      credit
    );
  }

  addEcheances(echeances: EcheanceCredit[]): Observable<any> {
    return this.http.post<EcheanceCredit[]>(
      this.baseUrl + '/credit/addecheances',
      echeances
    );
  }

  addMvtComptes(mvts: MvtCompte[]): Observable<any> {
    return this.http.post<MvtCompte[]>(
      this.baseUrl + '/credit/addmvtcomptes',
      mvts
    );
  }
}
