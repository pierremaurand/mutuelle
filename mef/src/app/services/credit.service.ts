import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Credit } from '../model/credit';

@Injectable({
  providedIn: 'root'
})
export class CreditService {
  baseUrl = environment.baseUrl;

  constructor(
    private http: HttpClient
  ) { }

  getAllMembreCredit(membreId: number): Observable<Credit[]>{
    return this.http.get<Credit[]>(this.baseUrl + '/credit/credits/membre/' + membreId.toString());
  }
}
