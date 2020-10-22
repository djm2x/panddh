import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class CycleService  extends SuperService<any> {

  constructor() {
    super('cycles');
  }

}
