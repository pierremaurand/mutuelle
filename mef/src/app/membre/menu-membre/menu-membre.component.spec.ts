import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuMembreComponent } from './menu-membre.component';

describe('MenuMembreComponent', () => {
  let component: MenuMembreComponent;
  let fixture: ComponentFixture<MenuMembreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenuMembreComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuMembreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
