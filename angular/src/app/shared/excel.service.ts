import { Injectable, ViewChild, ElementRef } from '@angular/core';
import * as XLSX from 'xlsx';
import * as FileSaver from 'file-saver';
import { WorkSheet, WorkBook, utils, writeFile } from 'xlsx';

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';
@Injectable({
  providedIn: 'root'
})
export class ExcelService {

  title = 'Excel';
  constructor() { }

  test(epltable: ElementRef ) {
    const ws: WorkSheet = utils.table_to_sheet(epltable.nativeElement);
    // const wb: WorkBook = utils.book_new();
    console.log(epltable)
    // ws["!cols"] = this.fitToColumn(epltable.nativeElement);
    const wb: WorkBook = { Sheets: { data: ws }, SheetNames: ['data'], Workbook: { Views: [{ RTL: true }] } };
    // wb.Workbook.Views = [{ RTL: true }];
    utils.book_append_sheet(wb, ws, 'Sheet1');

    
    writeFile(wb, 'epltable.xlsx');
  }

  public exportAsExcelFile(json: any[], excelFileName: string): void {
    // const worksheet2: XLSX.WorkSheet = XLSX.utils.;
    const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(json);

    // worksheet['!cols'] = this.fitToColumn(json);

    worksheet["!cols"] = this.fitToColumn(json);

    const workbook: XLSX.WorkBook = { Sheets: { data: worksheet }, SheetNames: ['data'] };
    const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
    // return
    this.saveAsExcelFile(excelBuffer, excelFileName);
  }

  fitToColumn(arrayOfArray) {
    // get maximum character of each column
    const header = Object.keys(arrayOfArray[0]); // columns name


    const wscols = [];
    for (let i = 0; i < header.length; i++) {  // columns length added
      wscols.push({ wch: header[i].length + 55 })
    }
    // console.log(arrayOfArray);
    // const columnCount = Object.keys(arrayOfArray[0]).length;
    let some = [];
    let maxes;
    const l = arrayOfArray.map((e, rowIndex) => {

      // const lengthOfWord = (e.map(a2 => {
      //   const length = a2.toString().length;
      //   return length;
      // }));
      // const col = Object.values(e)[columnCount]

      const values = Object.values(e).map(o => o.toString().length); // columns name

      // values.forEach((f, i) => {

      // })

      // some.push(values);
      return { wch: Math.max(...values as any[]) };
    });

    console.log(l);
    console.log(wscols);

    return l;
  }

  private saveAsExcelFile(buffer: any, fileName: string): void {
    const data: Blob = new Blob([buffer], { type: EXCEL_TYPE });
    FileSaver.saveAs(data, fileName + '_export_' + new Date().getTime() + EXCEL_EXTENSION);
  }


  ExportTOExcel(data2 = [], filename = 'SheetJS') {

    const data = [
      [{
        Name: 'def',
        RollNo: 102,
        Age: 15
      },
      {
        Name: 'xyz',
        RollNo: 103,
        Age: 20
      }],
      [{
        Name: 'def',
        RollNo: 102,
        Age: 15
      },
      {
        Name: 'xyz',
        RollNo: 103,
        Age: 20
      }],
    ]
    const ws: XLSX.WorkSheet = XLSX.utils.aoa_to_sheet(data);

    /* generate workbook and add the worksheet */
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');

    /* save to file */
    XLSX.writeFile(wb, `${filename}.xlsx`);
  }

  ExportTOExcel2(table: ElementRef) {
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(table.nativeElement);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, 'ScoreSheet.xlsx');
  }



}
