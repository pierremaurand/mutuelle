import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { LoaderService } from 'src/app/services/loader.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-profil-membre',
  templateUrl: './profil-membre.component.html',
  styleUrls: ['./profil-membre.component.scss'],
})
export class ProfilMembreComponent implements OnInit {
  membreInfos: Membre = {};
  membre: MembreList = {};
  photo: string = '';

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private membreService: MembreService
  ) {}

  ngOnInit(): void {
    const idMembre = this.activatedRoute.snapshot.params['id'];
    if (idMembre) {
      this.membreService.getById(idMembre).subscribe((membre: Membre) => {
        this.membre = membre;
        this.photo = this.membreService.getPhotoUrl(this.membre.photo);
      });
    }
  }

  activer(): void {
    this.membre.estActif = !this.membre.estActif;
    this.membreService.update(this.membre, this.membre.id).subscribe(() => {});
  }

  cancel(): void {
    this.router.navigate(['/membres']);
  }
}
