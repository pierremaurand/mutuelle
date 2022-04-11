import { Component, OnInit } from '@angular/core';
import { Sexe } from 'src/app/model/sexe';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-sexe-list',
  templateUrl: './sexe-list.component.html',
  styleUrls: ['./sexe-list.component.scss']
})
export class SexeListComponent implements OnInit {

  sexes: Sexe[] = [];

  constructor(private sexeService: SexeService) { }

  ngOnInit(): void {
    this.sexeService.getAll().subscribe({
      next:(data) => {
        this.sexes = data;
        console.log(data);
      },
      error:(error) => {
        console.log("Httperror:");
        console.log(error);
      }
    });
  }
}
