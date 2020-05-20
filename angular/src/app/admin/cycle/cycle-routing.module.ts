import { CycleComponent } from './cycle.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: 'cycle', redirectTo: '', pathMatch: 'full'},
  { path: '', component: CycleComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CycleRoutingModule { }
