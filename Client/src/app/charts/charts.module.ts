import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LineComponent } from './line/line.component';
import { DoughnutComponent } from './doughnut/doughnut.component';



@NgModule({
  declarations: [
    LineComponent,
    DoughnutComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    LineComponent,
    DoughnutComponent
  ]
})
export class ChartsModule { }
