import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Organisme } from 'src/app/Models/models';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit {
  myForm: FormGroup;
  o: Organisme;
  title = '';
  constructor(public dialogRef: MatDialogRef<any>, @Inject(MAT_DIALOG_DATA) public data: any
  , private fb: FormBuilder, public uow: UowService) { }

  ngOnInit() {
    this.o = this.data.model;
    this.title = this.data.title;
    this.createForm();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onOkClick(o: Organisme): void {
    this.dialogRef.close(o);
  }

  createForm() {
    this.myForm = this.fb.group({
      id: this.o.id,
      type: [this.o.type, Validators.required],
      label: [this.o.label, Validators.required],
      adresse: [this.o.adresse, Validators.required],
      tel: [this.o.tel, Validators.required],
    });
  }

  resetForm() {
    this.o = new Organisme();
    this.createForm();
  }

}
