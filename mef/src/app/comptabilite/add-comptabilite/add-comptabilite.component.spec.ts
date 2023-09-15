import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddComptabiliteComponent } from './add-comptabilite.component';

describe('AddComptabiliteComponent', () => {
  let component: AddComptabiliteComponent;
  let fixture: ComponentFixture<AddComptabiliteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddComptabiliteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddComptabiliteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
