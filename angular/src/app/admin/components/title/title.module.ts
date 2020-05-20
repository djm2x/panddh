import { MatModule } from './../../../mat.module';
import { TitleComponent } from './title.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [TitleComponent],
  imports: [
    CommonModule,
    MatModule,
  ],
  exports: [TitleComponent]
})
export class TitleModule { }
