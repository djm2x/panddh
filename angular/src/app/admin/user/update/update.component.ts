import { Component, OnInit, ViewEncapsulation, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { first } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { timeout } from 'q';
import { NgForm, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/Models/models';
import { UowService } from 'src/app/services/uow.service';


@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit {
  // loading = false;
  // submitted = false;
  // returnUrl: string;
  // error: string;
  profils = this.uow.profils.get();
  organismes = this.uow.organismes.get();
  public myForm: FormGroup;
  hide = true;
  hide2 = true;
  o = new User();
  id = 0;
  title = 'Nouveau utilisateur';
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private uow: UowService,
    private fb: FormBuilder,
  ) { }

  ngOnInit() {
    this.createForm();
    this.id = +this.route.snapshot.paramMap.get('id');
    if (this.id !== 0) {
      this.uow.users.getOne(this.id).subscribe(r => {
        this.o = r as User;
        console.log(this.o);
        this.title = 'Modifier Utilisateur';
        this.createForm();
      });
    }
  }

  createForm() {
    this.myForm = this.fb.group({
      id: this.o.id,
      nom: [this.o.nom, Validators.required],
      prenom: [this.o.prenom, Validators.required],
      email: [this.o.email, [Validators.email, Validators.required]],
      password: [this.o.password, Validators.required],
      password2: [this.o.password, Validators.required],
      adresse: [this.o.adresse, Validators.required],
      tel: [this.o.tel, Validators.required],
      fix: [this.o.fix, Validators.required],
      username: [this.o.username, Validators.required],
      actif: [this.o.actif, Validators.required],
      idOrganisme: [this.o.idOrganisme, Validators.required],
      idProfil: [this.o.idProfil, Validators.required],
    });
  }
  submit(f: FormGroup) {
    const user = f.value;
    // user.actif = Number(user.actif);

    if (user.password === user.password2) {
      delete (user as any).password2;

      if (this.id === 0) {
        this.uow.users.post(user).subscribe(r => {
          this.router.navigateByUrl('/admin/user');
        });
      } else {
        console.log(user);
        this.uow.users.put(user.id, user).subscribe(r => {
          this.router.navigateByUrl('/admin/user');
        });
      }
    }
  }
}
