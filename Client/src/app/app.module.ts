import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { TemplateModule } from './template/template.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ArticlesModule } from './articles/articles.module';
import { MapaComponent } from './mapa/mapa.component';
import { FormsModule } from '@angular/forms';
import { ChartsModule } from './charts/charts.module';
import { ArticlesService } from './articles.service';
import { LoginModule } from './login/login.module';
import { ManagerComponent } from './manager/manager.component';
import { ClientComponent } from './client/client.component';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { AuthService } from './auth.service';
import { TokenInterceptor } from './token.interceptor';
import { UsersModule } from './users/users.module';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    MapaComponent,
    ManagerComponent,
    ClientComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    TemplateModule,
    ArticlesModule,
    FormsModule,
    FroalaEditorModule.forRoot(),
    FroalaViewModule.forRoot(),
    ChartsModule,
    HttpClientModule,
    LoginModule,
    UsersModule
    
  ],
  exports : [],
  providers: [
    ArticlesService,
    AuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    provideAnimationsAsync(),
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
