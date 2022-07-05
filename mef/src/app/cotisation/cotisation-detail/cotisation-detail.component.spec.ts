import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CotisationDetailComponent } from './cotisation-detail.component';

describe('CotisationDetailComponent', () => {
  let component: CotisationDetailComponent;
  let fixture: ComponentFixture<CotisationDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CotisationDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CotisationDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
