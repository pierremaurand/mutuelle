import { Component, OnInit } from '@angular/core';
import { Parametre } from 'src/app/model/parametre';
import { ParametreService } from 'src/app/services/parametre.service';

@Component({
  selector: 'app-parametre-list',
  templateUrl: './parametre-list.component.html',
  styleUrls: ['./parametre-list.component.scss']
})
export class ParametreListComponent implements OnInit {

  parametres: Parametre[] = [];

  constructor(private parametreService: ParametreService) { }

  ngOnInit(): void {
    this.parametreService.getAll().subscribe({
      next:(data) => {
        this.parametres = data;
        console.log(data);
      },
      error:(error) => {
        console.log("Httperror:");
        console.log(error);
      }
    });
  }

}
