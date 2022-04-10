import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SexeComponent } from './sexe.component';

describe('SexeComponent', () => {
  let component: SexeComponent;
  let fixture: ComponentFixture<SexeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SexeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SexeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
