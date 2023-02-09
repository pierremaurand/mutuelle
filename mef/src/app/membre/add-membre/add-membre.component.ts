import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Membre } from 'src/app/model/Membre';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-membre',
  templateUrl: './add-membre.component.html',
  styleUrls: ['./add-membre.component.scss'],
})
export class AddMembreComponent implements OnInit {
  membre: Membre = new Membre();
  sexes: Sexe[] = [];
  postes: Poste[] = [];

  constructor(
    private router: Router,
    private membreService: MembreService,
    private sexeService: SexeService,
    private posteService: PosteService
  ) {}

  ngOnInit(): void {
    this.membre.photoUrl = this.membreService.getPhotoUrl(this.membre);

    this.sexeService.getAll().subscribe((data) => {
      this.sexes = data;
    });

    this.posteService.getAll().subscribe((data) => {
      this.postes = data;
    });
  }

  onSubmit(membreForm: NgForm): void {
    if (membreForm.valid) {
      this.membreService.add(this.membre).subscribe(() => {
        Swal.fire({
          icon: 'success',
          title: 'Membre ajouté avec succès !',
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
    this.router.navigate(['home/membres']);
  }
}
