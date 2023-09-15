import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateAvanceComponent } from './update-avance.component';

describe('UpdateAvanceComponent', () => {
  let component: UpdateAvanceComponent;
  let fixture: ComponentFixture<UpdateAvanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateAvanceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateAvanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
