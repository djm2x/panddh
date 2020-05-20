import { Component, OnInit, ViewChild, EventEmitter } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { merge } from 'rxjs';
import { UpdateComponent } from './update/update.component';
import { DeleteService } from '../components/delete/delete.service';
import { UowService } from 'src/app/services/uow.service';
import { Organisme } from 'src/app/Models/models';

@Component({
  selector: 'app-objectif',
  templateUrl: './objectif.component.html',
  styleUrls: ['./objectif.component.scss']
})
export class ObjectifComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  update = new EventEmitter();
  isLoadingResults = true;
  resultsLength = 0;
  isRateLimitReached = false;

  dataSource = [];
  columnDefs = [
    { columnDef: 'but', headName: 'هدف عام' },
    { columnDef: 'but2', headName: 'أهداف خاصة' },
    { columnDef: 'option', headName: 'OPTION' },
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
    // this.uow.organismes.getList(startIndex, pageSize, sortBy, sortDir).subscribe(
    //   (r: any) => {
    //     console.log(r.list);
    //     this.dataSource = r.list;
    //     this.resultsLength = r.count;
    //     this.isLoadingResults = false;
    //   }
    // );

    this.dataSource = [
      {
        but: ' النهوض بمشاركة المواطنات والمواطنين في تدبير الشأن العام على المستوى الوطني والجهوي والمحلي.',
        but2: `
        - تعزيز المشاركة ف العمل السياسي.
        - تقوية أداء المؤسسات المنتخبة.
        - تشجيع مشاركة النساء والشباب ف الحياة العامة.
        - احترام حقوق الإنسان وإشاعة قيم الديقراطية وإعمال المحاسبة والشفافية
        `
      },
      {
        but: `النهوض بالمساواة وتكافؤ الفرص والسعي إلى تحقيق المناصفة`,
        but2: `
        مواصلة مأسسة المناصفة وتفعيلها.
        - ضمان تكافؤ الفرص بين الجنسين فيما يخص فرص الولوج إلى العمل ومحاربة جميع أشكال التمييز.
        - تحسين نسبة ولوج الخدمات والتمتع بالحقوق السياسية والإقتصادية والإجتماعية والثقافية واللغوية.
        - ترشيد الآليات التضامنية الكفيلة بمعالجة الإختلالات المجالية ذات الصلة بتكافؤ الفرص والإستفادة من الثروات الطبيعية.
        `,
      }
    ];
    this.resultsLength = this.dataSource.length;
    this.isLoadingResults = false;
  }

  openDialog(o: Organisme, text) {
    const dialogRef = this.dialog.open(UpdateComponent, {
      width: '750px',
      disableClose: true,
      data: { model: o, title: text }
    });

    return dialogRef.afterClosed();
  }

  add() {
    this.openDialog(new Organisme(), 'إضافة هدف ').subscribe(result => {
      if (result) {
        // this.uow.organismes.post(result).subscribe(
        //   r => {
        //     this.update.next(true);
        //   }
        // );
      }
    });
  }

  edit(o: Organisme) {
    this.openDialog(o, ' تغير هدف ').subscribe((result: Organisme) => {
      if (result) {
        // this.uow.organismes.put(result.id, result).subscribe(
        //   r => {
        //     this.update.next(true);
        //   }
        // );
      }
    });
  }

  async delete(id: number) {
    const r = await this.mydialog.openDialog('organisme').toPromise();
    if (r === 'ok') {
      // this.uow.organismes.delete(id).subscribe(() => this.update.next(true));
    }
  }

}

