import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateComptabiliteComponent } from './update-comptabilite.component';

describe('UpdateComptabiliteComponent', () => {
  let component: UpdateComptabiliteComponent;
  let fixture: ComponentFixture<UpdateComptabiliteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateComptabiliteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateComptabiliteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
