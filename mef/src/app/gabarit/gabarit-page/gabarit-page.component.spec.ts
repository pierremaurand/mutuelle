import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GabaritPageComponent } from './gabarit-page.component';

describe('GabaritPageComponent', () => {
  let component: GabaritPageComponent;
  let fixture: ComponentFixture<GabaritPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GabaritPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GabaritPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
