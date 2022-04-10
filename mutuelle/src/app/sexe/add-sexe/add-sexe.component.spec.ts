import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSexeComponent } from './add-sexe.component';

describe('AddSexeComponent', () => {
  let component: AddSexeComponent;
  let fixture: ComponentFixture<AddSexeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddSexeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddSexeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
