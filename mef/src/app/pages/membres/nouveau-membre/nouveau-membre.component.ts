import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Membre } from 'src/app/model/Membre';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { MembreService } from 'src/app/services/membre.service';
import { PosteService } from 'src/app/services/poste.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-nouveau-membre',
  templateUrl: './nouveau-membre.component.html',
  styleUrls: ['./nouveau-membre.component.scss'],
})
export class NouveauMembreComponent implements OnInit {
  membre: Membre = {};
  sexe: Sexe = {};
  listeSexes: Sexe[] = [];
  poste: Poste = {};
  listePostes: Poste[] = [];
  errors: string[] = [];

  constructor(
    private router: Router,
    private membreService: MembreService,
    private sexeService: SexeService,
    private posteService: PosteService
  ) {}

  ngOnInit(): void {
    this.membre.photoUrl = this.membreService.getPhotoUrl(this.membre);

    this.sexeService.getAll().subscribe((data) => {
      this.listeSexes = data;
    });

    this.posteService.getAll().subscribe((data) => {
      this.listePostes = data;
    });
  }

  enregistrerMembre(): void {
    this.membre.sexe = this.sexe;
    this.membre.poste = this.poste;
    console.log(this.membre);
    this.membreService.add(this.membre).subscribe(
      (value: any) => {
        this.router.navigate(['membres']);
      },
      (error: any) => {
        this.errors = error.error.errors;
      }
    );
  }

  cancel(): void {
    this.router.navigate(['membres']);
  }
}
