import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateCotisationComponent } from './update-cotisation.component';

describe('UpdateCotisationComponent', () => {
  let component: UpdateCotisationComponent;
  let fixture: ComponentFixture<UpdateCotisationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateCotisationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateCotisationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
