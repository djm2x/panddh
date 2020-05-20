import { SousAxeComponent } from './sous-axe.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';



const routes: Routes = [
  { path: 'sous-axe', redirectTo: '', pathMatch: 'full'},
  { path: '', component: SousAxeComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SousAxeRoutingModule { }
