import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCotisationComponent } from './add-cotisation.component';

describe('AddCotisationComponent', () => {
  let component: AddCotisationComponent;
  let fixture: ComponentFixture<AddCotisationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCotisationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCotisationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
