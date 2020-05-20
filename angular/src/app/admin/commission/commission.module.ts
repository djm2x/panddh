import { DetailsComponent } from './details/details.component';
import { UpdateComponent } from './update/update.component';
import { ListComponent } from './list/list.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CommissionRoutingModule } from './commission-routing.module';
import { CommissionComponent } from './commission.component';
import { HttpClientModule } from '@angular/common/http';
import { MatModule } from 'src/app/mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TitleModule } from '../components/title/title.module';
import { MembreCommissionComponent } from './update/membre/membre.component';


@NgModule({
  declarations: [
    CommissionComponent,
    ListComponent,
    UpdateComponent,
    MembreCommissionComponent,
    DetailsComponent,
  ],
  imports: [
    CommonModule,
    CommissionRoutingModule,
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
export class CommissionModule { }
