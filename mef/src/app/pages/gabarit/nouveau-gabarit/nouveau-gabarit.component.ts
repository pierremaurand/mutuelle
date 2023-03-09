import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CompteComptable } from 'src/app/model/comptecomptable';
import { Gabarit } from 'src/app/model/gabarit';
import { Operation } from 'src/app/model/operation';
import { TypeMouvement } from 'src/app/model/typeMouvement';
import { CompteComptableService } from 'src/app/services/compte-comptable.service';
import { GabaritService } from 'src/app/services/gabarit.service';
import { LoaderService } from 'src/app/services/loader.service';
import { OperationService } from 'src/app/services/operation.service';

@Component({
  selector: 'app-nouveau-gabarit',
  templateUrl: './nouveau-gabarit.component.html',
  styleUrls: ['./nouveau-gabarit.component.scss'],
})
export class NouveauGabaritComponent implements OnInit {
  gabaritId?: number;
  gabarit: Gabarit = new Gabarit();
  operation: Operation = new Operation();
  comptes: CompteComptable[] = [];
  photo: string = '';
  SortbyParam = 'typeOperation';
  SortDirection = 'asc';
  typeMouvements: any[] = [
    {
      label: 'Cotisation',
      value: TypeMouvement.Cotisation,
    },
    {
      label: 'Déboursement avance',
      value: TypeMouvement.DeboursementAvance,
    },
    {
      label: 'Déboursement crédit',
      value: TypeMouvement.DeboursementCredit,
    },
    {
      label: 'Paiement échéance crédit',
      value: TypeMouvement.PaiementEcheanceCredit,
    },
    {
      label: 'Paiement échéance avance',
      value: TypeMouvement.PaiementEcheanceAvance,
    },
    {
      label: 'Solde tout comptes',
      value: TypeMouvement.SoldeToutComptes,
    },
  ];

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private gabaritService: GabaritService,
    private compteComptableService: CompteComptableService,
    private operationService: OperationService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    this.gabaritId = this.activatedRoute.snapshot.params['id'];
    this.photo = this.gabaritService.getImageUrl();
    this.compteComptableService
      .getAll()
      .subscribe((comptes: CompteComptable[]) => {
        this.comptes = comptes;
        this.chargementGabarit();
      });
  }

  enregistrerGabarit(): void {
    if (this.checkGabaritInfo()) {
      if (this.gabaritId) {
        this.gabaritService
          .update(this.gabarit, this.gabaritId)
          .subscribe((value: any) => {
            this.cancel();
          });
      } else {
        this.gabaritService.add(this.gabarit).subscribe((id: number) => {
          this.cancel();
        });
      }
    }
  }

  checkGabaritInfo(): boolean {
    if (
      !this.gabarit.operations ||
      this.gabarit.operations.length === 0 ||
      this.gabarit.libelle == ''
    ) {
      return false;
    }

    let equilibre = 0;
    this.gabarit.operations.map((operation) => {
      if (operation.typeOperation == 0) {
        equilibre += operation.taux;
      } else {
        equilibre -= operation.taux;
      }
    });
    if (equilibre != 0) {
      return false;
    }

    return true;
  }

  checkOperationInfos(): boolean {
    if (this.gabarit.libelle == '') {
      return false;
    }

    if (this.operation.compteComptableId == 0) {
      return false;
    }

    if (this.operation.taux == 0) {
      return false;
    }

    return true;
  }

  ajouterOperation(): void {
    if (this.checkOperationInfos()) {
      if (this.gabarit.operations) {
        this.gabarit.operations.push(this.operation);
        this.operation = new Operation();
      }
    }
  }

  supprimerOperation(operation: Operation): void {
    if (this.gabarit.operations) {
      const position = this.gabarit.operations.indexOf(operation);
      this.gabarit.operations.splice(position, 1);
    }
  }

  cancel(): void {
    this.router.navigate(['/gabarits']);
  }

  getNumCompte(id?: number): string {
    let compte = '';
    this.comptes.map((cmp) => {
      if (cmp.id == id) {
        compte = cmp.compte;
      }
    });
    return compte;
  }

  getLibelleCompte(id?: number): string {
    let libelle = '';
    this.comptes.map((cmp) => {
      if (cmp.id == id) {
        libelle = cmp.libelle;
      }
    });
    return libelle;
  }

  chargementGabarit(): void {
    if (this.gabaritId) {
      this.gabaritService
        .getById(this.gabaritId)
        .subscribe((gabarit: Gabarit) => {
          this.gabarit = gabarit;
        });
    }
  }
}
