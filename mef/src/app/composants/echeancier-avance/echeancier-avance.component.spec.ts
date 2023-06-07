import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EcheancierAvanceComponent } from './echeancier-avance.component';

describe('EcheancierAvanceComponent', () => {
  let component: EcheancierAvanceComponent;
  let fixture: ComponentFixture<EcheancierAvanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EcheancierAvanceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EcheancierAvanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
