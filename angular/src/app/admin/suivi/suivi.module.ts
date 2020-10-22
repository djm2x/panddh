import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SuiviRoutingModule } from './suivi-routing.module';
import { SuiviComponent } from './suivi.component';
import { ListComponent } from './list/list.component';
import { UpdateComponent } from './update/update.component';
import { HttpClientModule } from '@angular/common/http';
import { MatModule } from 'src/app/mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TitleModule } from '../components/title/title.module';
import { DetailsComponent } from './details/details.component';


@NgModule({
  declarations: [
    SuiviComponent,
    ListComponent,
    UpdateComponent,
    DetailsComponent,
  ],
  imports: [
    CommonModule,
    SuiviRoutingModule,
    HttpClientModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
    TitleModule,
  ],
  entryComponents: [
    DetailsComponent,
  ]
})
export class SuiviModule { }
