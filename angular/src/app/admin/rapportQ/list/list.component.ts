import { Realisation, Indicateur } from './../../../Models/models';
import { Mesure } from '../../../Models/models';
import { Component, OnInit, ViewChild, EventEmitter, ElementRef } from '@angular/core';
import { MatPaginator, MatSort, MatDialog, MatAutocompleteSelectedEvent, MatInput } from '@angular/material';
import { merge, Observable } from 'rxjs';
import { UowService } from 'src/app/services/uow.service';
import { SnackbarService } from 'src/app/shared/snakebar.service';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router, NavigationStart } from '@angular/router';
import { SessionService } from 'src/app/shared';
import { switchMap, map } from 'rxjs/operators';
import { DeleteService } from '../../components/delete/delete.service';
import { ExcelService } from 'src/app/shared/excel.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild('epltable', { static: true }) epltable: ElementRef;

  update = new EventEmitter();
  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;
  dataSource = [];

  columnDefs = [
    // { columnDef: 'pieceJointe', headName: '.' },
    { columnDef: 'organisme', headName: 'القطاع' },
    { columnDef: 'mesure', headName: 'التدبير' },
    { columnDef: 'realisations', headName: 'الإنجاز' },
    { columnDef: 'taux', headName: 'معدل الإنجاز' },
    { columnDef: 'indicateurs', headName: '(قيمة) المؤشر' },
    // { columnDef: 'option', headName: '...' },

  ].map(e => {
    e.headName = e.headName === '' ? e.columnDef.toUpperCase() : e.headName;
    return e;
  });
  //
  panelOpenState = false;
  //
  organismes = [];
  typeMesures = [
    { id: 1, value: 'المخطط التنفيدي' },
    { id: 2, value: 'المخطط التنفيدي الترابي' },
    { id: 3, value: 'برامج العمل' }
  ];
  mesures = [];
  axes = this.uow.axes.get();
  sousAxes = [];
  cycles = this.uow.cycles.get();
  users = [];

  myForm: FormGroup;
  //
  displayedColumns = this.columnDefs.map(e => e.columnDef);

  o = new Model();
  myAuto = new FormControl('');
  filteredOptions: Observable<any>;
  //
  isMesureRegion = false;
  isMesure = false;
  isProgramme = false;
  typeOrganisme = 1;
  //
  routeMesure = '';
  //

  title = '';

  
  
  constructor(private uow: UowService, private mydialog: DeleteService
    , private snack: SnackbarService, private fb: FormBuilder
    , public session: SessionService, public dialog: MatDialog
    , private excel: ExcelService, public router: Router) { }

  ngOnInit() {
    // this.searchAndGet(this.o);
    this.isLoadingResults = false;
    // console.warn('>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>')
    this.createForm();


    merge(...[this.sort.sortChange, this.paginator.page, this.update]).subscribe(
      r => {
        r === true ? this.paginator.pageIndex = 0 : r = r;
        !this.paginator.pageSize ? this.paginator.pageSize = 10 : r = r;
        // this.o = new Model();
        this.o.startIndex = this.paginator.pageIndex * this.paginator.pageSize;
        this.o.pageSize = this.paginator.pageSize;
        this.o.sortBy = this.sort.active ? this.sort.active : 'id';
        this.o.sortDir = this.sort.direction ? this.sort.direction : 'desc';
        this.isLoadingResults = true;
        this.searchAndGet(this.o);
      }
    );
  }

  exportExcel() {
    this.excel.test(this.epltable);
  }

  createForm() {
    this.myForm = this.fb.group({
      idCycle: this.o.idCycle,
      idMesure: this.o.idMesure,
      idResponsable: this.o.idResponsable,
      idOrganisme: this.o.idOrganisme,
      typeOrganisme: this.o.typeOrganisme,
      idAxe: this.o.idAxe,
      idSousAxe: this.o.idCycle,
      startIndex: this.o.startIndex,
      pageSize: this.o.pageSize,
      sortBy: this.o.sortBy,
      sortDir: this.o.sortDir,
    });
  }


  selectChange(id, name) {
    if (name === 'axe') {
      this.uow.sousAxes.getByIdAxe(id).subscribe(r => {
        this.sousAxes = r as any[];
      });
    } else if (name === 'cycle') {
      this.uow.mesures.getByForeignKey(id).subscribe(r => {
        this.mesures = r as any[];
      });
    } else if (name === 'mesure') {
      this.uow.users.getByForeignKey(id).subscribe(r => {
        this.users = r as any[];
      });
    }
  }

  reset() {
    this.o = new Model();
    this.createForm();
    // this.searchAndGet(this.o);
  }

  search(o: Model) {
    // this.searchAndGet(o);
    this.o = o;
    // console.log(this.o)
    this.update.next(true);
  }

  searchAndGet(o: Model) {
    console.log(o);
    this.o = o;
    // this.o.idOrganisme = this.session.isPointFocal || this.session.isProprietaire ? this.session.user.idOrganisme : this.o.idOrganisme;
    this.uow.realisations.getRapportQualitative(this.o).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
      }, e => this.isLoadingResults = false,
    );
  }

  async delete(o: Mesure) {
    const r = await this.mydialog.openDialog('تتبع').toPromise();
    if (r === 'ok') {
      this.uow.realisations.delete(o.id).subscribe(() => this.update.next(true));
    }
  }

  axeChange(idAxe: number) {
    this.uow.sousAxes.getByIdAxe(idAxe).subscribe(r => {
      this.sousAxes = r as any[];
    });
  }

  get isAllEmpty(): boolean {
    if (this.myForm.get('idAxe').value.toString() === '0' &&
      this.myForm.get('idCycle').value.toString() === '0' &&
      this.myForm.get('idSousAxe').value.toString() === '0' &&
      this.myForm.get('idMesure').value.toString() === '0' &&
      this.myForm.get('idOrganisme').value.toString() === '0' &&
      this.myForm.get('idResponsable').value.toString() === '0') {
      return true;
    }
    return false;
  }

}

class Model {
  idCycle = 0;
  idMesure = 0;
  idResponsable = 0;
  idAxe = 0;
  idSousAxe = 0;
  idOrganisme = 0;
  typeOrganisme = 1;
  // mecanisme = '';
  startIndex = 0;
  pageSize = 2;
  sortBy = 'id';
  sortDir = 'desc';
}
