import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class ProfilService  extends SuperService<any> {

  constructor() {
    super('profils');
  }

}
