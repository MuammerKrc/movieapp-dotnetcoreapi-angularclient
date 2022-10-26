import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/admin/component/dashboard/dashboard.component';
import { LayoutComponent } from './components/admin/layout/layout.component';
import { HomeComponent } from './components/ui/home/home.component';

const routes: Routes = [
  {path:"admin",component:LayoutComponent,children:[
     {path:"",component:DashboardComponent},
     {path:"movies-create",loadChildren:()=>import("./components/admin/component/movies/movies.module").then(module=>module.MoviesModule)},
  ]},

  {path:"",component:HomeComponent},
  {path:"register",loadChildren:()=>import('./components/ui/register/register.module').then(module=>module.RegisterModule)},
  {path:"login",loadChildren:()=>import('./components/ui/login/login.module').then(module=>module.LoginModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
