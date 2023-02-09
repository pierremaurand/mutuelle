import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ImageCroppedEvent } from 'ngx-image-cropper';
import { UploadImage } from 'src/app/model/uploadImage';
import { MembreService } from 'src/app/services/membre.service';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-image',
  templateUrl: './add-image.component.html',
  styleUrls: ['./add-image.component.scss'],
})
export class AddImageComponent implements OnInit {
  imagesUrl = environment.imagesUrl;
  imageUrl: string = '';
  fichier: any;
  imageChangedEvent: any = '';
  croppedImage: any = '';
  membreId!: number;
  uploadImage!: UploadImage;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private membreService: MembreService
  ) {}

  ngOnInit(): void {
    this.membreId = this.route.snapshot.params['id'];
  }

  onSavePic(): void {
    this.uploadImage = new UploadImage();
    this.uploadImage.image = this.croppedImage.substr(22);
    this.uploadImage.membreId = this.membreId;

    if (this.uploadImage.image != '') {
      this.membreService.addImage(this.uploadImage).subscribe(() => {
        Swal.fire({
          icon: 'success',
          title: 'Image ajouté avec succès !',
          showConfirmButton: false,
          timer: 1500,
        }),
          this.onCancel();
      });
    } else {
      Swal.fire({
        icon: 'error',
        title: "Aucune image n'a été selectionnée",
        showConfirmButton: false,
        timer: 1500,
      });
    }
  }

  fileChangeEvent(event: any): void {
    this.imageChangedEvent = event;
  }

  imageCropped(event: ImageCroppedEvent) {
    this.croppedImage = event.base64;
  }

  imageLoaded() {
    // show cropper
  }

  cropperReady() {
    // cropper ready
  }

  loadImageFailed() {
    // show message
  }

  onCancel(): void {
    if (this.membreId) {
      this.router.navigate(['home/membres/show', this.membreId]);
    }
  }
}
