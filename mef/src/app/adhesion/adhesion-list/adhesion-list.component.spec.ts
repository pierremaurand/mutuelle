import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdhesionListComponent } from './adhesion-list.component';

describe('AdhesionListComponent', () => {
  let component: AdhesionListComponent;
  let fixture: ComponentFixture<AdhesionListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdhesionListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdhesionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
