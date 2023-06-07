import { Component, OnInit } from '@angular/core';
import { Membre } from 'src/app/model/Membre';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-accueil',
  templateUrl: './accueil.component.html',
  styleUrls: ['./accueil.component.scss'],
})
export class AccueilComponent implements OnInit {
  constructor(private membreService: MembreService) {}

  ngOnInit(): void {
    this.membreService.getAll().subscribe((membres: Membre[]) => {
      this.membreService.membres = membres;
    });
  }
}
