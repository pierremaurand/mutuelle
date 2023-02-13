import { Component, Input, OnInit } from '@angular/core';
import { Membre } from 'src/app/model/Membre';

@Component({
  selector: 'app-detail-credit-membre',
  templateUrl: './detail-credit-membre.component.html',
  styleUrls: ['./detail-credit-membre.component.scss'],
})
export class DetailCreditMembreComponent implements OnInit {
  @Input() membre: Membre = new Membre();

  constructor() {}

  ngOnInit(): void {}
}
