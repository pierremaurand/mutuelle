import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Parametre } from 'src/app/model/parametre';

@Component({
  selector: 'app-parametre',
  templateUrl: './parametre.component.html',
  styleUrls: ['./parametre.component.scss']
})
export class ParametreComponent implements OnInit {

  @Input() parametre: Parametre = {};

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  update() {
    this.router.navigate(['add-parametre',this.parametre.id]);
  }

}
