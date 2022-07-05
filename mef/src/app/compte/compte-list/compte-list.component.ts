import { Component, OnInit } from '@angular/core';
import { Compte } from 'src/app/model/compte';
import { CompteService } from 'src/app/services/compte.service';

@Component({
  selector: 'app-compte-list',
  templateUrl: './compte-list.component.html',
  styleUrls: ['./compte-list.component.scss']
})
export class CompteListComponent implements OnInit {

  comptes: Compte[] = [];

  constructor(private compteService: CompteService) { }

  ngOnInit(): void {
    this.compteService.getAll().subscribe({
      next:(data) => {
        this.comptes = data;
        console.log(data);
      },
      error:(error) => {
        console.log("Httperror:");
        console.log(error);
      }
    });
  }

}
