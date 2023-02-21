import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Poste } from 'src/app/model/poste';
import { LoaderService } from 'src/app/services/loader.service';
import { PosteService } from 'src/app/services/poste.service';

@Component({
  selector: 'app-nouveau-poste',
  templateUrl: './nouveau-poste.component.html',
  styleUrls: ['./nouveau-poste.component.scss'],
})
export class NouveauPosteComponent implements OnInit {
  poste: Poste = new Poste();

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private posteService: PosteService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    const idPoste = this.activatedRoute.snapshot.params['id'];
    if (idPoste) {
      this.posteService.getById(idPoste).subscribe((poste: any) => {
        this.poste = poste;
      });
    }
  }

  enregistrerPoste(): void {
    if (this.poste.id) {
      this.posteService
        .update(this.poste, this.poste.id)
        .subscribe((value: any) => {
          this.loaderService.hide();
          this.cancel();
        });
    } else {
      this.posteService.add(this.poste).subscribe((id: number) => {
        this.loaderService.hide();
        this.cancel();
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/postes']);
  }
}
