import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddGabaritComponent } from './add-gabarit.component';

describe('AddGabaritComponent', () => {
  let component: AddGabaritComponent;
  let fixture: ComponentFixture<AddGabaritComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddGabaritComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddGabaritComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
