import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailCompteMembreComponent } from './detail-compte-membre.component';

describe('DetailCompteMembreComponent', () => {
  let component: DetailCompteMembreComponent;
  let fixture: ComponentFixture<DetailCompteMembreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailCompteMembreComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailCompteMembreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
