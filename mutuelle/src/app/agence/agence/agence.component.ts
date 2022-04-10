import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Agence } from 'src/app/model/agence';

@Component({
  selector: 'app-agence',
  templateUrl: './agence.component.html',
  styleUrls: ['./agence.component.scss']
})
export class AgenceComponent implements OnInit {

  @Input() agence: Agence = {};

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  update() {
    this.router.navigate(['add-agence',this.agence.id]);
  }

}
