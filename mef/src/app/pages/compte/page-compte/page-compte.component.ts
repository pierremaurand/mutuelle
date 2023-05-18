import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CompteList } from 'src/app/model/compteList';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { MvtCompte } from 'src/app/model/mvtCompte';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { TypeOperation } from 'src/app/model/typeoperation';
import { CompteService } from 'src/app/services/compte.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-page-compte',
  templateUrl: './page-compte.component.html',
  styleUrls: ['./page-compte.component.scss'],
})
export class PageCompteComponent implements OnInit {
  comptes: CompteList[] = [];

  constructor(private compteService: CompteService, private router: Router) {}

  ngOnInit(): void {
    this.compteService.getAllComptes().subscribe((comptes: CompteList[]) => {
      this.comptes = comptes;
    });
  }

  nouveauCompte(): void {
    this.router.navigate(['/nouveaucompte']);
  }

  navigate(id: number): void {
    this.router.navigate(['/nouveaucompte/' + id]);
  }

  getSolde(id?: number): number {
    let solde = 0;
    // this.mvtComptes
    //   .filter(({ membreId }) => membreId == id)
    //   .forEach((m) => {
    //     if (m.typeOperation == TypeOperation.Credit) {
    //       solde += m.montant ?? 0;
    //     } else {
    //       solde -= m.montant ?? 0;
    //     }
    //   });

    return solde;
  }
}
