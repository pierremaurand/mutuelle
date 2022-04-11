import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Sexe } from 'src/app/model/sexe';

@Component({
  selector: 'app-sexe',
  templateUrl: './sexe.component.html',
  styleUrls: ['./sexe.component.scss']
})
export class SexeComponent implements OnInit {

  @Input() sexe: Sexe = {};

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  update() {
    this.router.navigate(['add-service',this.sexe.id]);
  }
}
