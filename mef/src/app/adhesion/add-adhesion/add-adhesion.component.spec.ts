import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAdhesionComponent } from './add-adhesion.component';

describe('AddAdhesionComponent', () => {
  let component: AddAdhesionComponent;
  let fixture: ComponentFixture<AddAdhesionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAdhesionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAdhesionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
