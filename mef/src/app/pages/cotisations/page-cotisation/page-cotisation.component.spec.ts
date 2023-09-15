import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageCotisationComponent } from './page-cotisation.component';

describe('PageCotisationComponent', () => {
  let component: PageCotisationComponent;
  let fixture: ComponentFixture<PageCotisationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PageCotisationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageCotisationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
