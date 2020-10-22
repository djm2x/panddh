import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SuiviIndicateurRoutingModule } from './suivi-indicateur-routing.module';
import { SuiviIndicateurComponent } from './suivi-indicateur.component';
import { UpdateComponent } from './update/update.component';
import { HttpClientModule } from '@angular/common/http';
import { MatModule } from 'src/app/mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [SuiviIndicateurComponent, UpdateComponent],
  imports: [
    CommonModule,
    SuiviIndicateurRoutingModule,
    HttpClientModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  entryComponents: [
    UpdateComponent
  ]
})
export class SuiviIndicateurModule { }
