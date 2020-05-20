import { Injectable } from '@angular/core';
import { SuperService } from './super.service';
import { MembreCommission } from '../Models/models';

@Injectable({
  providedIn: 'root'
})
export class MembreCommissionService  extends SuperService<MembreCommission> {

  constructor() {
    super('MembreCommissions');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, id) {
    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${id}`);
  }

}
