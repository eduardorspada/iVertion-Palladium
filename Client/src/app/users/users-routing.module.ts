import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManagerComponent } from '../manager/manager.component';
import { UsersListComponent } from './users-list/users-list.component';
import { authGuard } from '../auth.guard';
import { UserComponent } from './user/user.component';
import { CreateUserComponent } from './create-user/create-user.component';
import { UsersProfilesListComponent } from './users-profiles-list/users-profiles-list.component';

const routes: Routes = [
  {path: 'manager/users', component: ManagerComponent, canActivate: [authGuard], children: [
    {path: 'list', component: UsersListComponent},
    {path: 'user/:id', component: UserComponent},
    {path: 'form', component: CreateUserComponent},
    {path: 'users-profile-list', component: UsersProfilesListComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
