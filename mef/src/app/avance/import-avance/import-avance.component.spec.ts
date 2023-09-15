import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportAvanceComponent } from './import-avance.component';

describe('ImportAvanceComponent', () => {
  let component: ImportAvanceComponent;
  let fixture: ComponentFixture<ImportAvanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportAvanceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportAvanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
