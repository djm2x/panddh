import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IndicateurRoutingModule } from './indicateur-routing.module';
import { IndicateurComponent } from './indicateur.component';
import { HttpClientModule } from '@angular/common/http';
import { MatModule } from 'src/app/mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UpdateComponent } from './update/update.component';


@NgModule({
  declarations: [IndicateurComponent, UpdateComponent],
  imports: [
    CommonModule,
    IndicateurRoutingModule,
    HttpClientModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  entryComponents: [
    UpdateComponent
  ]
})
export class IndicateurModule { }
