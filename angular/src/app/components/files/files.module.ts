import { MatModule } from './../../mat.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilesComponent } from './files.component';



@NgModule({
  declarations: [FilesComponent],
  imports: [
    CommonModule,
    MatModule,
  ]
})
export class FilesModule { }
