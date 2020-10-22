import { Component, OnInit, OnDestroy } from '@angular/core';
import { Validators, FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/models';
import { UowService } from 'src/app/services/uow.service';
import { SessionService } from 'src/app/shared';
import { SnackbarService } from 'src/app/shared/snakebar.service';
import { ManagePermissionService } from 'src/app/shared/manage.permission.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  // animations: anime
})
export class LoginComponent implements OnInit, OnDestroy {
  // for test
  displayedColumns: string[] = ['email', 'password', 'profil'];
  dataSource = [
    // { email: 'mourabit@angular.io', password: '123', profil: 'مدير' },
    // { email: 'mehdi@angular.io', password: '123', profil: 'مشرف' },
    // { email: 'fakri@angular.io', password: '123', profil: 'المخاطب الرئيسي' },
    // { email: 'ahmed@angular.io', password: '123', profil: 'لجنة التتبع' },
    // { email: 'soufiane@angular.io', password: '123', profil: 'لجنة الوطنية' },
  ];

  // end test
  myForm: FormGroup;
  o = new User();
  hide = true;
  
  constructor(private fb: FormBuilder, private uow: UowService
    , private router: Router, public session: SessionService) { }

  async ngOnInit() {
    // test
    this.o.email = 'mourabit@angular.io';
    this.o.password = '123';
    this.createForm();

    this.uow.users.getForTest().subscribe(r => {
      console.log(r);
      this.dataSource = [];
      this.dataSource = r as User[];
    });

    // this.checkbox.valueChanges.subscribe(r => console.log(r));
    // * remeber me
    // const s = JSON.parse(localStorage.getItem('user'));
    // if (s) {
    //   const u = await this.uow.users.findOne({ where: {email: s.email}}).toPromise();
    //   if (u.password === s.password) {
    //     this.router.navigate(['/concern']);
    //   }
    // }
    // if (this.session.isSignedIn) {
    //   this.snackbar.openMySnackBar('login...');
    //   setTimeout(() => {
    //     this.snackbar.dismiss();
    //     this.router.navigate(['concern']);
    //   }, 1500);
    // }
  }

  createForm() {
    this.myForm = this.fb.group({
      email: [this.o.email, [Validators.required, Validators.email]],
      password: [this.o.password, [Validators.required]],
    });
  }

  get email() { return this.myForm.get('email'); }
  get password() { return this.myForm.get('password'); }

  get emailError() {
    return this.email.hasError('required') ? 'You must enter a value' :
      this.email.hasError('email') ? 'Not a valid email' : '';
  }

  get passwordError() {
    return this.password.hasError('required') ? 'You must enter a value' : '';
  }

  submit(myForm) {
    // console.log(myForm.value);
    const o = myForm.value;
    // this.snackbar.openMySnackBar('login...');
    console.log(o);
    this.uow.users.login(o).subscribe(async (r: any) => {
      this.session.doSignIn(r.user, r.token, r.idRole);

      const prs = await this.uow.permissions.getByProfil(this.session.idRole).toPromise();
      this.session.doSavePermission(prs);
      this.router.navigate(['/admin'])
      // setTimeout(() => this.router.navigate(['/admin']), 500);
      // this.getRoute();

    });
  }

  resetForm() {
    this.o = new User();
    this.createForm();
  }

  ngOnDestroy(): void {
    console.log('ngOnDestroy');
  }
}
