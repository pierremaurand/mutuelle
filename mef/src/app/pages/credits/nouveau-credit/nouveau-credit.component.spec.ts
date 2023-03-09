import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NouveauCreditComponent } from './nouveau-credit.component';

describe('NouveauCreditComponent', () => {
  let component: NouveauCreditComponent;
  let fixture: ComponentFixture<NouveauCreditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NouveauCreditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NouveauCreditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
