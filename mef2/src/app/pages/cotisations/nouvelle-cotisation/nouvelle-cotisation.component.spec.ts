import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NouvelleCotisationComponent } from './nouvelle-cotisation.component';

describe('NouvelleCotisationComponent', () => {
  let component: NouvelleCotisationComponent;
  let fixture: ComponentFixture<NouvelleCotisationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NouvelleCotisationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NouvelleCotisationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
