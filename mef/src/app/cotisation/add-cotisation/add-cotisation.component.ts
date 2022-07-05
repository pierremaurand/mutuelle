import { DatePipe, DecimalPipe } from '@angular/common';
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
  @Input() cotisation: Cotisation = new Cotisation();
  @Output() cotisationChange = new EventEmitter<Cotisation>();

  constructor(
    private alertify: AlertifyService,
    private datePipe: DatePipe
  ) { }

  ngOnInit(): void {

  }

  onSubmit(cotisationForm: NgForm): void{
    if(cotisationForm.valid) {
      this.cotisationChange.emit(this.cotisation);
    } else {
      this.alertify.error('Veuillez remplir tous les champs obligatoires');
    }
  }
}
