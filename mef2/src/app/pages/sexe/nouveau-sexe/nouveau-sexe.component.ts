import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Sexe } from 'src/app/model/sexe';
import { LoaderService } from 'src/app/services/loader.service';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-nouveau-sexe',
  templateUrl: './nouveau-sexe.component.html',
  styleUrls: ['./nouveau-sexe.component.scss'],
})
export class NouveauSexeComponent implements OnInit {
  sexe: Sexe = new Sexe();

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private sexeService: SexeService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    const idSexe = this.activatedRoute.snapshot.params['id'];
    if (idSexe) {
      this.sexeService.getById(idSexe).subscribe((sexe: any) => {
        this.sexe = sexe;
      });
    }
  }

  enregistrerSexe(): void {
    if (this.sexe.id) {
      this.sexeService
        .update(this.sexe, this.sexe.id)
        .subscribe((value: any) => {
          this.loaderService.hide();
          this.cancel();
        });
    } else {
      this.sexeService.add(this.sexe).subscribe((id: number) => {
        this.loaderService.hide();
        this.cancel();
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/sexes']);
  }
}