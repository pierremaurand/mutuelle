import { Component, Input, OnInit } from '@angular/core';
import { Membre } from 'src/app/model/Membre';

@Component({
  selector: 'app-detail-cotisation-membre',
  templateUrl: './detail-cotisation-membre.component.html',
  styleUrls: ['./detail-cotisation-membre.component.scss'],
})
export class DetailCotisationMembreComponent implements OnInit {
  @Input() membre: Membre = new Membre();

  constructor() {}

  ngOnInit(): void {}
}
