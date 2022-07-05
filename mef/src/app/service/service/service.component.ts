import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Service } from 'src/app/model/service';

@Component({
  selector: 'app-service',
  templateUrl: './service.component.html',
  styleUrls: ['./service.component.scss']
})
export class ServiceComponent implements OnInit {

  @Input() service: Service = {};

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  update() {
    this.router.navigate(['add-service',this.service.id]);
  }

}
