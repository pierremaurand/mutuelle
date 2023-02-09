import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CompteComptable } from 'src/app/model/comptecomptable';
import { Gabarit } from 'src/app/model/gabarit';
import { Operation } from 'src/app/model/operation';
import { CompteComptableService } from 'src/app/services/compte-comptable.service';
import { GabaritService } from 'src/app/services/gabarit.service';
import { LoaderService } from 'src/app/services/loader.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-update-gabarit',
  templateUrl: './update-gabarit.component.html',
  styleUrls: ['./update-gabarit.component.scss'],
})
export class UpdateGabaritComponent implements OnInit {
  gabarit!: Gabarit;
  operation: Operation = new Operation();
  gabaritId!: number;
  compteComptables: CompteComptable[] = [];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private gabaritService: GabaritService,
    private loaderService: LoaderService,
    private compteComptableService: CompteComptableService
  ) {}

  ngOnInit(): void {
    this.gabaritId = this.route.snapshot.params['id'];
    this.compteComptableService.getAll().subscribe((data) => {
      this.compteComptables = data;
    });
    if (this.gabaritId) {
      this.loaderService.show();
      this.gabaritService.getById(this.gabaritId).subscribe((data) => {
        this.loaderService.hide();
        this.gabarit = data;
        this.gabarit.operations.map((o, i) => {
          this.gabarit.operations[i].tOperation =
            this.gabaritService.getTypeOperation(o.typeOperation);
          this.gabarit.operations[i].compte = this.gabaritService.getCompte(
            o.compteComptableId,
            this.compteComptables
          );
        });
      });
    }
  }

  onAddOperation(operationform: NgForm): void {
    if (operationform.valid) {
      this.operation.compte = this.gabaritService.getCompte(
        this.operation.compteComptableId,
        this.compteComptables
      );
      this.operation.tOperation = this.gabaritService.getTypeOperation(
        this.operation.typeOperation
      );
      this.gabarit.operations.push(this.operation);
      this.operation = new Operation();
    }
  }

  onDelete(operation: Operation): void {
    const position = this.gabarit.operations.indexOf(operation);
    this.gabarit.operations.splice(position, 1);
  }

  checkOperations(): boolean {
    let debit: number = 0;
    let credit: number = 0;
    this.gabarit.operations.map((o) => {
      if (o.tOperation == 'Débit') {
        if (o.taux) debit += o.taux;
      } else {
        if (o.taux) credit += o.taux;
      }
    });

    if (debit != 100 || credit != 100) return false;

    return true;
  }

  onSubmit(gabaritForm: NgForm): void {
    if (
      gabaritForm.valid &&
      this.gabarit.operations &&
      this.checkOperations()
    ) {
      this.gabaritService.update(this.gabarit, this.gabaritId).subscribe(() => {
        Swal.fire({
          icon: 'success',
          title: 'Gabarit modifié avec succès !',
          showConfirmButton: false,
          timer: 1500,
        });
        this.onCancel();
      });
    } else {
      Swal.fire({
        icon: 'error',
        title: 'Veuillez remplir tous les champs obligatoires',
        showConfirmButton: false,
        timer: 1500,
      });
    }
  }

  onCancel(): void {
    this.router.navigate(['home/gabarits']);
  }
}
