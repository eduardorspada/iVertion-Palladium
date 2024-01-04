import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateUserProfilePictureComponent } from './update-user-profile-picture.component';

describe('UpdateUserProfilePictureComponent', () => {
  let component: UpdateUserProfilePictureComponent;
  let fixture: ComponentFixture<UpdateUserProfilePictureComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateUserProfilePictureComponent]
    });
    fixture = TestBed.createComponent(UpdateUserProfilePictureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
