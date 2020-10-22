import { FormControl } from '@angular/forms';
import { Permission } from './../../Models/models';
import { DeleteService } from './../components/delete/delete.service';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { merge } from 'rxjs';
import { UowService } from 'src/app/services/uow.service';
import { ActivatedRoute } from '@angular/router';
import { SessionService } from 'src/app/shared';
import { Component, OnInit, ViewChild, EventEmitter } from '@angular/core';
import { UpdateComponent } from './update/update.component';

@Component({
  selector: 'app-permission',
  templateUrl: './permission.component.html',
  styleUrls: ['./permission.component.scss']
})
export class PermissionComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  // @ViewChild('myAutocomplete', { static: true }) myAutocomplete: MatInput;
  update = new EventEmitter();
  isLoadingResults = false;
  resultsLength = 0;
  isRateLimitReached = false;
  dataSource = [];
  columnDefs = [
    // { columnDef: 'profil', headName: 'الدور' },
    { columnDef: 'routeScreen', headName: 'صفحة ' },
    { columnDef: 'action', headName: 'الإجراء المسموح به' },
    // { columnDef: 'membre', headName: 'الأعضاء' },
    { columnDef: 'option', headName: '' },
  ].map(e => {
    e.headName = e.headName === '' ? e.columnDef.toUpperCase() : e.headName;
    return e;
  });
  //
  profils = [];
  idProfil = new FormControl(0);
  //
  displayedColumns = this.columnDefs.map(e => e.columnDef);
  //
  constructor(private uow: UowService, private mydialog: DeleteService
    , public dialog: MatDialog, public session: SessionService
    , private route: ActivatedRoute) { }

  ngOnInit() {
    this.uow.profils.get().subscribe((r: any[]) => {
      this.profils = r.filter(e => e.id !== 1);
      this.idProfil.setValue(this.profils[0].id);
      this.getPage(0, 10, 'id', 'desc', this.idProfil.value);
    });
    
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
          this.idProfil.value
        );
      }
    );

    

  }

  selectChange() {
    this.update.next(true);
  }

  getPage(startIndex, pageSize, sortBy, sortDir, id) {
    this.uow.permissions.getAll(startIndex, pageSize, sortBy, sortDir, id).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
      }
    );
  }

  add() {
    const p = new Permission();
    p.idProfil = this.idProfil.value;
    this.openDialog(p, 'إضافة الصلاحية').subscribe(result => {
      if (result) {
        this.uow.permissions.post(result).subscribe(
          r => {
            this.update.next(true);
          }
        );
      }
    });
  }

  edit(o: Permission) {
    this.openDialog(o, 'تغيير الصلاحية').subscribe((result: Permission) => {
      if (result) {
        this.uow.permissions.put(result.id, result).subscribe(
          r => {
            this.update.next(true);
          }
        );
      }
    });
  }

  async delete(o: Permission) {
    const r = await this.mydialog.openDialog('صلاحيات المستخدم').toPromise();
    if (r === 'ok') {
      this.uow.permissions.delete(o.id).subscribe(() => this.update.next(true));
    }
  }

  openDialog(o: Permission, text) {
    const dialogRef = this.dialog.open(UpdateComponent, {
      width: '7100px',
      disableClose: true,
      data: { model: o, title: text },
      direction: 'rtl',
    });

    return dialogRef.afterClosed();
  }
}
