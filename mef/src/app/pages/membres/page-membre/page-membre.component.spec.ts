import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageMembreComponent } from './page-membre.component';

describe('PageMembreComponent', () => {
  let component: PageMembreComponent;
  let fixture: ComponentFixture<PageMembreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PageMembreComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageMembreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
