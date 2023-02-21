import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PagePosteComponent } from './page-poste.component';

describe('PagePosteComponent', () => {
  let component: PagePosteComponent;
  let fixture: ComponentFixture<PagePosteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PagePosteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PagePosteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
