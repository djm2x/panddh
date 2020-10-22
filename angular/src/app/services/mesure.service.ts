import { Indicateur, Mesure } from '../Models/models';
import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class MesureService extends SuperService<Mesure> {

  constructor() {
    super('Mesures');
  }

  searchAndGet(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/searchAndGet`, o);
  }

  customAutocomplete(idCycle, name) {
    return this.http.get(`${this.urlApi}/${this.controller}/customAutocomplete/${idCycle}/${name}`);
  }

  // getByTypeOrganisme(id) {
  //   return this.http.get(`${this.urlApi}/${this.controller}/getByTypeOrganisme/${id}`);
  // }


}
