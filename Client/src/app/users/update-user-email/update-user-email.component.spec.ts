import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateUserEmailComponent } from './update-user-email.component';

describe('UpdateUserEmailComponent', () => {
  let component: UpdateUserEmailComponent;
  let fixture: ComponentFixture<UpdateUserEmailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateUserEmailComponent]
    });
    fixture = TestBed.createComponent(UpdateUserEmailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
