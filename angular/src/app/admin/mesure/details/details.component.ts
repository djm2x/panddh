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
  o: Mesure;
  title = '';
  partenaires: Organisme[] = [];
  activites: Activite[] = [];
  indicateurs: Indicateur[] = [];
  columnDefs = [
    { columnDef: 'article', headName: '' },
    { columnDef: 'qtePrise', headName: 'QTE' },
    { columnDef: 'prixVente', headName: 'P.U' },
    { columnDef: 'total', headName: '' },
  ].map(e => {
    e.headName = e.headName === '' ? e.columnDef.toUpperCase() : e.headName;
    return e;
  });

  displayedColumns = this.columnDefs.map(e => e.columnDef);

  constructor(public dialogRef: MatDialogRef<any>, @Inject(MAT_DIALOG_DATA) public data: any
  , private uow: UowService) { }

  ngOnInit() {
    this.o = this.data.model;
    this.partenaires = this.o.partenariats.map(e => e.organisme);
    this.activites = this.o.activites;
    this.indicateurs = this.o.indicateurMesures.map(e => e.indicateur);

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
