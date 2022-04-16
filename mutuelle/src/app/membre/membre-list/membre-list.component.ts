import { Component, OnInit } from '@angular/core';
import { Membre } from "src/app/model/membre";
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-membre-list',
  templateUrl: './membre-list.component.html',
  styleUrls: ['./membre-list.component.scss']
})
export class MembreListComponent implements OnInit {

  listeMembres: Membre[] = [];

  constructor(private membreService: MembreService) { }

  ngOnInit(): void {
    this.membreService.getAll().subscribe({
      next:(data) => {
        this.listeMembres = data;
        console.log(data);
      }
    });
  }

}
