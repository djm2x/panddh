import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class AxeService  extends SuperService<any> {

  constructor() {
    super('axes');
  }

}
