import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PayerEcheancesAvancesComponent } from './payer-echeances-avances.component';

describe('PayerEcheancesAvancesComponent', () => {
  let component: PayerEcheancesAvancesComponent;
  let fixture: ComponentFixture<PayerEcheancesAvancesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PayerEcheancesAvancesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PayerEcheancesAvancesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
