import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersProfilesListComponent } from './users-profiles-list.component';

describe('UsersProfilesListComponent', () => {
  let component: UsersProfilesListComponent;
  let fixture: ComponentFixture<UsersProfilesListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UsersProfilesListComponent]
    });
    fixture = TestBed.createComponent(UsersProfilesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
