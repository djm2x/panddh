import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Commission } from 'src/app/Models/models';
@Component({
  selector: 'app-update',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {
  o: Commission;
  title = '';
  dataSource = [];
  columnDefs = [
    { columnDef: 'nomComplete', headName: 'الإسم الكامل' },
    { columnDef: 'email', headName: 'البريد الإلكتروني' },
  ].map(e => {
    e.headName = e.headName === '' ? e.columnDef.toUpperCase() : e.headName;
    return e;
  });

  displayedColumns = this.columnDefs.map(e => e.columnDef);

  constructor(public dialogRef: MatDialogRef<any>, @Inject(MAT_DIALOG_DATA) public data: any
  , private uow: UowService) { }

  ngOnInit() {
    this.o = this.data.model;
    this.dataSource = this.o.membreCommissions;
    this.title = this.data.title;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onOkClick(o: any): void {
  }



}
