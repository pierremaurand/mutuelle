import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateGabaritComponent } from './update-gabarit.component';

describe('UpdateGabaritComponent', () => {
  let component: UpdateGabaritComponent;
  let fixture: ComponentFixture<UpdateGabaritComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateGabaritComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateGabaritComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
