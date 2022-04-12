import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Membre } from "src/app/model/Membre";
import { MembreService } from 'src/app/services/membre.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-membre-detail',
  templateUrl: './membre-detail.component.html',
  styleUrls: ['./membre-detail.component.scss']
})
export class MembreDetailComponent implements OnInit {

  membreId?: number;
  baseUrl = environment.imagesUrl;
  membre: Membre = {};
  photo?: string;
  cotisations?: number;
  mois?: number;
  lastCotisationDate?: Date;
  lastCotisation?: number;
  avances?: number;
  credits?: number;

  constructor(private route: ActivatedRoute,
    private membreService: MembreService
  ) { }

  ngOnInit(): void {
    this.membreId = +this.route.snapshot.params['id'];
    this.membreId = +this.route.snapshot.params['id'];
    if(this.membreId) {
      this.membreService.getById(this.membreId).subscribe({
        next:(data) => {
          this.membre = data;
          this.photo = this.baseUrl + this.membre.photo;
        }
      });
      this.cotisations = 1000000;
      this.mois = 12;
      this.lastCotisationDate = new Date('12-24-2021');
      this.lastCotisation = 45000;
    }
  }

}
