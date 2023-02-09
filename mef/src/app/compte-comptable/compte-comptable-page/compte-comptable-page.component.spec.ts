import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompteComptablePageComponent } from './compte-comptable-page.component';

describe('CompteComptablePageComponent', () => {
  let component: CompteComptablePageComponent;
  let fixture: ComponentFixture<CompteComptablePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompteComptablePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CompteComptablePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
