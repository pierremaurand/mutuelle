import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCompteComptableComponent } from './add-compte-comptable.component';

describe('AddCompteComptableComponent', () => {
  let component: AddCompteComptableComponent;
  let fixture: ComponentFixture<AddCompteComptableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCompteComptableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCompteComptableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
