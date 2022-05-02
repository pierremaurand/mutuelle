import { Component, OnInit } from '@angular/core';
import { Credit } from 'src/app/model/credit';

@Component({
  selector: 'app-credit-list',
  templateUrl: './credit-list.component.html',
  styleUrls: ['./credit-list.component.scss']
})
export class CreditListComponent implements OnInit {
  credits: Credit[] = [];

  constructor() { }

  ngOnInit(): void {
  }

  modifCredit(credit: Credit): void {

  }

}
