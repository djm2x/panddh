import { Component, OnInit, ViewChild, EventEmitter, Input } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { merge } from 'rxjs';
import { UowService } from 'src/app/services/uow.service';
import { MembreCommission, Mesure } from 'src/app/Models/models';
import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { DeleteService } from 'src/app/admin/components/delete/delete.service';

@Component({
  selector: 'app-membre',
  templateUrl: './membre.component.html',
  styleUrls: ['./membre.component.scss']
})
export class MembreCommissionComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @Input() commission = new Mesure();
  update = new EventEmitter();

  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;

  myForm: FormGroup;
  o = new MembreCommission();
  isEdit = false;

  dataSource = [];
  columnDefs = [
    { columnDef: 'nomComplete', headName: 'الإسم الكامل' },
    { columnDef: 'email', headName: 'البريد الإلكتروني' },
    { columnDef: 'option', headName: 'OPTION' },
  ];

  displayedColumns = this.columnDefs.map(e => e.columnDef);

  constructor(private uow: UowService, public dialog: MatDialog
    , private mydialog: DeleteService, private fb: FormBuilder) { }

  ngOnInit() {
    this.createForm();
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
    this.uow.membreCommissions.getAll(startIndex, pageSize, sortBy, sortDir, this.commission.id).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
      }
    );
  }

  createForm() {
    // this.o.duree = this.o.dureeToString();
    this.myForm = this.fb.group({
      id: this.o.id,
      nomComplete: [this.o.nomComplete, Validators.required],
      email: [this.o.email, [Validators.required, Validators.email]],
      idCommission: [this.commission.id],
    });
  }

  submit(o: MembreCommission) {
    // console.log(o);
    if (!this.isEdit) {
      this.uow.membreCommissions.post(o).subscribe(r => {
        this.reset();
        this.update.next(true);
      });
    } else {
      this.uow.membreCommissions.put(o.id, o).subscribe(r => {
        this.reset();
        this.update.next(true);
      });
    }
  }

  edit(o: MembreCommission) {
    this.o = o;
    // Object.assign(new MembreCommission(), this.o).dureeToArray()
    this.isEdit = true;
    this.createForm();
  }

  reset() {
    this.o = new MembreCommission();
    // this.o = this.o.dureeToArray();
    this.isEdit = false;
    this.createForm();
  }

  async delete(id: number) {
    const r = await this.mydialog.openDialog('Mesure').toPromise();
    if (r === 'ok') {
      this.uow.membreCommissions.delete(id).subscribe(() => {
        this.update.next(true);
      });
    }
  }

}


