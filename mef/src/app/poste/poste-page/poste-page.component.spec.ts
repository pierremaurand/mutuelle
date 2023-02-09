import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostePageComponent } from './poste-page.component';

describe('PostePageComponent', () => {
  let component: PostePageComponent;
  let fixture: ComponentFixture<PostePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PostePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
