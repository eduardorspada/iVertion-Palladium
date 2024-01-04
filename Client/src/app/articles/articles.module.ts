import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ArticlesRoutingModule } from './articles-routing.module';
import { ArticlesFormsComponent } from './articles-forms/articles-forms.component';
import { FormsModule } from '@angular/forms';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';




@NgModule({
  declarations: [
    ArticlesFormsComponent
  ],
  imports: [
    CommonModule,
    ArticlesRoutingModule,
    FroalaEditorModule.forRoot(), 
    FroalaViewModule.forRoot(),
    FormsModule
  ],
  exports: [
    ArticlesFormsComponent
  ]
})
export class ArticlesModule { }
