import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SexePageComponent } from './sexe-page.component';

describe('SexePageComponent', () => {
  let component: SexePageComponent;
  let fixture: ComponentFixture<SexePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SexePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SexePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
