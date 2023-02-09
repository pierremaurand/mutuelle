import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateSexeComponent } from './update-sexe.component';

describe('UpdateSexeComponent', () => {
  let component: UpdateSexeComponent;
  let fixture: ComponentFixture<UpdateSexeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateSexeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateSexeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
