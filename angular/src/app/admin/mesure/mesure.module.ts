import { ListComponent } from './list/list.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MesureRoutingModule } from './mesure-routing.module';
import { MesureComponent } from './mesure.component';
import { HttpClientModule } from '@angular/common/http';
import { MatModule } from 'src/app/mat.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TitleModule } from '../components/title/title.module';
import { UpdateComponent } from './update/update.component';
import { PartenaireComponent } from './partenaire/partenaire.component';
import { IndicateurComponent } from './indicateur/indicateur.component';
import { ActiviteComponent } from './activite/activite.component';
import { DetailsComponent } from './details/details.component';


@NgModule({
  declarations: [
    MesureComponent,
    ListComponent,
    UpdateComponent,
    PartenaireComponent,
    IndicateurComponent,
    ActiviteComponent,
    DetailsComponent,
  ],
  imports: [
    CommonModule,
    MesureRoutingModule,
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
export class MesureModule { }
