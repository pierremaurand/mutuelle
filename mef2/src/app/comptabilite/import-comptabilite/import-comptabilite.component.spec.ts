import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportComptabiliteComponent } from './import-comptabilite.component';

describe('ImportComptabiliteComponent', () => {
  let component: ImportComptabiliteComponent;
  let fixture: ComponentFixture<ImportComptabiliteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportComptabiliteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportComptabiliteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
