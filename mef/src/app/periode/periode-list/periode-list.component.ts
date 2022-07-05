import { Component, OnInit } from '@angular/core';
import { Periode } from 'src/app/model/periode';
import { PeriodeService } from 'src/app/services/periode.service';

@Component({
  selector: 'app-periode-list',
  templateUrl: './periode-list.component.html',
  styleUrls: ['./periode-list.component.scss']
})
export class PeriodeListComponent implements OnInit {

  periodes: Periode[] = [];

  constructor(private periodeService: PeriodeService) { }

  ngOnInit(): void {
    this.periodeService.getAll().subscribe({
      next:(data) => {
        this.periodes = data;
        console.log(data);
      },
      error:(error) => {
        console.log("Httperror:");
        console.log(error);
      }
    });
  }

}
