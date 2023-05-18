import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Membre } from 'src/app/model/Membre';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { MembreList } from 'src/app/model/membreList';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { UploadImage } from 'src/app/model/uploadImage';
import { Utilisateur } from 'src/app/model/utilisateur';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { LoaderService } from 'src/app/services/loader.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';
import { UtilisateurService } from 'src/app/services/utilisateur.service';

@Component({
  selector: 'app-nouvel-utilisateur',
  templateUrl: './nouvel-utilisateur.component.html',
  styleUrls: ['./nouvel-utilisateur.component.scss'],
})
export class NouvelUtilisateurComponent implements OnInit {
  utilisateur: Utilisateur = new Utilisateur();
  membres: MembreList[] = [];
  membre: MembreList = new MembreList();

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private membreService: MembreService,
    private utilisateurService: UtilisateurService
  ) {}

  ngOnInit(): void {
    this.membreService.getAll().subscribe((membres: MembreList[]) => {
      this.membres = membres;
      const idUtilisateur = this.activatedRoute.snapshot.params['id'];
      if (idUtilisateur) {
        this.utilisateurService
          .getById(idUtilisateur)
          .subscribe((utilisateur: Utilisateur) => {
            this.utilisateur = utilisateur;
            this.changeMembre();
          });
      }
    });
  }

  changeMembre(): void {
    var membre = this.membres.find((m) => m.id == this.utilisateur.membreId);
    if (membre) {
      this.membre = membre;
    }
  }

  enregistrerInfos(): void {
    if (this.validationFormulaire() == true) {
      if (this.utilisateur.id != 0) {
        this.utilisateurService
          .update(this.utilisateur, this.utilisateur.id)
          .subscribe((value: any) => {
            this.cancel();
          });
      } else {
        this.utilisateurService
          .add(this.utilisateur)
          .subscribe((id: number) => {
            this.cancel();
          });
      }
    }
  }

  validationFormulaire(): boolean {
    if (this.utilisateur.membreId == 0) {
      return false;
    }
    if (this.utilisateur.nomUtilisateur == '') {
      return false;
    }
    if (
      this.utilisateur.id == 0 &&
      (this.utilisateur.password == '' ||
        this.utilisateur.password != this.utilisateur.confirmPassword)
    ) {
      return false;
    }
    if (this.utilisateur.type == 0) {
      return false;
    }
    return true;
  }

  cancel(): void {
    this.router.navigate(['/utilisateurs']);
  }
}
