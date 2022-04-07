import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Property } from '../model/property';
import { environment } from 'src/environments/environment';
import { IKeyValuePair } from '../model/ikeyvaluepair';
import { City } from '../model/city';

@Injectable({
  providedIn: 'root',
})
export class HousingService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) {}

  getAllCities(): Observable<City[]> {
    return this.http.get<City[]>(this.baseUrl + '/city/cities');
  }

  getAllPropertyTypes(): Observable<IKeyValuePair[]> {
    return this.http.get<IKeyValuePair[]>(this.baseUrl + '/propertytype/list');
  }

  getAllFurnishingTypes(): Observable<IKeyValuePair[]> {
    return this.http.get<IKeyValuePair[]>(
      this.baseUrl + '/furnishingtype/list'
    );
  }

  getProperty(id: number) {
    return this.http.get<Property>(
      this.baseUrl + '/property/detail/' + id.toString()
    );
  }

  getAllProperties(SellRent?: number): Observable<Property[]> {
    return this.http.get<Property[]>(
      this.baseUrl + '/property/list/' + SellRent?.toString()
    );
  }

  addProperty(property: Property): Observable<any> {
    return this.http.post(
      this.baseUrl + '/property/add',
      property,
    );
  }

  uploadPhoto(file: File, id: number): Observable<any> {
    const formData = new FormData();
    formData.append('file', file, file.name);
    return this.http.post(this.baseUrl + '/property/add/photo/' + id, formData, {reportProgress: true, observe: 'events'});
  }

  newPropID(): number {
    if (localStorage.getItem('PID')) {
      localStorage.setItem(
        'PID',
        String(+(localStorage.getItem('PID') || '') + 1)
      );
    } else {
      localStorage.setItem('PID', '101');
    }
    return +(localStorage.getItem('PID') || '');
  }

  getPropertyAge(dateOfEstablishment: string): string {
    const today = new Date();
    let estDate = new Date();
    if (dateOfEstablishment) {
      estDate = new Date(dateOfEstablishment);
    }
    let age = today.getFullYear() - estDate.getFullYear();
    const m = today.getMonth() - estDate.getMonth();

    // Current month smaller than establishment month or
    // Same month but current date smaller than establishment date
    if (m < 0 || (m === 0 && today.getDate() < estDate.getDate())) {
      age--;
    }

    // Establishment date is future date
    if (today < estDate) {
      return '0';
    }

    // Age is les than a year
    if (age === 0) {
      return 'Less than a year';
    }

    return age.toString();
  }
}
