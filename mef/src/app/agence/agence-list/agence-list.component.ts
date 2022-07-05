import { Component, OnInit } from '@angular/core';
import { Agence } from 'src/app/model/agence';
import { AgenceService } from 'src/app/services/agence.service';

@Component({
  selector: 'app-agence-list',
  templateUrl: './agence-list.component.html',
  styleUrls: ['./agence-list.component.scss']
})
export class AgenceListComponent implements OnInit {

  agences: Agence[] = [];

  constructor(private agenceService: AgenceService) { }

  ngOnInit(): void {
    this.agenceService.getAll().subscribe({
      next:(data) => {
        this.agences = data;
        console.log(data);
      },
      error:(error) => {
        console.log("Httperror:");
        console.log(error);
      }
    });
  }

}
