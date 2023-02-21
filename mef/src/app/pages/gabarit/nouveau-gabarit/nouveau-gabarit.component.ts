import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CompteComptable } from 'src/app/model/comptecomptable';
import { Gabarit } from 'src/app/model/gabarit';
import { Operation } from 'src/app/model/operation';
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
  gabarit: Gabarit = new Gabarit();
  operations: Operation[] = [];
  delOperations: Operation[] = [];
  newOperations: Operation[] = [];
  operation: Operation = new Operation();
  comptes: CompteComptable[] = [];
  photo: string = '';

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private gabaritService: GabaritService,
    private compteComptableService: CompteComptableService,
    private operationService: OperationService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    this.photo = this.gabaritService.getImageUrl();
    this.compteComptableService
      .getAll()
      .subscribe((comptes: CompteComptable[]) => {
        this.comptes = comptes;
        const idGabarit = this.activatedRoute.snapshot.params['id'];
        if (idGabarit) {
          this.gabaritService
            .getById(idGabarit)
            .subscribe((gabarit: Gabarit) => {
              this.gabarit = gabarit;
              this.operationService
                .getByGabarit(this.gabarit.id)
                .subscribe((operations: Operation[]) => {
                  this.operations = operations;
                });
            });
        }
      });
  }

  enregistrerGabarit(): void {
    if (this.checkGabaritInfo()) {
      this.delOperations.map((operation) => {
        this.operationService
          .delete(operation.id)
          .subscribe((value: any) => {});
      });
      if (this.gabarit.id != 0) {
        this.gabaritService
          .update(this.gabarit, this.gabarit.id)
          .subscribe((value: any) => {
            this.operationService
              .addOperations(this.gabarit.id, this.newOperations)
              .subscribe(() => {
                this.cancel();
              });
            this.cancel();
          });
      } else {
        this.gabaritService.add(this.gabarit).subscribe((id: number) => {
          this.operationService
            .addOperations(id, this.newOperations)
            .subscribe(() => {
              this.cancel();
            });
        });
      }
    }
  }

  checkGabaritInfo(): boolean {
    if (this.operations.length === 0 || this.gabarit.libelle == '') {
      return false;
    }

    let equilibre = 0;
    this.operations.map((operation) => {
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
      if (this.operations) {
        this.newOperations.push(this.operation);
        this.operations.push(this.operation);
        this.operation = new Operation();
      }
    }
  }

  supprimerOperation(operation: Operation): void {
    if (this.operations) {
      const position = this.operations.indexOf(operation);
      if (operation.id != 0) {
        this.delOperations.push(operation);
      }
      this.operations.splice(position, 1);
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
}
