import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvancePageComponent } from './avance-page.component';

describe('AvancePageComponent', () => {
  let component: AvancePageComponent;
  let fixture: ComponentFixture<AvancePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AvancePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AvancePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
