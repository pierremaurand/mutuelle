import { Injectable } from '@angular/core';
import { MembreInfos } from '../model/membreInfos';

@Injectable({
  providedIn: 'root'
})
export class MembreService {

  constructor() { }

  getAll(): MembreInfos[]{
    return [];
  }

  getById() {

  }

  save(membre: MembreInfos) {

  }
}
