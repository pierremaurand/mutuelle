import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CompteList } from 'src/app/model/compteList';
import { CompteService } from 'src/app/services/compte.service';

@Component({
  selector: 'app-page-compte',
  templateUrl: './page-compte.component.html',
  styleUrls: ['./page-compte.component.scss'],
})
export class PageCompteComponent implements OnInit {
  comptes: CompteList[] = [];

  constructor(private compteService: CompteService, private router: Router) {}

  ngOnInit(): void {
    this.compteService.getAllComptes().subscribe((comptes: CompteList[]) => {
      this.comptes = comptes;
    });
  }

  nouveauCompte(): void {
    this.router.navigate(['/nouveaucompte']);
  }

  navigate(id: number): void {
    this.router.navigate(['/nouveaucompte/' + id]);
  }
}
