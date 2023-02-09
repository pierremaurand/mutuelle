import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CompteComptable } from 'src/app/model/comptecomptable';
import { CompteComptableService } from 'src/app/services/compte-comptable.service';
import { LoaderService } from 'src/app/services/loader.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-update-compte-comptable',
  templateUrl: './update-compte-comptable.component.html',
  styleUrls: ['./update-compte-comptable.component.scss'],
})
export class UpdateCompteComptableComponent implements OnInit {
  compteId!: number;
  compte: CompteComptable = new CompteComptable();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private compteComptableService: CompteComptableService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    this.compteId = this.route.snapshot.params['id'];
    if (this.compteId) {
      this.loaderService.show();
      this.compteComptableService.getById(this.compteId).subscribe((data) => {
        this.loaderService.hide();
        this.compte = data;
      });
    }
  }

  onSubmit(compteForm: NgForm): void {
    if (compteForm.valid) {
      this.compteComptableService
        .update(this.compte, this.compteId)
        .subscribe(() => {
          Swal.fire({
            icon: 'success',
            title: 'Compte comptable modifié avec succès !',
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
    this.router.navigate(['home/plan-comptable/show', this.compteId]);
  }
}
