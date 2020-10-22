import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';

import { MatModule } from '../mat.module';
import { MatSnackBarModule, MatProgressSpinnerModule, MAT_DATE_LOCALE } from '@angular/material';
// import { Moment, MatMomentDateModule } from 'moment';

@NgModule({
  declarations: [
    AdminComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    // HttpClientModule,
    MatModule,
    // FormsModule,
    // ReactiveFormsModule,
    MatSnackBarModule,
    MatProgressSpinnerModule,
  ],
  providers: [
    {provide: MAT_DATE_LOCALE, useValue: 'fr'},
    // {provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE]},
    // {provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS},
  ]
})
export class AdminModule { }
