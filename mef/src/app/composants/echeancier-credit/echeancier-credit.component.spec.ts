import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EcheancierCreditComponent } from './echeancier-credit.component';

describe('EcheancierCreditComponent', () => {
  let component: EcheancierCreditComponent;
  let fixture: ComponentFixture<EcheancierCreditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EcheancierCreditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EcheancierCreditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
