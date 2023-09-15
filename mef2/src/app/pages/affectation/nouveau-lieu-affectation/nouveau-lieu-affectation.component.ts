import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { LoaderService } from 'src/app/services/loader.service';

@Component({
  selector: 'app-nouveau-lieu-affectation',
  templateUrl: './nouveau-lieu-affectation.component.html',
  styleUrls: ['./nouveau-lieu-affectation.component.scss'],
})
export class NouveauLieuAffectationComponent implements OnInit {
  lieuaffectation: LieuAffectation = new LieuAffectation();

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private lieuAffectationService: LieuAffectationService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    const idLieuAffectation = this.activatedRoute.snapshot.params['id'];
    if (idLieuAffectation) {
      this.lieuAffectationService
        .getById(idLieuAffectation)
        .subscribe((lieuaffectation: LieuAffectation) => {
          this.lieuaffectation = lieuaffectation;
        });
    }
  }

  enregistrer(): void {
    if (this.lieuaffectation.id) {
      this.lieuAffectationService
        .update(this.lieuaffectation, this.lieuaffectation.id)
        .subscribe((value: any) => {
          this.loaderService.hide();
          this.cancel();
        });
    } else {
      this.lieuAffectationService
        .add(this.lieuaffectation)
        .subscribe((id: number) => {
          this.loaderService.hide();
          this.cancel();
        });
    }
  }

  cancel(): void {
    this.router.navigate(['/lieuaffectations']);
  }
}
