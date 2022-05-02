import { Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import { NgForm } from '@angular/forms';
import { Cotisation } from 'src/app/model/cotisation';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-add-cotisation',
  templateUrl: './add-cotisation.component.html',
  styleUrls: ['./add-cotisation.component.scss']
})
export class AddCotisationComponent implements OnInit {
  @ViewChild("closeCotisationFormModal") modalClose:any;
  @Input() cotisation!: Cotisation;
  @Output() cotisationChange = new EventEmitter<Cotisation>();

  constructor(
    private alertity: AlertifyService
  ) { }

  ngOnInit(): void {
    console.log(this.cotisation);
  }

  onSubmit(cotisationForm: NgForm){
    if(cotisationForm.valid) {
      this.cotisationChange.emit(this.cotisation);
      this.modalClose.nativeElement.click();
    } else {
      this.alertity.error('Veuillez remplir tous les champs obligatoires');
    }
  }
}
