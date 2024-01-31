;
import { ForbiddenPageComponent } from './forbidden-page/forbidden-page.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotFoundPageComponent } from './not-found-page/not-found-page.component';
import { UnauthorizedPageComponent } from './unauthorized-page/unauthorized-page.component';
import { BadRequestPageComponent } from './bad-request-page/bad-request-page.component';



@NgModule({
  declarations: [
    ForbiddenPageComponent,
    NotFoundPageComponent,
    UnauthorizedPageComponent,
    BadRequestPageComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ErrorModule { }
