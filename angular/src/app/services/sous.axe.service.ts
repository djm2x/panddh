import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class SousAxeService  extends SuperService<any> {

  constructor() {
    super('sousAxes');
  }

  getByIdAxe(id) {
    return this.http.get(`${this.urlApi}/${this.controller}/getByIdAxe/${id}`);
  }

}
