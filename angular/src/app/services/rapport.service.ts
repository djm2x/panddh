import { Rapport } from './../Models/models';
import { Injectable } from '@angular/core';
import { SuperService } from './super.service';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RapportService  extends SuperService<Rapport> {

  constructor() {
    super('rapports');
  }

  getAllByTraite(startIndex, pageSize, sortBy, sortDir, idTraite) {
    return this.http.get(`${this.urlApi}/${this.controller}/getAllByTraite/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${idTraite}`);
  }



  uploadFiles(files: FormData) {
    if (!files) {
      return of(null);
    }
    return this.http.post(`${this.urlApi}/${this.controller}/uploadFiles`, files, {
      // headers: {'Content-Type': 'multipart/form-data'},
      reportProgress: true,
    });
  }

  getByIdTraite(id) {
    return this.http.get<Rapport[]>(`${this.urlApi}/${this.controller}/getByIdTraite/${id}`);
  }

  getByTraite(id) {
    return this.http.get<Rapport[]>(`${this.urlApi}/${this.controller}/getByTraite/${id}`);
  }

  postFile(file) {
    return this.http.post(`${this.urlApi}/files/postFile`, file, { reportProgress: true });
  }

  deleteFile(filename, folder) {
    return this.http.post(`${this.urlApi}/files/deleteFile/`, { filename, folder }, { reportProgress: true });
  }

  deleteFiles(filenames: string[], folder) {
    if (filenames.length === 0) {
      return of(null);
    }
    return this.http.post(`${this.urlApi}/files/deleteFiles/`, { filenames, folder }, { reportProgress: true });
  }

  download(filename) {
    return this.http.get(`${this.url}/rapport/${filename}`);
  }

}
