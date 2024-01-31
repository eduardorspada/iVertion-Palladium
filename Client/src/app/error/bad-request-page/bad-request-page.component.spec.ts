import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BadRequestPageComponent } from './bad-request-page.component';

describe('BadRequestPageComponent', () => {
  let component: BadRequestPageComponent;
  let fixture: ComponentFixture<BadRequestPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BadRequestPageComponent]
    });
    fixture = TestBed.createComponent(BadRequestPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
