import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { CompteComptable } from 'src/app/model/comptecomptable';
import { Gabarit } from 'src/app/model/gabarit';
import { Operation } from 'src/app/model/operation';
import { CompteComptableService } from 'src/app/services/compte-comptable.service';
import { GabaritService } from 'src/app/services/gabarit.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-gabarit',
  templateUrl: './add-gabarit.component.html',
  styleUrls: ['./add-gabarit.component.scss'],
})
export class AddGabaritComponent implements OnInit {
  gabarit: Gabarit = new Gabarit();
  operation: Operation = new Operation();
  compteComptables: CompteComptable[] = [];

  constructor(
    private router: Router,
    private gabaritService: GabaritService,
    private compteComptableService: CompteComptableService
  ) {}

  ngOnInit(): void {
    this.compteComptableService.getAll().subscribe((data) => {
      this.compteComptables = data;
    });
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
      this.gabaritService.add(this.gabarit).subscribe(() => {
        Swal.fire({
          icon: 'success',
          title: 'Gabarit ajouté avec succès !',
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
