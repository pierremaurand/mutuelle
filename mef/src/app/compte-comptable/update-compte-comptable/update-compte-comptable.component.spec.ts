import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateCompteComptableComponent } from './update-compte-comptable.component';

describe('UpdateCompteComptableComponent', () => {
  let component: UpdateCompteComptableComponent;
  let fixture: ComponentFixture<UpdateCompteComptableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateCompteComptableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateCompteComptableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
