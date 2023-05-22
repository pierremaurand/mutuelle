import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Gabarit } from 'src/app/model/gabarit';
import { MembreList } from 'src/app/model/membreList';
import { Mouvement } from 'src/app/model/mouvement';
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
  mouvement: Mouvement = new Mouvement();
  gabarits: Gabarit[] = [];
  mouvements: Mouvement[] = [];
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
          this.compteService
            .getAllMvts(this.membre.id)
            .subscribe((mouvements: Mouvement[]) => {
              this.mouvements = mouvements;
            });
        });
    }
  }

  ajouterMouvement(): void {
    if (this.checkInfosMvt()) {
      this.mouvements.push(this.mouvement);
      this.resetForm();
    }
  }

  soldeCompte(): number {
    let solde = 0;
    this.mouvements.map((mouvement) => {
      if (mouvement.typeOperation == TypeOperation.Credit) {
        solde += mouvement.montant ? mouvement.montant : 0;
      } else {
        solde -= mouvement.montant ? mouvement.montant : 0;
      }
    });
    return solde;
  }

  enregistrer(): void {
    this.compteService.addMvts(this.idMembre, this.mouvements).subscribe(() => {
      this.cancel();
    });
  }

  getTypeOperation(typeOperation: number): string {
    const operation: string =
      'Note de ' + (typeOperation == TypeOperation.Credit ? 'Crédit' : 'Débit');
    return operation;
  }

  checkInfosMvt(): boolean {
    if (
      this.mouvement.dateMvt == '' ||
      this.mouvement.gabaritId == 0 ||
      this.mouvement.libelle == '' ||
      this.mouvement.montant == 0
    ) {
      return false;
    }

    return true;
  }

  cancel(): void {
    this.router.navigate(['/comptes']);
  }

  resetForm(): void {
    this.mouvement = new Mouvement();
  }
}
