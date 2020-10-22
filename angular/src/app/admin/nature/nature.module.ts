import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NatureRoutingModule } from './nature-routing.module';
import { NatureComponent } from './nature.component';
import { HttpClientModule } from '@angular/common/http';
import { MatModule } from 'src/app/mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UpdateComponent } from './update/update.component';


@NgModule({
  declarations: [NatureComponent, UpdateComponent],
  imports: [
    CommonModule,
    NatureRoutingModule,
    HttpClientModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  entryComponents: [
    UpdateComponent,
  ]
})
export class NatureModule { }
