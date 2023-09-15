import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { HeaderState } from 'src/app/model/header';
import { AuthService } from 'src/app/services/auth.service';
import { HeaderService } from 'src/app/services/header.service';
import { LoaderService } from 'src/app/services/loader.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  photo: string = '';
  userName: any;
  search: string = '';

  constructor(
    private authService: AuthService,
    private headerService: HeaderService
  ) {}

  ngOnInit(): void {
    this.photo = this.authService.getPhotoUrl();
    if (localStorage.getItem('userName') != null) {
      this.userName = localStorage.getItem('userName');
    }
  }

  doClear(): void {
    this.search = '';
    this.doSearch();
  }

  doSearch(): void {
    localStorage.setItem('search', this.search);
    this.headerService.search(this.search);
  }
}
