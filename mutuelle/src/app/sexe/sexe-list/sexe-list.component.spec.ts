import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SexeListComponent } from './sexe-list.component';

describe('SexeListComponent', () => {
  let component: SexeListComponent;
  let fixture: ComponentFixture<SexeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SexeListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SexeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
