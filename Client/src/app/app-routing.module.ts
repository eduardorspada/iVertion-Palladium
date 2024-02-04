import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ManagerComponent } from './manager/manager.component';
import { ClientComponent } from './client/client.component';
import { authGuard } from './auth.guard';
import { ForbiddenPageComponent } from './error/forbidden-page/forbidden-page.component';
import { BadRequestPageComponent } from './error/bad-request-page/bad-request-page.component';
import { UnauthorizedPageComponent } from './error/unauthorized-page/unauthorized-page.component';
import { NotFoundPageComponent } from './error/not-found-page/not-found-page.component';
import { InternalServerErrorPageComponent } from './error/internal-server-error-page/internal-server-error-page.component';


const routes: Routes = [
  {path: '', component: ClientComponent},
  {path: 'manager', component: ManagerComponent, canActivate: [authGuard], children: [
    {path: 'dashboard', component: DashboardComponent},
    {path: '400', component: BadRequestPageComponent},
    {path: '401', component: UnauthorizedPageComponent},
    {path: '403', component: ForbiddenPageComponent},
    {path: '404', component: NotFoundPageComponent},
    {path: '500', component: InternalServerErrorPageComponent}

  ]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
