import { DecimalPipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import { NgForm } from '@angular/forms';
import { CotisationList } from 'src/app/model/cotisationList';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-add-cotisation',
  templateUrl: './add-cotisation.component.html',
  styleUrls: ['./add-cotisation.component.scss']
})
export class AddCotisationComponent implements OnInit {
  @ViewChild("closeCotisationFormModal") modalClose:any;
  @Input() cotisation!: CotisationList;
  @Output() cotisationChange = new EventEmitter<CotisationList>();

  constructor(
    private alertity: AlertifyService,
    private decimalPipe: DecimalPipe
  ) { }

  ngOnInit(): void {

  }

  onSubmit(cotisationForm: NgForm): void{
    if(cotisationForm.valid) {
      this.cotisationChange.emit(this.cotisation);
      this.modalClose.nativeElement.click();
    } else {
      this.alertity.error('Veuillez remplir tous les champs obligatoires');
    }
  }

  controlChar(x: any): void {
    const pattern = /[0-9\+\-\ ]/;
    const inputChar = String.fromCharCode(x.charCode);
    if (x.key !== 8 && !pattern.test(inputChar)) {
      x.preventDefault();
    }
  }

  gestionSpaces(): void {

  }

  separer(chaine: string | null): string{
    if(chaine!=null) {
      //console.log("Chaine " + chaine);
      if(chaine.length > 3) {
        let l = chaine.length -3;
        let fin = chaine.substring(l,chaine.length);
        let debut = chaine.substring(0,l);
        //console.log("Fin " + fin);
        //console.log("Debut " + debut);
        if(debut.length > 3)
          return this.separer(debut) + " " + fin;
        return debut + " " + fin;
      }
      return chaine;
    }
    return "";
  }
}
