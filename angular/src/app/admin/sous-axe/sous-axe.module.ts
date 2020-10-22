import { UpdateComponent } from './update/update.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SousAxeRoutingModule } from './sous-axe-routing.module';
import { SousAxeComponent } from './sous-axe.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatModule } from 'src/app/mat.module';


@NgModule({
  declarations: [SousAxeComponent, UpdateComponent],
  imports: [
    CommonModule,
    SousAxeRoutingModule,
    HttpClientModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  entryComponents: [
    UpdateComponent
  ]
})
export class SousAxeModule { }
