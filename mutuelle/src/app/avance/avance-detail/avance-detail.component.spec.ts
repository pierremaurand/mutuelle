import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvanceDetailComponent } from './avance-detail.component';

describe('AvanceDetailComponent', () => {
  let component: AvanceDetailComponent;
  let fixture: ComponentFixture<AvanceDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AvanceDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AvanceDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
