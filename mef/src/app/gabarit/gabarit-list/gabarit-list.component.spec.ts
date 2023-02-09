import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GabaritListComponent } from './gabarit-list.component';

describe('GabaritListComponent', () => {
  let component: GabaritListComponent;
  let fixture: ComponentFixture<GabaritListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GabaritListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GabaritListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
