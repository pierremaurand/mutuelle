import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LieuAffectation } from 'src/app/model/lieuAffectation';
import { LieuAffectationService } from 'src/app/services/lieu-affectation.service';

@Component({
  selector: 'app-detail-lieu-affectation',
  templateUrl: './detail-lieu-affectation.component.html',
  styleUrls: ['./detail-lieu-affectation.component.scss'],
})
export class DetailLieuAffectationComponent implements OnInit {
  @Input()
  lieuaffectation?: LieuAffectation;
  photo: string = '';
  @Input() hideIcons: boolean = false;

  constructor(
    private router: Router,
    private lieuAffectationService: LieuAffectationService
  ) {}

  ngOnInit(): void {
    this.photo = this.lieuAffectationService.getImageUrl();
  }

  modifier(): void {
    this.router.navigate(['/nouveaulieuaffectation', this.lieuaffectation?.id]);
  }
}