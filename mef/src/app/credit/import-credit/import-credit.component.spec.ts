import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportCreditComponent } from './import-credit.component';

describe('ImportCreditComponent', () => {
  let component: ImportCreditComponent;
  let fixture: ComponentFixture<ImportCreditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportCreditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportCreditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
