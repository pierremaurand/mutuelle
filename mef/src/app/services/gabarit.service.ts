import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Gabarit } from '../model/gabarit';
import { Operation } from '../model/operation';

@Injectable({
  providedIn: 'root',
})
export class GabaritService {
  baseUrl = environment.baseUrl;
  imagesUrl = environment.imagesUrl;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Gabarit[]> {
    return this.http.get<Gabarit[]>(this.baseUrl + '/gabarit/gabarits');
  }

  getAllOperations(): Observable<Operation[]> {
    return this.http.get<Operation[]>(this.baseUrl + '/gabarit/operations');
  }

  getAllOperationsGabarit(id: number): Observable<Operation[]> {
    return this.http.get<Operation[]>(
      this.baseUrl + '/gabarit/get/operations/' + id.toString()
    );
  }

  getById(id: number): Observable<Gabarit> {
    return this.http.get<Gabarit>(
      this.baseUrl + '/gabarit/get/' + id.toString()
    );
  }

  add(gabarit: Gabarit): Observable<number> {
    return this.http.post<number>(this.baseUrl + '/gabarit/add', gabarit);
  }

  update(gabarit: Gabarit, id: number): Observable<any> {
    return this.http.put(
      this.baseUrl + '/gabarit/update/' + id.toString(),
      gabarit
    );
  }

  deleteGabarit(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + '/gabarit/delete/' + id.toString());
  }

  getImageUrl(): string {
    return this.imagesUrl + '/assets/images/gabarit_image.png';
  }
}
