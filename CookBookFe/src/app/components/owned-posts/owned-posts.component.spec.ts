import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnedPostsComponent } from './owned-posts.component';

describe('OwnedPostsComponent', () => {
  let component: OwnedPostsComponent;
  let fixture: ComponentFixture<OwnedPostsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OwnedPostsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OwnedPostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
