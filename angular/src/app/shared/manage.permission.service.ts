import { Permission } from '../Models/models';
import { SessionService } from './session.service';
import { UowService } from 'src/app/services/uow.service';
import { Injectable, OnInit } from '@angular/core';
import { Action } from '../Models/models';

@Injectable({
  providedIn: 'root'
})
export class ManagePermissionService {
  permissions: Permission[] = [];
  constructor(private session: SessionService) { }

  checkPermission(route, i = 0): boolean {
    if (this.session.user.idProfil === 1) {
      return true;
    }

    const action = i !== 1 ? Action.Consultation : Action.Modification;
    const obj = this.permissions.find(e => e.action === action && route.includes(e.routeScreen));
    return obj !== undefined;
  }

  
}
