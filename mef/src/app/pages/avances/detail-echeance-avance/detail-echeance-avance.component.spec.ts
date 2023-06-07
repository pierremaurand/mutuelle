import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailEcheanceAvanceComponent } from './detail-echeance-avance.component';

describe('DetailEcheanceAvanceComponent', () => {
  let component: DetailEcheanceAvanceComponent;
  let fixture: ComponentFixture<DetailEcheanceAvanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailEcheanceAvanceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailEcheanceAvanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
