import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListeChoixMembreComponent } from './liste-choix-membre.component';

describe('ListeChoixMembreComponent', () => {
  let component: ListeChoixMembreComponent;
  let fixture: ComponentFixture<ListeChoixMembreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListeChoixMembreComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListeChoixMembreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
