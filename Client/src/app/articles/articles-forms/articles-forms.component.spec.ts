import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticlesFormsComponent } from './articles-forms.component';

describe('ArticlesFormsComponent', () => {
  let component: ArticlesFormsComponent;
  let fixture: ComponentFixture<ArticlesFormsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ArticlesFormsComponent]
    });
    fixture = TestBed.createComponent(ArticlesFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
