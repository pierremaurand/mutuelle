import { Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Cotisation } from 'src/app/model/cotisation';
import { CotisationList } from 'src/app/model/cotisationList';
import { Periode } from 'src/app/model/periode';
import { PeriodeService } from 'src/app/services/periode.service';

@Component({
  selector: 'app-add-cotisation',
  templateUrl: './add-cotisation.component.html',
  styleUrls: ['./add-cotisation.component.scss']
})
export class AddCotisationComponent implements OnInit {
  periodes?: Periode[];
  @ViewChild("cluseCotisationFormModal") modalClose:any;
  @Input() cotisation!: CotisationList;
  infos: Cotisation = {};
  @Output() cotisationChange = new EventEmitter<Cotisation>();

  constructor(private periodeService:PeriodeService) { }

  ngOnInit(): void {

    this.periodeService.getAll().subscribe({
      next: (data:Periode[]) => {
        this.periodes = data;
      }
    });

    console.log(this.cotisation);
  }

  onSubmit(cotisationForm: NgForm){
    this.cotisationChange.emit(this.infos);
    this.modalClose.nativeElement.click();
    cotisationForm.reset();
  }

}
