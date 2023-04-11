import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LieuAffectation } from '../model/lieuAffectation';

@Injectable({
  providedIn: 'root',
})
export class LieuAffectationService {
  baseUrl = environment.baseUrl;
  imagesUrl = environment.imagesUrl;

  constructor(private http: HttpClient) {}

  getAll(): Observable<LieuAffectation[]> {
    return this.http.get<LieuAffectation[]>(
      this.baseUrl + '/lieuaffectation/lieuaffectations'
    );
  }

  getById(id?: number): Observable<LieuAffectation> {
    return this.http.get<LieuAffectation>(
      this.baseUrl + '/lieuaffectation/get/' + id?.toString()
    );
  }

  add(lieuaffectation: LieuAffectation): Observable<any> {
    return this.http.post(
      this.baseUrl + '/lieuaffectation/add',
      lieuaffectation
    );
  }

  update(lieuaffectation: LieuAffectation, id: number): Observable<any> {
    return this.http.put(
      this.baseUrl + '/lieuaffectation/update/' + id.toString(),
      lieuaffectation
    );
  }

  delete(id: number): Observable<any> {
    return this.http.delete(
      this.baseUrl + '/lieuaffectation/delete/' + id.toString()
    );
  }

  getImageUrl(): string {
    return this.imagesUrl + '/assets/images/building.png';
  }
}
