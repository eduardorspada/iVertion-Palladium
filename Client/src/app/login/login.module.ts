import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginRoutingModule } from './login-routing.module';
import { FormsModule } from '@angular/forms';
import { LoginFormComponent } from './login-form/login-form.component';


@NgModule({
  declarations: [
    LoginFormComponent
  ],
  imports: [
    CommonModule,
    LoginRoutingModule,
    FormsModule
  ],
  exports: [
    LoginFormComponent
  ]
})
export class LoginModule { }
