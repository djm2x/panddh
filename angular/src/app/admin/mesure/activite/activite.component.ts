import { Component, OnInit, ViewChild, EventEmitter, Input } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { merge } from 'rxjs';
import { UowService } from 'src/app/services/uow.service';
import { Activite, Mesure } from 'src/app/Models/models';
import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { DeleteService } from '../../components/delete/delete.service';
import { UpdateComponent } from '../../user/update/update.component';

@Component({
  selector: 'app-activite',
  templateUrl: './activite.component.html',
  styleUrls: ['./activite.component.scss']
})
export class ActiviteComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @Input() mesure = new Mesure();
  update = new EventEmitter();

  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;

  myForm: FormGroup;
  o = new Activite();
  isEdit = false;

  dataSource = [];
  columnDefs = [
    { columnDef: 'nom', headName: 'النشاط' },
    { columnDef: 'duree', headName: 'السنة' },
    { columnDef: 'option', headName: 'OPTION' },
  ];

  // toppings = new FormControl();

  toppingList = [...Array(15).keys()].map(e => `${2016 + e}`);

  displayedColumns = this.columnDefs.map(e => e.columnDef);

  constructor(private uow: UowService, public dialog: MatDialog
    , private mydialog: DeleteService, private fb: FormBuilder) { }

  ngOnInit() {
    Object.assign(new Activite(), this.o).dureeToArray();
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
    this.uow.activites.getAll(startIndex, pageSize, sortBy, sortDir, this.mesure.id).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list.map(e => {
          e.duree = Object.assign(new Activite(), e).dureeToArray();
          return e;
        });
        this.resultsLength = r.count;
        this.isLoadingResults = false;
      }
    );
  }

  createForm() {
    // this.o.duree = this.o.dureeToString();
    this.myForm = this.fb.group({
      id: this.o.id,
      nom: [this.o.nom, Validators.required],
      duree: [this.o.duree],
      idMesure: [this.mesure.id],
    });
  }

  submit(o: Activite) {
    o.duree = Object.assign(new Activite(), o).dureeToString();
    // console.log(o);
    if (!this.isEdit) {
      this.uow.activites.post(o).subscribe(r => {
        this.reset();
        this.update.next(true);
      });
    } else {
      this.uow.activites.put(o.id, o).subscribe(r => {
        this.reset();
        this.update.next(true);
      });
    }
  }

  edit(o: Activite) {
    this.o = o;
    // Object.assign(new Activite(), this.o).dureeToArray()
    this.isEdit = true;
    this.createForm();
  }

  reset() {
    this.o = new Activite();
    // this.o = this.o.dureeToArray();
    this.isEdit = false;
    this.createForm();
  }

  async delete(id: number) {
    const r = await this.mydialog.openDialog('Mesure').toPromise();
    if (r === 'ok') {
      this.uow.activites.delete(id).subscribe(() => {
        this.update.next(true);
      });
    }
  }

}


