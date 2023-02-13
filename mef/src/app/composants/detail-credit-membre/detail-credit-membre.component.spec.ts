import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailCreditMembreComponent } from './detail-credit-membre.component';

describe('DetailCreditMembreComponent', () => {
  let component: DetailCreditMembreComponent;
  let fixture: ComponentFixture<DetailCreditMembreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailCreditMembreComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailCreditMembreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
