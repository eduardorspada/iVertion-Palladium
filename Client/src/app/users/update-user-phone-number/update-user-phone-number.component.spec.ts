import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateUserPhoneNumberComponent } from './update-user-phone-number.component';

describe('UpdateUserPhoneNumberComponent', () => {
  let component: UpdateUserPhoneNumberComponent;
  let fixture: ComponentFixture<UpdateUserPhoneNumberComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateUserPhoneNumberComponent]
    });
    fixture = TestBed.createComponent(UpdateUserPhoneNumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
