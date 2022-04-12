import { Component, Input, OnInit } from '@angular/core';
import { Membre } from "src/app/model/Membre";
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-membre',
  templateUrl: './membre.component.html',
  styleUrls: ['./membre.component.scss']
})
export class MembreComponent implements OnInit {

  @Input() membre: Membre = {};
  baseUrl = environment.imagesUrl;

  constructor() { }

  ngOnInit(): void {
  }

  btnClasse():string {
    if(this.membre.sexe?.toLowerCase() === 'masculin'){
      return "btn btn-primary";
    }
    return "btn btn-danger";
  }

}
