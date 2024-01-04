import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { PreloaderComponent } from './preloader/preloader.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    NavbarComponent,
    PreloaderComponent,
    SidebarComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    PreloaderComponent,
    NavbarComponent,
    SidebarComponent,
    FooterComponent
  ]
})
export class TemplateModule { }
