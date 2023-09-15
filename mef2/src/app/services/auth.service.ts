import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginReq } from '../model/loginReq';
import { LoginRes } from '../model/loginRes';
import { UserForLogin, UserForRegister } from '../model/user';

@Injectable({
  providedIn: 'root',
})
export class AuthService implements CanActivate {
  baseUrl = environment.baseUrl;
  imagesUrl = environment.imagesUrl;

  constructor(private http: HttpClient, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | boolean
    | UrlTree
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree> {
    return this.isAuthenticateUser();
  }

  authUser(loginReq: LoginReq): Observable<LoginRes> {
    return this.http.post<LoginRes>(
      this.baseUrl + '/utilisateur/login',
      loginReq
    );
  }

  registerUser(user: UserForRegister) {
    return this.http.post(this.baseUrl + '/utilisateur/add', user);
  }

  getPhotoUrl(): string {
    return this.imagesUrl + '/assets/images/default_man.jpg';
  }

  setInfosUser(loginRes: LoginRes): void {
    localStorage.setItem('userName', loginRes.nom);
    localStorage.setItem('token', loginRes.token);
  }

  isAuthenticateUser(): boolean {
    const token = localStorage.getItem('token');
    if (token && !this.tokenExpired(token)) {
      return true;
    }
    this.removeItem();
    this.router.navigate(['login']);
    return false;
  }

  removeItem(): void {
    localStorage.clear();
  }

  private tokenExpired(token: string) {
    const expiry = JSON.parse(atob(token.split('.')[1])).exp;
    return Math.floor(new Date().getTime() / 1000) >= expiry;
  }
}
