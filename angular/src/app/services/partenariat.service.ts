import { Injectable } from '@angular/core';
import { SuperService } from './super.service';
import { Partenariat } from '../Models/models';

@Injectable({
  providedIn: 'root'
})
export class PartenariatService extends SuperService<Partenariat> {

  constructor() {
    super('Partenariats');
  }

  putRange(modelsToDelete, modelsToAdd) {
    return this.http.post(`${this.urlApi}/${this.controller}/putRange`, { modelsToDelete, modelsToAdd });
  }

}
