import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Sexe } from 'src/app/model/sexe';
import { SexeService } from 'src/app/services/sexe.service';

@Component({
  selector: 'app-detail-sexe',
  templateUrl: './detail-sexe.component.html',
  styleUrls: ['./detail-sexe.component.scss'],
})
export class DetailSexeComponent implements OnInit {
  @Input()
  sexe?: Sexe;
  photo: string = '';
  @Input() hideIcons: boolean = false;

  constructor(private router: Router, private sexeService: SexeService) {}

  ngOnInit(): void {
    this.photo = this.sexeService.getImageUrl();
  }

  modifier(): void {
    this.router.navigate(['/nouveausexe', this.sexe?.id]);
  }
}