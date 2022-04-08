import { Component, Input, OnInit } from '@angular/core';
import { Membre } from 'src/app/model/membre';

@Component({
  selector: 'app-membre',
  templateUrl: './membre.component.html',
  styleUrls: ['./membre.component.scss']
})
export class MembreComponent implements OnInit {

  @Input() membre: Membre = {};

  constructor() { }

  ngOnInit(): void {
  }

}
