import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoughnutComponent } from './doughnut.component';

describe('DoughnutComponent', () => {
  let component: DoughnutComponent;
  let fixture: ComponentFixture<DoughnutComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DoughnutComponent]
    });
    fixture = TestBed.createComponent(DoughnutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
