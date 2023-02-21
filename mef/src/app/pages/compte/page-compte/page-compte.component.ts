import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Compte } from 'src/app/model/compte';
import { CompteService } from 'src/app/services/compte.service';

@Component({
  selector: 'app-page-compte',
  templateUrl: './page-compte.component.html',
  styleUrls: ['./page-compte.component.scss'],
})
export class PageCompteComponent implements OnInit {
  comptes: Compte[] = [];

  constructor(private compteService: CompteService, private router: Router) {}

  ngOnInit(): void {
    this.compteService.getAll().subscribe((data) => {
      this.comptes = data;
      console.log(data);
    });
  }

  nouveauCompte(): void {
    this.router.navigate(['/nouveaucompte']);
  }
}
