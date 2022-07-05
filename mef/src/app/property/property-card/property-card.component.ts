import { Component, Input, OnInit } from '@angular/core';
import { IPropertyBase } from 'src/app/model/ipropertybase';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-property-card',
  templateUrl: './property-card.component.html',
  styleUrls: ['./property-card.component.scss']
})
export class PropertyCardComponent implements OnInit {

  @Input() property!: IPropertyBase;
  @Input() hideIcons!: boolean;
  imagesUrl = environment.imagesUrl;

  constructor() { }

  ngOnInit(): void {
  }

}
