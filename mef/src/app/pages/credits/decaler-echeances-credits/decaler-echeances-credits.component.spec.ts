import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DecalerEcheancesCreditsComponent } from './decaler-echeances-credits.component';

describe('DecalerEcheancesCreditsComponent', () => {
  let component: DecalerEcheancesCreditsComponent;
  let fixture: ComponentFixture<DecalerEcheancesCreditsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DecalerEcheancesCreditsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DecalerEcheancesCreditsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
