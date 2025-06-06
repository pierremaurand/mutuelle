import { Injectable } from '@angular/core';
import { Router, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { CompteService } from '../services/compte.service';
import { Mouvement } from '../models/mouvement';

@Injectable({
  providedIn: 'root',
})
export class MouvementsAvanceResolver  {
  constructor(public compteService: CompteService) {}
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<Mouvement[]> {
    const idAvance = route.paramMap.get('avanceId');
    if (idAvance) {
      return this.compteService.getMouvementsAvance(+idAvance);
    }
    return of([]);
  }
}
