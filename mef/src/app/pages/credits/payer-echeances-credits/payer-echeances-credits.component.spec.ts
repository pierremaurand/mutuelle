import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PayerEcheancesCreditsComponent } from './payer-echeances-credits.component';

describe('PayerEcheancesCreditsComponent', () => {
  let component: PayerEcheancesCreditsComponent;
  let fixture: ComponentFixture<PayerEcheancesCreditsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PayerEcheancesCreditsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PayerEcheancesCreditsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
