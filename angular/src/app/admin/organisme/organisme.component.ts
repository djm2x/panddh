import { Component, OnInit, ViewChild, EventEmitter } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { merge } from 'rxjs';
import { UpdateComponent } from './update/update.component';
import { DeleteService } from '../components/delete/delete.service';
import { UowService } from 'src/app/services/uow.service';
import { Organisme } from 'src/app/Models/models';

@Component({
  selector: 'app-organisme',
  templateUrl: './organisme.component.html',
  styleUrls: ['./organisme.component.scss']
})
export class OrganismeComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  update = new EventEmitter();
  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;

  dataSource = [];
  columnDefs = [
    { columnDef: 'type', headName: 'نوع' },
    { columnDef: 'label', headName: 'إسم' },
    { columnDef: 'adresse', headName: 'عنوان' },
    { columnDef: 'tel', headName: 'هاتف' },
    { columnDef: 'option', headName: 'OPTION' },
  ];

  displayedColumns = this.columnDefs.map(e => e.columnDef);

  constructor(private uow: UowService, public dialog: MatDialog, private mydialog: DeleteService,) { }

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
    this.uow.organismes.getList(startIndex, pageSize, sortBy, sortDir).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
      }
    );
  }

  getTypeName(id) {
    return this.uow.typeOrganismes.find(e => e.id === id).name;
  }

  openDialog(o: Organisme, text) {
    const dialogRef = this.dialog.open(UpdateComponent, {
      width: '750px',
      disableClose: true,
      data: { model: o, title: text },
      direction: 'rtl',
    });

    return dialogRef.afterClosed();
  }

  add() {
    this.openDialog(new Organisme(), 'إضافة منظمة').subscribe(result => {
      if (result) {
        this.uow.organismes.post(result).subscribe(
          r => {
            this.update.next(true);
          }
        );
      }
    });
  }

  edit(o: Organisme) {
    this.openDialog(o, 'تغير منظمة').subscribe((result: Organisme) => {
      if (result) {
        this.uow.organismes.put(result.id, result).subscribe(
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
      this.uow.organismes.delete(id).subscribe(() => this.update.next(true));
    }
  }

}
