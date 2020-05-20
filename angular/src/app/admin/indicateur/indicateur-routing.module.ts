import { IndicateurComponent } from './indicateur.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';



const routes: Routes = [
  { path: 'indicateur', redirectTo: '', pathMatch: 'full'},
  { path: '', component: IndicateurComponent }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IndicateurRoutingModule { }
