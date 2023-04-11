import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginReq } from 'src/app/model/loginReq';
import { LoginRes } from 'src/app/model/loginRes';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-page-login',
  templateUrl: './page-login.component.html',
  styleUrls: ['./page-login.component.scss'],
})
export class PageLoginComponent implements OnInit {
  loginReq: LoginReq = new LoginReq();

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {}

  login(): void {
    this.authService.authUser(this.loginReq).subscribe((loginRes: LoginRes) => {
      this.authService.setInfosUser(loginRes);
      this.router.navigate(['']);
    });
  }
}
