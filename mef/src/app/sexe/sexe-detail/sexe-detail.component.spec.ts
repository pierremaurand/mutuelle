import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SexeDetailComponent } from './sexe-detail.component';

describe('SexeDetailComponent', () => {
  let component: SexeDetailComponent;
  let fixture: ComponentFixture<SexeDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SexeDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SexeDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
