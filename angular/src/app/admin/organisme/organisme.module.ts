import { MatModule } from './../../mat.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrganismeComponent } from './organisme.component';
import { UpdateComponent } from './update/update.component';
import { OrganismeRoutingModule } from './organisme-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    OrganismeComponent,
    UpdateComponent,
    // BreadcrumbsComponent,
  ],
  imports: [
    OrganismeRoutingModule,
    CommonModule,
    HttpClientModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  entryComponents: [
    UpdateComponent
  ]
})
export class OrganismeModule { }
