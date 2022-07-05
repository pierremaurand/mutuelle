import { Component, OnInit } from '@angular/core';
import { Service } from 'src/app/model/service';
import { ServiceService } from 'src/app/services/service.service';

@Component({
  selector: 'app-service-list',
  templateUrl: './service-list.component.html',
  styleUrls: ['./service-list.component.scss']
})
export class ServiceListComponent implements OnInit {

  services: Service[] = [];

  constructor(private serviceService: ServiceService) { }

  ngOnInit(): void {
    this.serviceService.getAll().subscribe({
      next:(data) => {
        this.services = data;
        console.log(data);
      },
      error:(error) => {
        console.log("Httperror:");
        console.log(error);
      }
    });
  }

}
