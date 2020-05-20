import { ObjectifComponent } from './objectif.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: 'objectif', redirectTo: '', pathMatch: 'full'},
  { path: '', component: ObjectifComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ObjectifRoutingModule { }
