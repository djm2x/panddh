import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class OrganismeService  extends SuperService<any> {

  constructor() {
    super('organisme');
  }

  // getByForeignKey(id) {
  //   return this.http.get(`${this.urlApi}/${this.controller}/getByForeignKey/${id}`);
  // }

  getByType(id) {
    return this.http.get(`${this.urlApi}/${this.controller}/getByType/${id}`);
  }

}
