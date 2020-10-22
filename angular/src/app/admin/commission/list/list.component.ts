import { Commission } from './../../../Models/models';
import { MatPaginator, MatSort, MatDialog, MatAutocompleteSelectedEvent, MatInput } from '@angular/material';
import { merge, Observable } from 'rxjs';
import { UowService } from 'src/app/services/uow.service';
import { SnackbarService } from 'src/app/shared/snakebar.service';
import { DeleteService } from '../../components/delete/delete.service';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SessionService } from 'src/app/shared';
import { switchMap } from 'rxjs/operators';
import { Component, OnInit, ViewChild, EventEmitter } from '@angular/core';
import { DetailsComponent } from '../details/details.component';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  // @ViewChild('myAutocomplete', { static: true }) myAutocomplete: MatInput;
  update = new EventEmitter();
  isLoadingResults = false;
  resultsLength = 0;
  isRateLimitReached = false;
  dataSource = [];
  columnDefs = [
    { columnDef: 'type', headName: 'نوع اللجنة' },
    { columnDef: 'pv', headName: 'محضر ' },
    { columnDef: 'dateEvenement', headName: 'تاريخ الحدث' },
    // { columnDef: 'membre', headName: 'الأعضاء' },
    { columnDef: 'option', headName: '' },
  ].map(e => {
    e.headName = e.headName === '' ? e.columnDef.toUpperCase() : e.headName;
    return e;
  });
  //
  displayedColumns = this.columnDefs.map(e => e.columnDef);
  //
  constructor(private uow: UowService, private mydialog: DeleteService
    , public dialog: MatDialog, public session: SessionService
    , private route: ActivatedRoute, public router: Router) { }

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
    this.uow.commissions.getList(startIndex, pageSize, sortBy, sortDir).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
      }
    );
  }

  detail(o) {
    this.uow.commissions.getOneWithInclude(o.id).subscribe(r => {
      this.openDialog(r);
    });
  }

  openDialog(o: any) {
    const dialogRef = this.dialog.open(DetailsComponent, {
      width: '7100px',
      disableClose: true,
      data: { model: o, title: 'Mesure' },
      direction: 'rtl',
    });

    return dialogRef.afterClosed();
  }

  async delete(o: Commission) {
    const r = await this.mydialog.openDialog('لجنة').toPromise();
    if (r === 'ok') {
      this.uow.commissions.delete(o.id).subscribe(() => this.update.next(true));
    }
  }
}
