import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Periode } from 'src/app/model/periode';

@Component({
  selector: 'app-periode',
  templateUrl: './periode.component.html',
  styleUrls: ['./periode.component.scss']
})
export class PeriodeComponent implements OnInit {

  @Input() periode: Periode = {};

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  update() {
    this.router.navigate(['add-periode',this.periode.id]);
  }

}
