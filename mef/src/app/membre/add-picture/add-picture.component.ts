import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ImageCroppedEvent, LoadedImage } from 'ngx-image-cropper';
import { Membre } from 'src/app/model/membre';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-add-picture',
  templateUrl: './add-picture.component.html',
  styleUrls: ['./add-picture.component.scss'],
})
export class AddPictureComponent implements OnInit {
  @Input() membre: Membre | undefined = {};
  @Output() membreChange = new EventEmitter<Membre>();
  imgChangeEvt: any = '';
  cropImgPreview: any = '';

  public constructor(private membreService: MembreService) {}

  public ngOnInit(): void {}

  onFileChange(event: any): void {
    this.imgChangeEvt = event;
  }
  cropImg(e: ImageCroppedEvent) {
    this.cropImgPreview = e.base64;
  }

  imgLoad() {
    // display cropper tool
  }

  initCropper() {
    // init cropper
  }

  imgFailed() {
    // error msg
  }

  uploadPhoto(): void {
    const file = this.DataURIToBlob(this.cropImgPreview);
    this.membreService.addPhotoMembre(file).subscribe({
      next: (data: any) => {
        if(this.membre) {
          this.membre.photo = data.imageUrl;
          this.membreChange.emit(this.membre);
        }
      }
    });
  }

  DataURIToBlob(dataURI: string) {
    const splitDataURI = dataURI.split(',');
    const byteString =
      splitDataURI[0].indexOf('base64') >= 0
        ? atob(splitDataURI[1])
        : decodeURI(splitDataURI[1]);
    const mimeString = splitDataURI[0].split(':')[1].split(';')[0];

    const ia = new Uint8Array(byteString.length);
    for (let i = 0; i < byteString.length; i++)
      ia[i] = byteString.charCodeAt(i);

    return new Blob([ia], { type: mimeString });
  }
}
