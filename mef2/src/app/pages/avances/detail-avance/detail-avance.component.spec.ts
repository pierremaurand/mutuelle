import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailAvanceComponent } from './detail-avance.component';

describe('DetailAvanceComponent', () => {
  let component: DetailAvanceComponent;
  let fixture: ComponentFixture<DetailAvanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailAvanceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailAvanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
