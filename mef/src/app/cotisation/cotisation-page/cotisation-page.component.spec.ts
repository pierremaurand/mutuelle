import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CotisationPageComponent } from './cotisation-page.component';

describe('CotisationPageComponent', () => {
  let component: CotisationPageComponent;
  let fixture: ComponentFixture<CotisationPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CotisationPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CotisationPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
