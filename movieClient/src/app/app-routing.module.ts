import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './admin/layout/layout.component';
import { MovieComponent } from './ui/components/movie/movie.component';

const routes: Routes = [
  {path:"",component:MovieComponent},
  {path:"register"}
];

@NgModule({

  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
