import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { SessionService } from 'src/app/shared';
import { ManagePermissionService } from 'src/app/shared/manage.permission.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

  constructor(private session: SessionService, private router: Router) { }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    console.log('url : ', state.url);
    if (this.session.checkPermission(state.url)) {
      return true;
    }

    this.router.navigate(['/admin']);
    return false;

  }
}
