import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailCotisationMembreComponent } from './detail-cotisation-membre.component';

describe('DetailCotisationMembreComponent', () => {
  let component: DetailCotisationMembreComponent;
  let fixture: ComponentFixture<DetailCotisationMembreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailCotisationMembreComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailCotisationMembreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
