import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateUserProfileCoverComponent } from './update-user-profile-cover.component';

describe('UpdateUserProfileCoverComponent', () => {
  let component: UpdateUserProfileCoverComponent;
  let fixture: ComponentFixture<UpdateUserProfileCoverComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateUserProfileCoverComponent]
    });
    fixture = TestBed.createComponent(UpdateUserProfileCoverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
