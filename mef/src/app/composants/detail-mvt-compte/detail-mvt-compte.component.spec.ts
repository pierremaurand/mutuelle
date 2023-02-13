import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailMvtCompteComponent } from './detail-mvt-compte.component';

describe('DetailMvtCompteComponent', () => {
  let component: DetailMvtCompteComponent;
  let fixture: ComponentFixture<DetailMvtCompteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailMvtCompteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailMvtCompteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
