import { Component, OnInit, ViewChild, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { Observable, merge } from 'rxjs';
import { FormControl } from '@angular/forms';
import { UowService } from 'src/app/services/uow.service';
import { DeleteService } from '../../components/delete/delete.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  update = new EventEmitter();
  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;

  dataSource = [];
  columnDefs = [
    { columnDef: 'nom', headName: 'الاسم' },
    { columnDef: 'prenom', headName: 'الأسم الأول' },
    { columnDef: 'email', headName: 'البريد الإلكتروني' },
    { columnDef: 'organisme', headName: 'هيئة' },
    { columnDef: 'profil', headName: 'وظيفة' },
    { columnDef: 'actif', headName: 'الحالة' },
    { columnDef: 'option', headName: 'Option' },
  ];
  //
  panelOpenState = false;
  //
  displayedColumns = this.columnDefs.map(e => e.columnDef);
  organismes = this.uow.organismes.get();
  nom = new FormControl('');
  prenom = new FormControl('');
  organisme = new FormControl(0);

  constructor(
    private router: Router,
    private uow: UowService,
    public dialog: MatDialog,
    private mydialog: DeleteService,
  ) { }

  ngOnInit() {
    this.getPage(0, 10, 'id', 'desc', '*', '*', 0);
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
          this.nom.value ? this.nom.value : '*',
          this.prenom.value ? this.prenom.value : '*',
          this.organisme.value ? this.organisme.value : 0,
        );
      }
    );
  }

  getPage(startIndex, pageSize, sortBy, sortDir, nom, prenom, organisme) {
    this.uow.users.getAll(startIndex, pageSize, sortBy, sortDir, nom, prenom, organisme).subscribe(
      (r: any) => {
        console.log(r);
        this.dataSource = r.list;
        this.resultsLength = r.count;
        this.isLoadingResults = false;
      }
    );
  }

  // Evenement boutton modifier un utilisateur
  edit(o) {
    this.router.navigateByUrl('/admin/modify?id=' + o.id);
  }
  // Evenement boutton rechercher
  search() {
    this.update.next(true);
  }

  async delete(id) {
    const r = await this.mydialog.openDialog('Utilisateur').toPromise();
    if (r === 'ok') {
      this.uow.users.delete(id).subscribe(() => this.update.next(true));
    }
  }

}
