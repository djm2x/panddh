import { Notification } from './../Models/models';
import { Injectable } from '@angular/core';
import { SuperService } from './super.service';

@Injectable({
  providedIn: 'root'
})
export class NotificationService  extends SuperService<Notification> {

  constructor() {
    super('notifications');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, idOrganisme) {
    return this.http.get(
      `${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${idOrganisme}`);
  }

}
