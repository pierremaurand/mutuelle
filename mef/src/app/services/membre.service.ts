import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Membre } from '../model/Membre';
import { MembreList } from '../model/membreList';
import { MvtCompte } from '../model/mvtCompte';
import { MvtMembre } from '../model/mvtMembre';
import { UploadImage } from '../model/uploadImage';

@Injectable({
  providedIn: 'root',
})
export class MembreService {
  [x: string]: any;
  baseUrl = environment.baseUrl;
  imagesUrl = environment.imagesUrl;
  public static membres: MembreList[] = [];

  constructor(private http: HttpClient) {}

  getAll(): Observable<MembreList[]> {
    return this.http.get<MembreList[]>(this.baseUrl + '/membre/membres');
  }

  addMvtCompte(id: number, mvtComptes: MvtCompte[]): Observable<any> {
    return this.http.post<any>(
      this.baseUrl + '/membre/addMvtComptes/' + id.toString(),
      mvtComptes
    );
  }

  getById(id?: number): Observable<Membre> {
    return this.http.get<Membre>(
      this.baseUrl + '/membre/get/' + id?.toString()
    );
  }

  getInfosMembre(id: number): Observable<MembreList> {
    return this.http.get<MembreList>(
      this.baseUrl + '/membre/get/infos/' + id.toString()
    );
  }

  getMvtMembre(id?: number): Observable<MvtMembre> {
    return this.http.get<MvtMembre>(
      this.baseUrl + '/membre/get/mvtmembre/' + id?.toString()
    );
  }

  add(membre: Membre): Observable<number> {
    return this.http.post<number>(this.baseUrl + '/membre/add', membre);
  }

  getDetails(id: number): Observable<Membre> {
    return this.http.get<Membre>(
      this.baseUrl + '/membre/getdetails/' + id.toString()
    );
  }

  import(membres: Membre[]): Observable<any> {
    return this.http.post(this.baseUrl + '/membre/import', membres);
  }

  addImage(uploadImage: UploadImage): Observable<any> {
    return this.http.post(this.baseUrl + '/membre/addImage', uploadImage);
  }

  update(membre: Membre, id?: number): Observable<any> {
    return this.http.put(
      this.baseUrl + '/membre/update/' + id?.toString(),
      membre
    );
  }

  deleteMembre(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + '/membre/delete/' + id.toString());
  }

  getPhotoUrl(photo?: string): string {
    if (photo && photo !== '') {
      return this.imagesUrl + '/assets/images/' + photo;
    }
    return this.imagesUrl + '/assets/images/default_man.jpg';
  }
}
