import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CompteComptable } from '../model/comptecomptable';
import { Gabarit } from '../model/gabarit';
import { Operation } from '../model/operation';
import { TypeOperation } from '../model/typeoperation';

@Injectable({
  providedIn: 'root',
})
export class GabaritService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Gabarit[]> {
    return this.http.get<Gabarit[]>(this.baseUrl + '/gabarit/gabarits');
  }

  getById(id: number): Observable<Gabarit> {
    return this.http.get<Gabarit>(
      this.baseUrl + '/gabarit/get/' + id.toString()
    );
  }

  add(gabarit: Gabarit): Observable<any> {
    return this.http.post(this.baseUrl + '/gabarit/add', gabarit);
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

  getTypeOperation(typeOperation: number): string {
    return typeOperation == TypeOperation.Credit ? 'Crédit' : 'Débit';
  }

  getCompte(id: number, comptes: CompteComptable[]): string {
    const compte = comptes.find((e) => e.id == id);
    return compte ? compte.compte : '';
  }
}
