import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectMembreComponent } from './select-membre.component';

describe('SelectMembreComponent', () => {
  let component: SelectMembreComponent;
  let fixture: ComponentFixture<SelectMembreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectMembreComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectMembreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
