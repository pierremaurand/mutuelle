import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserForLogin, UserForRegister } from '../model/user';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl = environment.baseUrl;
  imagesUrl = environment.imagesUrl;

  constructor(private http: HttpClient) {}

  authUser(user: UserForLogin) {
    return this.http.post(this.baseUrl + '/account/login', user);
  }

  registerUser(user: UserForRegister) {
    return this.http.post(this.baseUrl + '/account/register', user);
  }

  getPhotoUrl(): string {
    return this.imagesUrl + '/assets/images/default_man.jpg';
  }
}
