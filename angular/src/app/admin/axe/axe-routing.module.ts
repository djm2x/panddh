import { AxeComponent } from './axe.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';



const routes: Routes = [
  { path: 'axe', redirectTo: '', pathMatch: 'full'},
  { path: '', component: AxeComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AxeRoutingModule { }
