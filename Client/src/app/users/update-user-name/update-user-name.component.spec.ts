import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateUserNameComponent } from './update-user-name.component';

describe('UpdateUserNameComponent', () => {
  let component: UpdateUserNameComponent;
  let fixture: ComponentFixture<UpdateUserNameComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateUserNameComponent]
    });
    fixture = TestBed.createComponent(UpdateUserNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
