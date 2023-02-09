import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { CompteComptable } from 'src/app/model/comptecomptable';
import { CompteComptableService } from 'src/app/services/compte-comptable.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-compte-comptable',
  templateUrl: './add-compte-comptable.component.html',
  styleUrls: ['./add-compte-comptable.component.scss'],
})
export class AddCompteComptableComponent implements OnInit {
  compte: CompteComptable = new CompteComptable();

  constructor(
    private router: Router,
    private compteComptableService: CompteComptableService
  ) {}

  ngOnInit(): void {}

  onSubmit(compteForm: NgForm): void {
    if (compteForm.valid) {
      this.compteComptableService.add(this.compte).subscribe(() => {
        Swal.fire({
          icon: 'success',
          title: 'Compte ajouté avec succès !',
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
    this.router.navigate(['home/plan-comptable']);
  }
}
