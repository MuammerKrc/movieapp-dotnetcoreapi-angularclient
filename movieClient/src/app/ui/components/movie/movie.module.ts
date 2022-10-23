import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MovieComponent } from './movie.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    MovieComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([{path:"",component:MovieComponent}])

  ]
})
export class MovieModule { }
