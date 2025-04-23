import { Injectable } from '@angular/core';
import { Router, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Deboursement } from '../models/deboursement.model';
import { DeboursementService } from '../services/deboursement.service';

@Injectable({
  providedIn: 'root',
})
export class DeboursementResolver  {
  constructor(public deboursementService: DeboursementService) {}
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<Deboursement> {
    const id = route.paramMap.get('deboursementId');
    if (id) {
      return this.deboursementService.getDeboursementById(+id);
    }
    return of(new Deboursement());
  }
}
