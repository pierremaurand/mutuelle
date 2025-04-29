import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListeMembreComponent } from './liste-membre.component';

describe('ListeMembreComponent', () => {
  let component: ListeMembreComponent;
  let fixture: ComponentFixture<ListeMembreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListeMembreComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListeMembreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
