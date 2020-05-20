import { Injectable } from '@angular/core';
import { SuperService } from './super.service';
import { IndicateurMesureValue } from '../Models/models';

@Injectable({
  providedIn: 'root'
})
export class IndicateurMesureValueService extends SuperService<IndicateurMesureValue> {

  constructor() {
    super('IndicateurMesureValues');
  }

  // putRange(modelsToDelete, modelsToAdd) {
  //   return this.http.post(`${this.urlApi}/${this.controller}/putRange`, { modelsToDelete, modelsToAdd });
  // }

  
  // putIndicateurMesure(model) {
  //   return this.http.post(`${this.urlApi}/${this.controller}/putIndicateurMesure`, model);
  // }

  getAll(startIndex, pageSize, sortBy, sortDir, id) {
    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${id}`);
  }

  getForDiagramme(idIndicateur, idMesure) {
    return this.http.get(`${this.urlApi}/${this.controller}/getForDiagramme/${idIndicateur}/${idMesure}`);
  }

}
