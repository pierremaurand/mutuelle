import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Membre } from "src/app/model/Membre";

@Component({
  selector: 'app-membre-detail',
  templateUrl: './membre-detail.component.html',
  styleUrls: ['./membre-detail.component.scss']
})
export class MembreDetailComponent implements OnInit {

  membreId?: number;
  membre: Membre = {};

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.membreId = +this.route.snapshot.params['id'];
  }

}
