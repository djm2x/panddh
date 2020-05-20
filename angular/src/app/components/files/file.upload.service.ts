import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class FileUploadService {

  constructor(private http: HttpClient, @Inject('BASE_URL') public url: string) { }

  postFile(file) {
    return this.http.post(`${this.url}/files/postFile`, file, { reportProgress: true });
  }

  deleteFile(filename, folder) {
    return this.http.post(`${this.url}/files/deleteFile/`, { filename, folder }, { reportProgress: true });
  }

  download(filename) {
    return this.http.get(`${this.url}/Visite/${filename}`);
  }

}
