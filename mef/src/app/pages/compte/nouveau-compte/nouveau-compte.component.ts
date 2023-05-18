import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Gabarit } from 'src/app/model/gabarit';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { MembreList } from 'src/app/model/membreList';
import { MvtCompte } from 'src/app/model/mvtCompte';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { TypeOperation } from 'src/app/model/typeoperation';
import { CompteService } from 'src/app/services/compte.service';
import { GabaritService } from 'src/app/services/gabarit.service';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-nouveau-compte',
  templateUrl: './nouveau-compte.component.html',
  styleUrls: ['./nouveau-compte.component.scss'],
})
export class NouveauCompteComponent implements OnInit {
  membre: MembreList = new MembreList();
  mvtCompte: MvtCompte = new MvtCompte();
  gabarits: Gabarit[] = [];
  SortbyParam = 'dateMvt';
  SortDirection = 'desc';
  @ViewChild('closeModal') modalClose: any;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private gabaritService: GabaritService,
    private compteService: CompteService,
    private membreService: MembreService
  ) {}

  ngOnInit(): void {
    // this.gabaritService.getAll().subscribe((gabarits: Gabarit[]) => {
    //   this.gabarits = gabarits;
    //   let idMembre = this.activatedRoute.snapshot.params['id'];
    //   this.membreService
    //     .getById(idMembre)
    //     .subscribe((membre: MembreList) => {});
    // });
  }

  // ajouterMvtCompte(): void {
  //   if (this.checkInfosMvt()) {
  //     this.mvtCompte.membreId = this.membreId;
  //     this.mvtCompte.gabaritId = 1;
  //     this.mvtComptes.push(this.mvtCompte);
  //     this.mvtCompte = new MvtCompte();
  //     this.modalClose.nativeElement.click();
  //     this.enregistrerCompte();
  //   }
  // }

  soldeCompte(): number {
    let solde = 0;
    // this.mvtComptes.map((mvtCompte) => {
    //   if (mvtCompte.typeOperation == TypeOperation.Credit) {
    //     solde += mvtCompte.montant ? mvtCompte.montant : 0;
    //   } else {
    //     solde -= mvtCompte.montant ? mvtCompte.montant : 0;
    //   }
    // });
    return solde;
  }

  getTypeOperation(typeOperation: number): string {
    const operation: string =
      'Note de ' + (typeOperation == TypeOperation.Credit ? 'Crédit' : 'Débit');
    return operation;
  }

  checkInfosMvt(): boolean {
    if (
      !this.mvtCompte.dateMvt ||
      !this.mvtCompte.typeOperation ||
      !this.mvtCompte.libelle ||
      !this.mvtCompte.montant
    ) {
      return false;
    }

    return true;
  }

  cancel(): void {
    this.router.navigate(['/comptes']);
  }
}
