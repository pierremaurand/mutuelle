import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { Membre } from 'src/app/model/Membre';
import { Poste } from 'src/app/model/poste';
import { Sexe } from 'src/app/model/sexe';
import { UploadImage } from 'src/app/model/uploadImage';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';
import { LoaderService } from 'src/app/services/loader.service';
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
  sexes: Sexe[] = [];
  postes: Poste[] = [];
  lieuAffectations: LieuAffectation[] = [];
  errors: string[] = [];
  photo: string = '';
  dateNaissance!: string | null;
  image: string = '';
  uploadImage!: UploadImage;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private membreService: MembreService,
    private sexeService: SexeService,
    private posteService: PosteService,
    private lieuAffectationService: LieuAffectationService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    this.photo = this.membreService.getPhotoUrl(this.membre.photo);

    this.sexeService.getAll().subscribe((data: any) => {
      this.sexes = data;
      this.loaderService.hide();
    });

    this.posteService.getAll().subscribe((data) => {
      this.postes = data;
      this.loaderService.hide();
    });

    this.lieuAffectationService.getAll().subscribe((data) => {
      this.lieuAffectations = data;
      this.loaderService.hide();
    });

    const idMembre = this.activatedRoute.snapshot.params['id'];
    if (idMembre) {
      this.membreService.getById(idMembre).subscribe((membre: any) => {
        this.membre = membre;
        this.photo = this.membreService.getPhotoUrl(this.membre.photo);
      });
    }
  }

  enregistrerMembre(): void {
    if (this.image != '') {
      this.uploadImage = new UploadImage();
      this.uploadImage.image = this.image.substring(22);
    }

    if (this.membre.id) {
      if (this.uploadImage) {
        this.uploadImage.membreId = this.membre.id;
      }
      this.membreService
        .update(this.membre, this.membre.id)
        .subscribe((value: any) => {
          if (this.uploadImage) {
            this.membreService.addImage(this.uploadImage).subscribe(() => {
              this.loaderService.hide();
              this.cancel();
            });
          } else {
            this.loaderService.hide();
            this.cancel();
          }
        });
    } else {
      this.membreService.add(this.membre).subscribe((id: number) => {
        if (this.uploadImage) {
          this.uploadImage.membreId = id;
          this.membreService.addImage(this.uploadImage).subscribe(() => {
            this.loaderService.hide();
            this.cancel();
          });
        } else {
          this.loaderService.hide();
          this.cancel();
        }
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/membres']);
  }

  changeImage(): void {
    alert("Chargement de l'image");
  }

  photoChange(photo: string): void {
    this.photo = photo;
    this.image = photo;
  }
}
