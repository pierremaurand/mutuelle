import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Service } from '../model/service';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Service[]>{
    return this.http.get<Service[]>(this.baseUrl + '/service/services');
  }

  getById(id: number): Observable<Service> {
    return this.http.get<Service>(this.baseUrl + '/service/get/' + id.toString());
  }

  add(service: Service): Observable<any> {
    return this.http.post(this.baseUrl + '/service/add', service);
  }

  update(service: Service, id?: number): Observable<any> {
    return this.http.put(this.baseUrl + '/service/update/' + id?.toString(),service);
  }
}
