import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Membre } from 'src/app/model/Membre';
import { MembreService } from 'src/app/services/membre.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-page-membre',
  templateUrl: './page-membre.component.html',
  styleUrls: ['./page-membre.component.scss'],
})
export class PageMembreComponent implements OnInit {
  imagesUrl = environment.imagesUrl;
  membres: Membre[] = [];

  constructor(private membreService: MembreService, private router: Router) {}

  ngOnInit(): void {}

  nouveauMembre(): void {
    this.router.navigate(['nouveaumembre']);
  }
}
