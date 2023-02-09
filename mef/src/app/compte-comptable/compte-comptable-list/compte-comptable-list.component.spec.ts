import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompteComptableListComponent } from './compte-comptable-list.component';

describe('CompteComptableListComponent', () => {
  let component: CompteComptableListComponent;
  let fixture: ComponentFixture<CompteComptableListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompteComptableListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CompteComptableListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
