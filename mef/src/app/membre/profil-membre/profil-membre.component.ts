import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Membre } from 'src/app/model/Membre';

@Component({
  selector: 'app-profil-membre',
  templateUrl: './profil-membre.component.html',
  styleUrls: ['./profil-membre.component.scss'],
})
export class ProfilMembreComponent implements OnInit {
  @Input() membre?: Membre;
  @Input() showDetailsBtn: boolean = true;

  constructor(private router: Router) {}

  ngOnInit(): void {}

  showDetails(): void {
    this.router.navigate(['home/membres/show', this.membre?.id]);
  }
}
