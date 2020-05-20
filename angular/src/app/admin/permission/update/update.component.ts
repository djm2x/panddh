import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Permission, Action } from 'src/app/Models/models';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit {
  myForm: FormGroup;
  o: Permission;
  title = '';
  actions =  Object.keys(Action);
  profils = this.uow.profils.get();
  constructor(public dialogRef: MatDialogRef<any>, @Inject(MAT_DIALOG_DATA) public data: any
  , private fb: FormBuilder, public uow: UowService) { }

  ngOnInit() {
    this.o = this.data.model;
    this.title = this.data.title;
    this.createForm();
    console.log(this.actions)
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onOkClick(o: Permission): void {
    this.dialogRef.close(o);
  }

  createForm() {
    this.myForm = this.fb.group({
      id: this.o.id,
      idProfil: [this.o.idProfil, Validators.required],
      action: [this.o.action, Validators.required],
      routeScreen: [this.o.routeScreen, Validators.required],
      // routeScreenAr: [this.o.routeScreenAr, Validators.required],
    });
  }

  resetForm() {
    this.o = new Permission();
    this.createForm();
  }

  selectChange(e) {
    this.myForm.get('routeScreen').setValue(e.value.nameF);
    this.myForm.get('routeScreenAr').setValue(e.value.nameA);
  }

}
