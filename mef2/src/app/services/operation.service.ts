import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Operation } from '../model/operation';

@Injectable({
  providedIn: 'root',
})
export class OperationService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Operation[]> {
    return this.http.get<Operation[]>(this.baseUrl + '/operation/operations');
  }

  getByGabarit(id?: number): Observable<Operation[]> {
    return this.http.get<Operation[]>(
      this.baseUrl + '/operation/operations/' + id?.toString()
    );
  }

  getById(id?: number): Observable<Operation> {
    return this.http.get<Operation>(
      this.baseUrl + '/operation/get/' + id?.toString()
    );
  }

  add(operation: Operation): Observable<any> {
    return this.http.post(this.baseUrl + '/operation/add', operation);
  }

  addOperations(id: number, operations: Operation[]): Observable<any> {
    return this.http.post(
      this.baseUrl + '/operation/addoperations/' + id.toString(),
      operations
    );
  }

  update(operation: Operation, id: number): Observable<any> {
    return this.http.put(
      this.baseUrl + '/operation/update/' + id.toString(),
      operation
    );
  }

  delete(id: number): Observable<any> {
    return this.http.delete(
      this.baseUrl + '/operation/delete/' + id.toString()
    );
  }
}
