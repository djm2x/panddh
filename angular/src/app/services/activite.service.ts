import { Injectable } from '@angular/core';
import { SuperService } from './super.service';
import { Activite } from '../Models/models';

@Injectable({
  providedIn: 'root'
})
export class ActiviteService  extends SuperService<Activite> {

  constructor() {
    super('Activites');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, id) {
    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${id}`);
  }

}
