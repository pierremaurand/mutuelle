import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateMembreComponent } from './update-membre.component';

describe('UpdateMembreComponent', () => {
  let component: UpdateMembreComponent;
  let fixture: ComponentFixture<UpdateMembreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateMembreComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateMembreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
