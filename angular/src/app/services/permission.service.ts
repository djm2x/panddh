import { Permission } from './../Models/models';
import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class PermissionService  extends SuperService<Permission> {

  constructor() {
    super('Permissions');
  }

  getByProfil(id) {
    return this.http.get<Permission[]>(`${this.urlApi}/${this.controller}/getByProfil/${id}`);
  }

  getAll(startIndex, pageSize, sortBy, sortDir, id) {
    return this.http.get(
      `${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${id}`);
  }

}
