import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateUserStatusComponent } from './update-user-status.component';

describe('UpdateUserStatusComponent', () => {
  let component: UpdateUserStatusComponent;
  let fixture: ComponentFixture<UpdateUserStatusComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateUserStatusComponent]
    });
    fixture = TestBed.createComponent(UpdateUserStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
