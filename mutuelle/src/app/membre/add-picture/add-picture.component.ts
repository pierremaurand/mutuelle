import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Membre } from 'src/app/model/membre';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-add-picture',
  templateUrl: './add-picture.component.html',
  styleUrls: ['./add-picture.component.scss']
})
export class AddPictureComponent implements OnInit {
  @Input() membre: Membre = {};
  @Output() membreChange = new EventEmitter<Membre>();
  @Input() imageUrl: string ='';
  fichier: any;
  constructor() { }

  ngOnInit(): void {

  }

  onSubmit(pictureForm: NgForm): void {
    /*this.membreService.addPhoto(this.fichier).subscribe({
      next:(data:any) => {
        this.membre.photo = data.imageUrl;
      }
    });*/
  }

  fileBrowseHandler(event: Event) {
    const element = event.currentTarget as HTMLInputElement;
    let fileList = element.files;
    const files = Array.prototype.slice.call(fileList);
    this.fichier = files[0];
    var reader = new FileReader();
    reader.onload = () => {
      this.imageUrl = reader.result as string;
    }
    reader.readAsDataURL(this.fichier);
  }

}
