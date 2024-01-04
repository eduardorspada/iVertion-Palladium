import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateUserOccupationComponent } from './update-user-occupation.component';

describe('UpdateUserOccupationComponent', () => {
  let component: UpdateUserOccupationComponent;
  let fixture: ComponentFixture<UpdateUserOccupationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateUserOccupationComponent]
    });
    fixture = TestBed.createComponent(UpdateUserOccupationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
