import { Component, OnInit } from '@angular/core';
import { MembreList } from 'src/app/model/membreList';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-accueil',
  templateUrl: './accueil.component.html',
  styleUrls: ['./accueil.component.scss'],
})
export class AccueilComponent implements OnInit {
  constructor(private membreService: MembreService) {}

  ngOnInit(): void {
    this.membreService.getAll().subscribe((membres: MembreList[]) => {
      this.membreService.membres = membres;
    });
  }
}
