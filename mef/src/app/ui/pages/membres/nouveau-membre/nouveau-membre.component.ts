import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-nouveau-membre',
  imports: [RouterLink, CommonModule, FormsModule],
  templateUrl: './nouveau-membre.component.html',
  styleUrl: './nouveau-membre.component.scss',
})
export default class NouveauMembreComponent {
  errorMsg: Array<string> = [];

  selectedBookCover: any;
  selectedPicture: string | undefined;

  onFileSelected(event: any) {
    this.selectedBookCover = event.target.files[0];
    console.log(this.selectedBookCover);

    if (this.selectedBookCover) {
      const reader = new FileReader();
      reader.onload = () => {
        this.selectedPicture = reader.result as string;
      };
      reader.readAsDataURL(this.selectedBookCover);
    }
  }
}
