import { Indicateur, Commission } from '../Models/models';
import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class CommissionService extends SuperService<Commission> {

  constructor() {
    super('Commissions');
  }
}
