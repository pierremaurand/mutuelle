import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Membre } from 'src/app/model/Membre';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { LoaderService } from 'src/app/services/loader.service';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-update-membre',
  templateUrl: './update-membre.component.html',
  styleUrls: ['./update-membre.component.scss'],
})
export class UpdateMembreComponent implements OnInit {
  membreId?: number;
  membre: Membre = new Membre();
  sexes: Sexe[] = [];
  postes: Poste[] = [];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private membreService: MembreService,
    private sexeService: SexeService,
    private posteService: PosteService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    (this.membreId = this.route.snapshot.params['id']), this.loadInfosMembre();

    this.sexeService.getAll().subscribe((data) => {
      this.sexes = data;
    });

    this.posteService.getAll().subscribe((data) => {
      this.postes = data;
    });
  }

  loadInfosMembre(): void {
    if (this.membreId) {
      this.loaderService.show();
      this.membreService.getById(this.membreId).subscribe((data) => {
        this.loaderService.hide();
        (this.membre = data),
          (this.membre.photoUrl = this.membreService.getPhotoUrl(this.membre));
      });
    }
  }

  onSubmit(membreForm: NgForm): void {
    if (membreForm.valid && this.membreId) {
      this.membreService.update(this.membre, this.membreId).subscribe(() => {
        Swal.fire({
          icon: 'success',
          title: 'Membre modifié avec succès !',
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
    this.router.navigate(['home/membres/show', this.membreId]);
  }
}
