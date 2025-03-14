import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-widget',
  templateUrl: './widget.component.html',
  styleUrls: ['./widget.component.scss']
})
export class WidgetComponent implements OnInit {
  @Input() icone: string = "";
  @Input() titre: string = "";
  @Input() montant: number = 0;

  constructor() { }

  ngOnInit(): void {
  }

}
