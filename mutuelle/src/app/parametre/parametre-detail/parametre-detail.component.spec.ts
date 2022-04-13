import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParametreDetailComponent } from './parametre-detail.component';

describe('ParametreDetailComponent', () => {
  let component: ParametreDetailComponent;
  let fixture: ComponentFixture<ParametreDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParametreDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ParametreDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
