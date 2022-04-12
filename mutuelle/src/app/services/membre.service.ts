import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Membre } from "../model/Membre";

@Injectable({
  providedIn: 'root'
})
export class MembreService {

  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Membre[]>{
    return this.http.get<Membre[]>(this.baseUrl + '/membre/membres');
  }

  getById(id: number): Observable<Membre> {
    return this.http.get<Membre>(this.baseUrl + '/membre/get/' + id.toString());
  }

  add(membre: Membre): Observable<any> {
    return this.http.post(this.baseUrl + '/membre/add', membre);
  }

  update(membre: Membre, id?: number): Observable<any> {
    return this.http.put(this.baseUrl + '/membre/update/' + id?.toString(),membre);
  }

  addPhoto(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file, file.name);
    return this.http.post(this.baseUrl + '/membre/add/photo', formData);
  }
}
