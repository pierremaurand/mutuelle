import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComptabiliteListComponent } from './comptabilite-list.component';

describe('ComptabiliteListComponent', () => {
  let component: ComptabiliteListComponent;
  let fixture: ComponentFixture<ComptabiliteListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComptabiliteListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComptabiliteListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
