import { Component, Input, OnInit } from '@angular/core';
import { Membre } from 'src/app/model/membre';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  membreId: number = 0;
  membre: Membre|undefined;

  constructor(
    private membreService: MembreService
  ) { }

  ngOnInit(): void {
    if(localStorage.getItem('MembreId')) {
      this.membreId = +(localStorage.getItem('MembreId')||'');
      this.loadInfosMembre();
    }
  }

  loadInfosMembre(): void {
    if (this.membreId) {
      this.membreService.getMembreById(this.membreId).subscribe({
        next: (data) => {
          this.membre = data;
        },
      });
    }
  }

}
