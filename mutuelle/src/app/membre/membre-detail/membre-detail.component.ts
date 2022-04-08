import { Component, OnInit } from '@angular/core';
import { Membre } from 'src/app/model/membre';

@Component({
  selector: 'app-membre-detail',
  templateUrl: './membre-detail.component.html',
  styleUrls: ['./membre-detail.component.scss']
})
export class MembreDetailComponent implements OnInit {

  membre: Membre = {};

  constructor() { }

  ngOnInit(): void {
  }

}
