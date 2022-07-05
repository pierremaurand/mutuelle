import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MembrePageComponent } from './membre-page.component';

describe('MembrePageComponent', () => {
  let component: MembrePageComponent;
  let fixture: ComponentFixture<MembrePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MembrePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MembrePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
