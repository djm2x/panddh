import { Realisation } from './../../../Models/models';
import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Mesure, Organisme, Activite, Indicateur } from 'src/app/Models/models';
@Component({
  selector: 'app-update',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {
  o: Realisation;
  title = '';


  constructor(public dialogRef: MatDialogRef<any>, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.o = this.data.model;


    // this.title = typeof(Synthese).name.toUpperCase;
    this.title = this.data.title;
    // console.log(this.dataSource);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onOkClick(o: any): void {
    // o.date = this.valideDate(o.date);
    // this.dialogRef.close({ model: o, file: this.file });
  }



}
