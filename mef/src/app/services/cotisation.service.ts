import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cotisation } from '../model/cotisation';
import { Membre } from '../model/Membre';
import { Mois } from '../model/mois';
import { CotisationList } from '../model/cotisationList';

@Injectable({
  providedIn: 'root',
})
export class CotisationService {
  baseUrl = environment.baseUrl;
  imagesUrl = environment.imagesUrl;

  constructor(private http: HttpClient) {}

  getAllCotisations(): Observable<CotisationList[]> {
    return this.http.get<CotisationList[]>(
      this.baseUrl + '/cotisation/cotisations'
    );
  }

  getAllMois(): Observable<Mois[]> {
    return this.http.get<Mois[]>(this.baseUrl + '/cotisation/mois');
  }

  getById(id?: number): Observable<Membre> {
    return this.http.get<Membre>(
      this.baseUrl + '/cotisation/get/' + id?.toString()
    );
  }

  getAllCotisationsById(id?: number): Observable<Cotisation[]> {
    return this.http.get<Cotisation[]>(
      this.baseUrl + '/cotisation/cotisations/' + id?.toString()
    );
  }

  addCotisations(cotisations: Cotisation[]): Observable<any> {
    return this.http.post<Cotisation[]>(
      this.baseUrl + '/cotisation/addcotisations',
      cotisations
    );
  }
}
