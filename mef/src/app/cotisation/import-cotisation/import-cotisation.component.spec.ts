import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportCotisationComponent } from './import-cotisation.component';

describe('ImportCotisationComponent', () => {
  let component: ImportCotisationComponent;
  let fixture: ComponentFixture<ImportCotisationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportCotisationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportCotisationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
