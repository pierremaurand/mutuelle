import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Compte } from 'src/app/model/compte';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-detail-compte',
  templateUrl: './detail-compte.component.html',
  styleUrls: ['./detail-compte.component.scss'],
})
export class DetailCompteComponent implements OnInit {
  @Input() compte: Compte = new Compte();
  photo: string = '';
  @Input() hideIcons: boolean = false;

  constructor(private membreService: MembreService, private router: Router) {}

  ngOnInit(): void {
    this.photo = this.membreService.getPhotoUrl();
  }

  modifier(): void {
    this.router.navigate(['nouveaucompte', this.compte.id]);
  }
}
