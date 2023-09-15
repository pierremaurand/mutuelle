import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DecalerEcheancesAvancesComponent } from './decaler-echeances-avances.component';

describe('DecalerEcheancesAvancesComponent', () => {
  let component: DecalerEcheancesAvancesComponent;
  let fixture: ComponentFixture<DecalerEcheancesAvancesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DecalerEcheancesAvancesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DecalerEcheancesAvancesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
