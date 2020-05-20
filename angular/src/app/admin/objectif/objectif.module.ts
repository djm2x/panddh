import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ObjectifRoutingModule } from './objectif-routing.module';
import { ObjectifComponent } from './objectif.component';
import { HttpClientModule } from '@angular/common/http';
import { MatModule } from 'src/app/mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UpdateComponent } from './update/update.component';


@NgModule({
  declarations: [ObjectifComponent, UpdateComponent],
  imports: [
    CommonModule,
    ObjectifRoutingModule,
    HttpClientModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  entryComponents: [
    UpdateComponent
  ]
})
export class ObjectifModule { }
