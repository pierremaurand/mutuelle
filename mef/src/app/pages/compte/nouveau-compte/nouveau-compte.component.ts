import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Gabarit } from 'src/app/model/gabarit';
import { MembreList } from 'src/app/model/membreList';
import { MvtCompte } from 'src/app/model/mvtCompte';
import { TypeOperation } from 'src/app/model/typeoperation';
import { CompteService } from 'src/app/services/compte.service';
import { GabaritService } from 'src/app/services/gabarit.service';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-nouveau-compte',
  templateUrl: './nouveau-compte.component.html',
  styleUrls: ['./nouveau-compte.component.scss'],
})
export class NouveauCompteComponent implements OnInit {
  membre: MembreList = new MembreList();
  idMembre: number = 0;
  mvtCompte: MvtCompte = new MvtCompte();
  gabarits: Gabarit[] = [];
  mouvements: MvtCompte[] = [];
  SortbyParam = 'dateMvt';
  SortDirection = 'desc';

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private gabaritService: GabaritService,
    private compteService: CompteService,
    private membreService: MembreService
  ) {}

  ngOnInit(): void {
    this.idMembre = this.activatedRoute.snapshot.params['id'];
    this.gabaritService.getAllActive().subscribe((gabarits: Gabarit[]) => {
      this.gabarits = gabarits;
    });
    if (this.idMembre) {
      this.membreService
        .getInfosMembre(this.idMembre)
        .subscribe((membre: MembreList) => {
          this.membre = membre;
        });
    }
  }

  ajouterMvtCompte(): void {
    // if (this.checkInfosMvt()) {
    //   this.mvtCompte.membreId = this.membreId;
    //   this.mvtCompte.gabaritId = 1;
    //   this.mvtComptes.push(this.mvtCompte);
    //   this.mvtCompte = new MvtCompte();
    //   this.modalClose.nativeElement.click();
    //   this.enregistrerCompte();
    // }
  }

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
