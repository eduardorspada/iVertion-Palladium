import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnauthorizedPageComponent } from './unauthorized-page.component';

describe('UnauthorizedPageComponent', () => {
  let component: UnauthorizedPageComponent;
  let fixture: ComponentFixture<UnauthorizedPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UnauthorizedPageComponent]
    });
    fixture = TestBed.createComponent(UnauthorizedPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
