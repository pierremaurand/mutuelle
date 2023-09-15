import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComptabilitePageComponent } from './comptabilite-page.component';

describe('ComptabilitePageComponent', () => {
  let component: ComptabilitePageComponent;
  let fixture: ComponentFixture<ComptabilitePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComptabilitePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComptabilitePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
