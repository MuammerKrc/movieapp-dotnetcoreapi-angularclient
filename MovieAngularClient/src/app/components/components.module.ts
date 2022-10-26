import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UiModule } from './ui/ui.module';
import { AdminModule } from './admin/admin.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    UiModule,
    AdminModule
  ]
})
export class ComponentsModule { }
