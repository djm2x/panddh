import { Organisme } from 'src/app/Models/models';
import { SessionService } from './../../../shared/session.service';
import { Notification, Commission } from './../../../Models/models';
import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { Validators, FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UowService } from 'src/app/services/uow.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit {

  myForm: FormGroup;
  o = new Commission();
  id = 0;


  constructor(private route: ActivatedRoute, private router: Router,
    private uow: UowService, private fb: FormBuilder, private session: SessionService) { }

  ngOnInit() {

    this.createForm();
    this.id = +this.route.snapshot.paramMap.get('id');
    if (this.id !== 0) {
      this.uow.commissions.getOne(this.id).subscribe(r => {
        this.o = r as Commission;

        this.createForm();
      });
    }
  }

  createForm() {
    this.myForm = this.fb.group({
      id: this.o.id,
      type: [this.o.type, Validators.required],
      pv: [this.o.pv, Validators.required],
      dateEvenement: [this.o.dateEvenement],
    });
  }

  submit(o: Commission) {
    // return;
    o.dateEvenement = this.valideDate(o.dateEvenement);
    if (this.id === 0) {
      this.uow.commissions.post(o).subscribe((r: Commission) => {
        this.o = r;
      });
    } else {
      this.uow.commissions.put(o.id, o).subscribe((r: Commission) => {

      });
    }
  }

  reset() {
    this.o = new Commission();
    this.createForm();
  }

  valideDate(date: Date): Date {
    date = new Date(date);

    const hoursDiff = date.getHours() - date.getTimezoneOffset() / 60;
    const minutesDiff = (date.getHours() - date.getTimezoneOffset()) % 60;
    date.setHours(hoursDiff);
    date.setMinutes(minutesDiff);

    return date;
  }
}

