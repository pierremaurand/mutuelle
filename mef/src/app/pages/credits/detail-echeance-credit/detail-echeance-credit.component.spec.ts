import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailEcheanceCreditComponent } from './detail-echeance-credit.component';

describe('DetailEcheanceCreditComponent', () => {
  let component: DetailEcheanceCreditComponent;
  let fixture: ComponentFixture<DetailEcheanceCreditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailEcheanceCreditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailEcheanceCreditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
