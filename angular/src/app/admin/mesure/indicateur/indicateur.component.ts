import { IndicateurMesure } from './../../../Models/models';
import { Component, OnInit, ViewChild, EventEmitter, Input } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { merge } from 'rxjs';
import { UowService } from 'src/app/services/uow.service';
import { SousAxe, Indicateur, Partenariat, Mesure } from 'src/app/Models/models';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { DeleteService } from '../../components/delete/delete.service';
import { UpdateComponent } from '../../user/update/update.component';

@Component({
  selector: 'app-indicateur',
  templateUrl: './indicateur.component.html',
  styleUrls: ['./indicateur.component.scss']
})
export class IndicateurComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  // @Output() eventToParent = new EventEmitter<any[]>();

  selectedList: Indicateur[] = [];
  todeleteList: IndicateurMesure[] = [];
  useFullList: IndicateurMesure[] = [];
  // listFromParent: Partenariat[] = [];

  isEdit = false;

  update = new EventEmitter();
  isLoadingResults = false;
  resultsLength = 0;
  isRateLimitReached = false;

  @Input() mesure = new Mesure();
  // mecanisme = '';
  // selectInput = new FormControl(0);
  dataSource = [];

  columnDefs = [
    { columnDef: 'select', headName: '' },
    { columnDef: 'nom', headName: 'المؤشر' },
    { columnDef: 'source', headName: 'مصدر تحقق' },
    { columnDef: 'option', headName: 'OPTION' },
  ];

  displayedColumns = this.columnDefs.map(e => e.columnDef);

  constructor(private uow: UowService, public dialog: MatDialog
    , private mydialog: DeleteService, private fb: FormBuilder) { }

  ngOnInit() {
    this.uow.indicateurs.getByForeignKey(this.mesure.id).subscribe(r => {
      this.selectedList = r as any[];
      // console.log(this.selectedList)
      this.selectedList.forEach(row => {
        this.todeleteList.push({ idIndicateur: row.id, idMesure: this.mesure.id } as any);
        // this.selection.select(row);
      });
    });

    if (this.mesure.id !== 0) {
      this.isEdit = true;
    }

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

  // createForm() {
  //   this.myForm = this.fb.group({
  //     id: this.o.id,
  //     label: [this.o.label, Validators.required],
  //     source: ['غير معروف', Validators.required],
  //     // idAxe: [this.o.idAxe, Validators.required],
  //   });
  // }

  getPage(startIndex, pageSize, sortBy, sortDir) {
    this.uow.indicateurs.getList(startIndex, pageSize, sortBy, sortDir).subscribe(
      (r: any) => {
        console.log(r.list);
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
      }
    );
  }

  submit() {
    this.useFullList = [];
    this.selectedList.map(r => {
      this.useFullList.push({ idIndicateur: r.id, idMesure: this.mesure.id } as any);
    });
    // console.log('listRecommendation', this.selectedList, 'this.o.recommendations', this.o.recommendations)
    // console.log(this.todeleteList, this.useFullList);
    this.uow.indicateurMesures.putRange(this.todeleteList, this.useFullList).subscribe(e => {
      // this.navTab.navigateTo.next(2);
      this.todeleteList = this.useFullList;
    });
  }

  openDialog(o: SousAxe, text) {
    const dialogRef = this.dialog.open(UpdateComponent, {
      width: '750px',
      disableClose: true,
      data: { model: o, title: text }
    });

    return dialogRef.afterClosed();
  }

  add() {
    this.openDialog(new SousAxe(), 'إضافة مؤشر').subscribe(result => {
      if (result) {
        // this.uow.sousAxes.post(result).subscribe(
        //   r => {
        //     this.update.next(true);
        //   }
        // );
      }
    });
  }

  edit(o: SousAxe) {
    this.openDialog(o, 'تغيير مؤشر ').subscribe((result: SousAxe) => {
      if (result) {
        // this.uow.sousAxes.put(result.id, result).subscribe(
        //   r => {
        //     this.update.next(true);
        //   }
        // );
      }
    });
  }

  async delete(id: number) {
    const r = await this.mydialog.openDialog('sous-axe').toPromise();
    if (r === 'ok') {
      // this.uow.sousAxes.delete(id).subscribe(() => this.update.next(true));
    }
  }

  isSelected(row): boolean {
    // console.log(this.selectedList)
    // this.selectedList.forEach(e => console.log(+e.id, +row.id))
    // console.log(this.selectedList.find(e => +e.id === +row.id) ? true : false);
    return this.selectedList.find(e => e.id === row.id) ? true : false;
  }

  check(r) {
    const i = this.selectedList.findIndex(o => r.id === o.id);
    const existe: boolean = i !== -1;
    if (!existe) {
      this.selectedList.push(r);
    } else {
      this.selectedList.splice(i, 1);
    }
    // console.log(this.todeleteList);
    // this.eventToParent.next(this.selectedList);
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selectedList.length;
    const numRows = this.paginator.pageSize;
    // console.log(numSelected, numRows)
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    if (this.isAllSelected()) {
      this.selectedList = [];
    } else {
      this.selectedList = [];
      this.dataSource.forEach(row => this.selectedList.push(row));
    }
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: Indicateur): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    // return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id}`;
    return `${this.selectedList.find(e => e.id === row.id) ? 'deselect' : 'select'} row ${row.id}`;
  }

}


