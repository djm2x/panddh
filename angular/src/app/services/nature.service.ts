import { Nature } from './../Models/models';
import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class NatureService  extends SuperService<Nature> {

  constructor() {
    super('natures');
  }

}
