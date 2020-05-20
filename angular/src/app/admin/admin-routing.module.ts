import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminGuard } from './guard/admin.guard';

const routes: Routes = [
  { path: '', redirectTo: '', pathMatch: 'full' },
  {
    path: '', component: AdminComponent,
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full'},
      { path: 'home', loadChildren: () => import('./home/home.module').then(m => m.HomeModule), },
      { path: 'user', loadChildren: () => import('./user/user.module').then(m => m.UserModule), canActivate: [AdminGuard]},
      // tslint:disable-next-line: max-line-length
      { path: 'indicateur', loadChildren: () => import('./indicateur/indicateur.module').then(m => m.IndicateurModule), canActivate: [AdminGuard] },
      { path: 'objectif', loadChildren: () => import('./objectif/objectif.module').then(m => m.ObjectifModule), canActivate: [AdminGuard] },
      // tslint:disable-next-line: max-line-length
      { path: 'organisme', loadChildren: () => import('./organisme/organisme.module').then(m => m.OrganismeModule), canActivate: [AdminGuard]},
      { path: 'nature', loadChildren: () => import('./nature/nature.module').then(m => m.NatureModule), canActivate: [AdminGuard] },
      { path: 'profil', loadChildren: () => import('./profil/profil.module').then(m => m.ProfilModule), canActivate: [AdminGuard]},
      // tslint:disable-next-line: max-line-length
      { path: 'permission', loadChildren: () => import('./permission/permission.module').then(m => m.PermissionModule), canActivate: [AdminGuard]},
      { path: 'mesure-executif', loadChildren: () => import('./mesure/mesure.module').then(m => m.MesureModule), canActivate: [AdminGuard]},
      { path: 'mesure-region', loadChildren: () => import('./mesure/mesure.module').then(m => m.MesureModule), canActivate: [AdminGuard] },
      // tslint:disable-next-line: max-line-length
      { path: 'mesure-programme', loadChildren: () => import('./mesure/mesure.module').then(m => m.MesureModule), canActivate: [AdminGuard]},
      { path: 'cycle', loadChildren: () => import('./cycle/cycle.module').then(m => m.CycleModule), canActivate: [AdminGuard]},
      { path: 'axe', loadChildren: () => import('./axe/axe.module').then(m => m.AxeModule), canActivate: [AdminGuard]},
      { path: 'suivi', loadChildren: () => import('./suivi/suivi.module').then(m => m.SuiviModule), canActivate: [AdminGuard]},
      // tslint:disable-next-line: max-line-length
      { path: 'suivi-indicateur', loadChildren: () => import('./suivi-indicateur/suivi-indicateur.module').then(m => m.SuiviIndicateurModule), canActivate: [AdminGuard]},
      { path: 'sous-axe', loadChildren: () => import('./sous-axe/sous-axe.module').then(m => m.SousAxeModule), canActivate: [AdminGuard]},
      { path: 'rapport-litteraire', loadChildren: () => import('./rapportL/rapport.module').then(m => m.RapportModule), },
      { path: 'rapport-qualitative', loadChildren: () => import('./rapportQ/rapport.module').then(m => m.RapportModule), },
      { path: 'compte', loadChildren: () => import('./compte/compte.module').then(m => m.CompteModule), canActivate: [AdminGuard] },
      // tslint:disable-next-line: max-line-length suivi-indicateur
      { path: 'commission', loadChildren: () => import('./commission/commission.module').then(m => m.CommissionModule), canActivate: [AdminGuard] }
    ]
  },
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
