import { Component, Input, OnInit } from '@angular/core';
import { Membre } from 'src/app/model/membre';
import { MembreList } from 'src/app/model/membreList';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  @Input() membre: Membre|undefined;
  constructor(private membreService: MembreService) { }

  ngOnInit(): void {
  }

  afficheAgence(): string|undefined {
    if(this.membre) {
      return this.membreService.afficheAgence(this.membre.agence);
    }
    return undefined;
  }

  afficheService(): string|undefined {
    if(this.membre) {
      return this.membreService.afficheService(this.membre.service);
    }
    return undefined;
  }

  afficheSexe(): string|undefined {
    if(this.membre) {
      return this.membreService.afficheSexe(this.membre.sexe);
    }
    return undefined;
  }

}
