import { Injectable } from '@angular/core';
import { SuperService } from './super.service';
import { Realisation } from '../Models/models';

@Injectable({
  providedIn: 'root'
})
export class RealisationService  extends SuperService<Realisation> {

  constructor() {
    super('Realisations');
  }

  // getAll(startIndex, pageSize, sortBy, sortDir, idSynthese) {
  //   return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${idSynthese}`);
  // }

  searchAndGet(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/searchAndGet`, o);
  }

  GetRapportLiterary(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/GetRapportLiterary`, o);
  }

  getRapportQualitative(o) {
    return this.http.post(`${this.urlApi}/${this.controller}/getRapportQualitative`, o);
  }

}
