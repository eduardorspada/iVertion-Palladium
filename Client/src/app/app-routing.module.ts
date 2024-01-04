import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ManagerComponent } from './manager/manager.component';
import { ClientComponent } from './client/client.component';
import { authGuard } from './auth.guard';
import { ForbiddenPageComponent } from './error/forbidden-page/forbidden-page.component';


const routes: Routes = [
  {path: '', component: ClientComponent},
  {path: 'manager', component: ManagerComponent, canActivate: [authGuard], children: [
    {path: 'dashboard', component: DashboardComponent},
    {path: '403', component: ForbiddenPageComponent},
    
  ]}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
