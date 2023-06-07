import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageEcheancesAvancesComponent } from './page-echeances-avances.component';

describe('PageEcheancesAvancesComponent', () => {
  let component: PageEcheancesAvancesComponent;
  let fixture: ComponentFixture<PageEcheancesAvancesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PageEcheancesAvancesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageEcheancesAvancesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
