import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BadlyRatedPostsComponent } from './badly-rated-posts.component';

describe('BadlyRatedPostsComponent', () => {
  let component: BadlyRatedPostsComponent;
  let fixture: ComponentFixture<BadlyRatedPostsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BadlyRatedPostsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BadlyRatedPostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
