import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailAvanceMembreComponent } from './detail-avance-membre.component';

describe('DetailAvanceMembreComponent', () => {
  let component: DetailAvanceMembreComponent;
  let fixture: ComponentFixture<DetailAvanceMembreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailAvanceMembreComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailAvanceMembreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
