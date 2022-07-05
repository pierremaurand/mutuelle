import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Credit } from 'src/app/model/credit';

@Component({
  selector: 'app-add-credit',
  templateUrl: './add-credit.component.html',
  styleUrls: ['./add-credit.component.scss']
})
export class AddCreditComponent implements OnInit {
  @Input() credit: Credit = {};
  @Output() creditChange = new EventEmitter<Credit>();
  @ViewChild("closeCreditFormModal") modalClose:any;

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(creditForm: NgForm): void {

  }

  annuler(): void {

  }

}
