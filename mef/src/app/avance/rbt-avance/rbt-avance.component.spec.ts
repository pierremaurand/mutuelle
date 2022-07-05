import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RbtAvanceComponent } from './rbt-avance.component';

describe('RbtAvanceComponent', () => {
  let component: RbtAvanceComponent;
  let fixture: ComponentFixture<RbtAvanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RbtAvanceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RbtAvanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
