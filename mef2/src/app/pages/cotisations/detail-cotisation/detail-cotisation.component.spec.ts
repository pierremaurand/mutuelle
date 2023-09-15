import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailCotisationComponent } from './detail-cotisation.component';

describe('DetailCotisationComponent', () => {
  let component: DetailCotisationComponent;
  let fixture: ComponentFixture<DetailCotisationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailCotisationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailCotisationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
