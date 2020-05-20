import { FormControl } from '@angular/forms';
import { Component, OnInit, ViewChild, EventEmitter } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { merge } from 'rxjs';
import { UpdateComponent } from './update/update.component';
import { DeleteService } from '../components/delete/delete.service';
import { UowService } from 'src/app/services/uow.service';
import { IndicateurMesureValue } from 'src/app/Models/models';

@Component({
  selector: 'app-suivi-indicateur',
  templateUrl: './suivi-indicateur.component.html',
  styleUrls: ['./suivi-indicateur.component.scss']
})
export class SuiviIndicateurComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  update = new EventEmitter();
  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;
  idMesure = new FormControl(0);
  mesures = [];
  cycles = this.uow.cycles.get();
  panelOpenState = false;
  dataSource = [];
  columnDefs = [
    { columnDef: 'cycle', headName: 'المرحلة' },
    { columnDef: 'mesure', headName: 'التدبير' },
    { columnDef: 'indicateur', headName: 'المؤشرات' },
    { columnDef: 'date', headName: 'تاريخ' },
    { columnDef: 'value', headName: 'قيمة / نسبة' },
    { columnDef: 'option', headName: '' },
  ];

  displayedColumns = this.columnDefs.map(e => e.columnDef);

  constructor(private uow: UowService, public dialog: MatDialog, private mydialog: DeleteService, ) { }

  ngOnInit() {
    this.getPage(0, 10, 'id', 'desc');
    merge(...[this.sort.sortChange, this.paginator.page, this.update]).subscribe(
      r => {
        r === true ? this.paginator.pageIndex = 0 : r = r;
        !this.paginator.pageSize ? this.paginator.pageSize = 10 : r = r;
        const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
        this.isLoadingResults = true;
        this.getPage(
          startIndex,
          this.paginator.pageSize,
          this.sort.active ? this.sort.active : 'id',
          this.sort.direction ? this.sort.direction : 'desc',
        );
      }
    );
  }

  getPage(startIndex, pageSize, sortBy, sortDir) {
    this.uow.indicateurMesureValues.getAll(startIndex, pageSize, sortBy, sortDir, this.idMesure.value).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
      }
    );
  }

  // getTypeName(id) {
  //   return this.uow.typeindicateurMesureValues.find(e => e.id === id).name;
  // }

  openDialog(o: IndicateurMesureValue, text) {
    const dialogRef = this.dialog.open(UpdateComponent, {
      width: '750px',
      disableClose: true,
      data: { model: o, title: text },
      direction: 'rtl',
    });

    return dialogRef.afterClosed();
  }

  add() {
    this.openDialog(new IndicateurMesureValue(), 'إضافة قيمة مؤشر').subscribe(result => {
      if (result) {
        this.uow.indicateurMesureValues.post(result).subscribe(
          r => {
            this.update.next(true);
          }
        );
      }
    });
  }

  edit(o: IndicateurMesureValue) {
    this.openDialog(o, 'تغير قيمة مؤشر').subscribe((result: IndicateurMesureValue) => {
      if (result) {
        this.uow.indicateurMesureValues.put(result.id, result).subscribe(
          r => {
            this.update.next(true);
          }
        );
      }
    });
  }

  async delete(id: number) {
    const r = await this.mydialog.openDialog('organisme').toPromise();
    if (r === 'ok') {
      this.uow.indicateurMesureValues.delete(id).subscribe(() => this.update.next(true));
    }
  }

  selectChange(id, name) {
    if (name === 'axe') {
      // this.uow.sousAxes.getByIdAxe(id).subscribe(r => {
      //   this.sousAxes = r as any[];
      // });
    } else if (name === 'cycle') {
      this.uow.mesures.getByForeignKey(id).subscribe(r => {
        this.mesures = r as any[];
      });

    }
  }

  reset() {
    this.idMesure.setValue(0);
    this.update.next(true);
  }

  search(o: any) {
    this.update.next(true);
  }

}
