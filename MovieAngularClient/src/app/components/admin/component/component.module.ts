import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardModule } from './dashboard/dashboard.module';
import { MoviesModule } from './movies/movies.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    DashboardModule,
    MoviesModule
  ]
})
export class ComponentModule { }
