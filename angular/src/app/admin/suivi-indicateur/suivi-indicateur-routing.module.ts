import { SuiviIndicateurComponent } from './suivi-indicateur.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: '', redirectTo: 'suivi-indicateur', pathMatch: 'full'},
  { path: 'suivi-indicateur', component: SuiviIndicateurComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SuiviIndicateurRoutingModule { }
