import { Component, Input, OnInit } from '@angular/core';
import { Membre } from 'src/app/model/Membre';

@Component({
  selector: 'app-detail-avance-membre',
  templateUrl: './detail-avance-membre.component.html',
  styleUrls: ['./detail-avance-membre.component.scss'],
})
export class DetailAvanceMembreComponent implements OnInit {
  @Input() membre: Membre = new Membre();

  constructor() {}

  ngOnInit(): void {}
}
