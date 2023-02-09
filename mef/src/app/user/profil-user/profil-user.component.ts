import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-profil-user',
  templateUrl: './profil-user.component.html',
  styleUrls: ['./profil-user.component.scss'],
})
export class ProfilUserComponent implements OnInit {
  photo: string = '';
  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.photo = this.authService.getPhotoUrl();
  }
}
