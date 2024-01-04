import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateUserBirthdayComponent } from './update-user-birthday.component';

describe('UpdateUserBirthdayComponent', () => {
  let component: UpdateUserBirthdayComponent;
  let fixture: ComponentFixture<UpdateUserBirthdayComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateUserBirthdayComponent]
    });
    fixture = TestBed.createComponent(UpdateUserBirthdayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
