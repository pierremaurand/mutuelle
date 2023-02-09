import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportCompteComponent } from './import-compte.component';

describe('ImportCompteComponent', () => {
  let component: ImportCompteComponent;
  let fixture: ComponentFixture<ImportCompteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportCompteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportCompteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
