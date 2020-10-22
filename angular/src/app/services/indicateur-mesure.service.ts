import { Injectable } from '@angular/core';
import { SuperService } from './super.service';
import { IndicateurMesure } from '../Models/models';

@Injectable({
  providedIn: 'root'
})
export class IndicateurMesureService extends SuperService<IndicateurMesure> {

  constructor() {
    super('IndicateurMesures');
  }

  putRange(modelsToDelete, modelsToAdd) {
    return this.http.post(`${this.urlApi}/${this.controller}/putRange`, { modelsToDelete, modelsToAdd });
  }

  
  putIndicateurMesure(model) {
    return this.http.post(`${this.urlApi}/${this.controller}/putIndicateurMesure`, model);
  }

  getAll(startIndex, pageSize, sortBy, sortDir, id) {
    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${id}`);
  }

}
