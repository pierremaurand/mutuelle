import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Poste } from '../model/poste';

@Injectable({
  providedIn: 'root',
})
export class PosteService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Poste[]> {
    return this.http.get<Poste[]>(this.baseUrl + '/poste/postes');
  }

  getById(id: number): Observable<Poste> {
    return this.http.get<Poste>(this.baseUrl + '/poste/get/' + id.toString());
  }

  add(poste: Poste): Observable<any> {
    return this.http.post(this.baseUrl + '/poste/add', poste);
  }

  update(poste: Poste, id: number): Observable<any> {
    return this.http.put(
      this.baseUrl + '/poste/update/' + id.toString(),
      poste
    );
  }

  deletePoste(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + '/poste/delete/' + id.toString());
  }
}
