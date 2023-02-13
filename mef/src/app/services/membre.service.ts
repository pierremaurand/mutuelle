import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Membre } from '../model/Membre';
import { UploadImage } from '../model/uploadImage';

@Injectable({
  providedIn: 'root',
})
export class MembreService {
  baseUrl = environment.baseUrl;
  imagesUrl = environment.imagesUrl;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Membre[]> {
    return this.http.get<Membre[]>(this.baseUrl + '/membre/membres');
  }

  getById(id: number): Observable<Membre> {
    return this.http.get<Membre>(this.baseUrl + '/membre/get/' + id.toString());
  }

  add(membre: Membre): Observable<any> {
    return this.http.post(this.baseUrl + '/membre/add', membre);
  }

  import(membres: Membre[]): Observable<any> {
    return this.http.post(this.baseUrl + '/membre/import', membres);
  }

  addImage(uploadImage: UploadImage): Observable<any> {
    return this.http.post(this.baseUrl + '/membre/addImage', uploadImage);
  }

  update(membre: Membre, id: number): Observable<any> {
    return this.http.put(
      this.baseUrl + '/membre/update/' + id.toString(),
      membre
    );
  }

  deleteMembre(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + '/membre/delete/' + id.toString());
  }

  getPhotoUrl(membre: Membre): string {
    if (membre.photo) {
      return this.imagesUrl + '/assets/images/' + membre.photo;
      // } else {
      //   if (membre.sexeId) {
      //     return (
      //       this.imagesUrl +
      //       '/assets/images/' +
      //       (membre.sexeId === 1 ? 'default_man.jpg' : 'default_woman.jpg')
      //     );
      //   }
    }
    return this.imagesUrl + '/assets/images/default_man.jpg';
  }
}
