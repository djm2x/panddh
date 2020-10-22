import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatAutocompleteSelectedEvent } from '@angular/material';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { IndicateurMesureValue, Mesure } from 'src/app/Models/models';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit {
  myForm: FormGroup;
  o: IndicateurMesureValue;
  title = '';
  indicateurs = [];
  cycleFC = new FormControl(0);
  mesure = new Mesure();
  myAuto = new FormControl('');
  filteredOptions: Observable<any>;
  cycles = this.uow.cycles.get();
 
  constructor(public dialogRef: MatDialogRef<any>, @Inject(MAT_DIALOG_DATA) public data: any
  , private fb: FormBuilder, public uow: UowService) { }

  ngOnInit() {
    const o = this.data.model;
    this.o = o;
    this.createForm();
    console.log(o)
    if (o.id !== 0) {
      this.cycleFC.setValue(o.idCycle);
      // this.mesure = o.mesureO;
      this.myForm.get('idMesure').setValue(o.idMesure);
      this.myAuto.setValue(o.mesure);
  
      this.uow.indicateurMesures.getByForeignKey(o.idMesure).subscribe(r => {
        this.indicateurs = r as any;
        this.myForm.get('idIndicateur').setValue(o.idIndicateur);
      });
    }
    this.title = this.data.title;

   

    
    this.autoComplete();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onOkClick(o: IndicateurMesureValue): void {
    o.date = this.valideDate(o.date);
    this.dialogRef.close(o);
  }

  createForm() {
    this.myForm = this.fb.group({
      id: [this.o.id],
      idIndicateur: [this.o.idIndicateur, Validators.required],
      idMesure: [this.o.idMesure, Validators.required],
      value: [this.o.value, Validators.required],
      date: [this.o.date, Validators.required],
    });
  }

  resetForm() {
    this.o = new IndicateurMesureValue();
    this.createForm();
    
  }

  autoComplete() {
    this.filteredOptions = this.myAuto.valueChanges.pipe(
      // startWith(''),
      switchMap((value: string) => {
        // return value.length > 1 && this.cycleFC.value !== 0 ? this.uow.mesures.customAutocomplete(this.cycleFC.value, value) : [];
        return value.length > 1 && this.cycleFC.value !== 0 ? this.uow.mesures.getByForeignKey(this.cycleFC.value) : [];
      }),
      // map(r => r)
    );
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    this.mesure = event.option.value as Mesure;
    console.log(this.mesure);
    this.myAuto.setValue(this.mesure.nom);
    this.myForm.get('idMesure').setValue(this.mesure.id);


    this.uow.indicateurMesures.getByForeignKey(this.mesure.id).subscribe(r => {
      this.indicateurs = r as any;
    });

    // this.sendMesureToIndicateurComponent.next(this.mesure.id);

  }

  valideDate(date: Date): Date {
    date = new Date(date);
  
    const hoursDiff = date.getHours() - date.getTimezoneOffset() / 60;
    const minutesDiff = (date.getHours() - date.getTimezoneOffset()) % 60;
    date.setHours(hoursDiff);
    date.setMinutes(minutesDiff);
  
    return date;
  }

  selectChange(id, name) {
    // if (name === 'axe') {
    //   this.uow.sousAxes.getByIdAxe(id).subscribe(r => {
    //     this.sousAxes = r as any[];
    //   });
    // } else if (name === 'cycle') {
    //   this.uow.mesures.getByForeignKey(id).subscribe(r => {
    //     this.mesures = r as any[];
    //   });
    // } else if (name === 'mesure') {
    //   this.uow.users.getByForeignKey(id).subscribe(r => {
    //     this.users = r as any[];
    //   });
    // }
  }

}
