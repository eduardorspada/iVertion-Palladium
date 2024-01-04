import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateUserFullNameComponent } from './update-user-full-name.component';

describe('UpdateUserFullNameComponent', () => {
  let component: UpdateUserFullNameComponent;
  let fixture: ComponentFixture<UpdateUserFullNameComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateUserFullNameComponent]
    });
    fixture = TestBed.createComponent(UpdateUserFullNameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
