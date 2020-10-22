import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HttpClientModule } from '@angular/common/http';
import { MatModule } from 'src/app/mat.module';
import { HomeRoutingModule } from './home-routing.module';
import { ChartsModule } from 'ng2-charts';
import { adapterFactory } from 'angular-calendar/date-adapters/moment';
import * as moment from 'moment';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { CalendarComponent } from './calendar/calendar.component';
import { BarOneComponent } from './bar-one/bar-one.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

export function momentAdapterFactory() {
  return adapterFactory(moment);
};
@NgModule({
  declarations: [
    HomeComponent,
    CalendarComponent,
    BarOneComponent,
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatModule,
    ChartsModule,
    CalendarModule.forRoot({ provide: DateAdapter, useFactory: momentAdapterFactory }),
  ]
})
export class HomeModule { }
