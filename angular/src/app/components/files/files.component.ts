import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.scss']
})
export class FilesComponent implements OnInit {
  title = typeof (FilesComponent).name;
  files: File[] = [];
  // progress: number;
  // message: any;
  filename = 'Choisie un rapport';
  iconFile = '';
  pieceJointe = '';
  pieceJointeToShow: string[] = [];
  pieceJointeToDelete: string[] = [];
  o: any;
  formData = new FormData();
  @Input() urls = '';
  @Output() sendFormDataToParent = new EventEmitter<{formData: FormData, urls: string}>();

  constructor() { }

  ngOnInit() {
    const pieces = this.o.pieceJointe.split(';');
    pieces.pop();
    pieces.forEach(e => this.pieceJointeToShow.push(e));
    this.pieceJointe = this.o.pieceJointe;
  }

  upload(files: FileList) {
    Array.from(files).forEach((file: File) => {
      const nameFile = `${file.lastModified}_${file.name}` as string;
      const exist = this.formData.has(`${file.lastModified}_${file.name}`) || this.pieceJointe.includes(nameFile) as boolean;

      if (!exist) {
        this.formData.append(nameFile, file, nameFile);
        this.pieceJointe += `${nameFile};`;
        this.pieceJointeToShow.push(`${file.lastModified}_${file.name};`);
        // console.log('>>>>>>>>>>>>>');
        // console.log(file);
        this.sendFormDataToParent.next({formData: this.formData, urls:  this.pieceJointe});
      }
    });
    console.log(this.pieceJointe);

    // to delete

  }

  // file manager

  openInput(o/*: HTMLInputElement*/) {
    o.click();
  }

  remove(nameFile: string) {
    this.pieceJointeToDelete.push(nameFile);
    this.pieceJointeToShow = this.pieceJointeToShow.filter(e => e !== nameFile);
    this.formData.delete(nameFile);
    // this.files = this.files.splice(i, 1);
    console.log(this.pieceJointe);
    this.pieceJointe = this.pieceJointe.replace(`${nameFile};`, '');
    console.log(this.pieceJointe);

    this.sendFormDataToParent.next({formData: this.formData, urls:  this.pieceJointe});
    // this.files = [];
    // this.filename = 'Choisie un rapport';
    // this.myForm.get('pieceJointe').setValue('');
    // this.iconFile = '';
  }

}
