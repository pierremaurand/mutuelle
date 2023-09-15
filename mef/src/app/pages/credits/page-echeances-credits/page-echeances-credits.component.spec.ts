import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageEcheancesCreditsComponent } from './page-echeances-credits.component';

describe('PageEcheancesCreditsComponent', () => {
  let component: PageEcheancesCreditsComponent;
  let fixture: ComponentFixture<PageEcheancesCreditsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PageEcheancesCreditsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageEcheancesCreditsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
