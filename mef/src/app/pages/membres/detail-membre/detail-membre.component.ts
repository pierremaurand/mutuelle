import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Membre } from 'src/app/model/Membre';
import { MembreService } from 'src/app/services/membre.service';

@Component({
  selector: 'app-detail-membre',
  templateUrl: './detail-membre.component.html',
  styleUrls: ['./detail-membre.component.scss'],
})
export class DetailMembreComponent implements OnInit {
  @Input() membre: Membre = new Membre();
  photo: string = '';
  @Input() hideIcons: boolean = false;

  constructor(private membreService: MembreService, private router: Router) {}

  ngOnInit(): void {
    this.photo = this.membreService.getPhotoUrl(this.membre.photo);
  }

  modifier(): void {
    this.router.navigate(['nouveaumembre', this.membre.id]);
  }

  detailler(): void {
    this.router.navigate(['detailmembre', this.membre.id]);
  }
}
