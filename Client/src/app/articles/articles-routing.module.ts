import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArticlesFormsComponent } from './articles-forms/articles-forms.component';
import { ManagerComponent } from '../manager/manager.component';
import { authGuard } from '../auth.guard';

const routes: Routes = [
  {path: 'manager/article', component: ManagerComponent, canActivate: [authGuard], children: [
    {path: 'form', component: ArticlesFormsComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ArticlesRoutingModule { }
