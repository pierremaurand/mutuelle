import { Component, Input, OnInit } from '@angular/core';
import { Membre } from 'src/app/model/Membre';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-detail-compte-membre',
  templateUrl: './detail-compte-membre.component.html',
  styleUrls: ['./detail-compte-membre.component.scss'],
})
export class DetailCompteMembreComponent implements OnInit {
  @Input() membre: Membre = new Membre();

  constructor(private membreService: MembreService) {}

  ngOnInit(): void {
    this.membre.photoUrl = this.membreService.getPhotoUrl(this.membre);
  }
}
