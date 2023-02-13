import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageCreditComponent } from './page-credit.component';

describe('PageCreditComponent', () => {
  let component: PageCreditComponent;
  let fixture: ComponentFixture<PageCreditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PageCreditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageCreditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
