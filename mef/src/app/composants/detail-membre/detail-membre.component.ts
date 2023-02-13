import { Component, Input, OnInit } from '@angular/core';
import { Membre } from 'src/app/model/Membre';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-detail-membre',
  templateUrl: './detail-membre.component.html',
  styleUrls: ['./detail-membre.component.scss'],
})
export class DetailMembreComponent implements OnInit {
  @Input() membre: Membre = new Membre();

  constructor(private membreService: MembreService) {}

  ngOnInit(): void {
    this.membre.photoUrl = this.membreService.getPhotoUrl(this.membre);
  }
}
