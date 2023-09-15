import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NouvelleAvanceComponent } from './nouvelle-avance.component';

describe('NouvelleAvanceComponent', () => {
  let component: NouvelleAvanceComponent;
  let fixture: ComponentFixture<NouvelleAvanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NouvelleAvanceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NouvelleAvanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
