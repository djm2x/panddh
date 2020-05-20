import { Mesure } from './../../../Models/models';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-update',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {
  dataSource = [];
  columnDefs = [
    { columnDef: 'titre', headName: 'اسم' },
    { columnDef: 'dateDernierRapport', headName: 'Date Rapport' },
    { columnDef: 'dateObservation', headName: 'Date des observations finales' },
    { columnDef: 'dateProchaineRapport', headName: 'Date Prochain Rapport' },
    { columnDef: 'reference', headName: 'Référence des observations finales' },
  ].map(e => {
    e.headName = e.headName === '' ? e.columnDef.toUpperCase() : e.headName;
    return e;
  });

  displayedColumns = this.columnDefs.map(e => e.columnDef);
  //
  o: Mesure;
  title = '';
  constructor(public dialogRef: MatDialogRef<any>, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.o = this.data.model;
    // this.dataSource = this.o.rapports;
    this.title = this.data.title;
    console.log(this.o);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onOkClick(o: any): void {
    // o.date = this.valideDate(o.date);
    // this.dialogRef.close({ model: o, file: this.file });
  }



}
