import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateUserProfileDescriptionComponent } from './update-user-profile-description.component';

describe('UpdateUserProfileDescriptionComponent', () => {
  let component: UpdateUserProfileDescriptionComponent;
  let fixture: ComponentFixture<UpdateUserProfileDescriptionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateUserProfileDescriptionComponent]
    });
    fixture = TestBed.createComponent(UpdateUserProfileDescriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
