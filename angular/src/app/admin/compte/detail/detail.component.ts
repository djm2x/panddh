import { User } from './../../../Models/models';
import { SessionService } from './../../../shared/session.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UowService } from 'src/app/services/uow.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {

  profils = this.uow.profils.get();
  organismes = this.uow.organismes.get();
  myForm: FormGroup;
  hide = true;
  hide2 = true;
  // o = this.session.user as User;
  o = new User();
  hasAccess: boolean = this.o.idProfil === 1 || 2 ? true : false;
  // id = 0;
  // title = 'Nouveau utilisateur';

  ogranisme = '';
  profil = '';

  constructor(private route: ActivatedRoute, private router: Router,
    private uow: UowService, private fb: FormBuilder, private session: SessionService, ) { }

  ngOnInit() {
    this.createForm();
    // this.id = +this.route.snapshot.paramMap.get('id');
    // if (this.id !== 0) {
    this.uow.users.getOneInclude(this.session.user.id).subscribe(r => {
      this.o = r as User;
      console.log(this.o);
      this.createForm();
      this.ogranisme = this.o.organisme.label;
      this.profil = this.o.profil.label;
      // this.title = 'Modifier Utilisateur';
    });
    // }
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
      idOrganisme: [{ value: this.o.idOrganisme, disabled: !this.hasAccess }, Validators.required],
      idProfil: [{ value: this.o.idProfil, disabled: !this.hasAccess }, Validators.required],
    });
  }
  submit(f: FormGroup) {
    const user = f.value;
    // user.actif = Number(user.actif);
    delete (user as any).password2;
    console.log(user);
    if (user.Password === user.Password2) {
      console.log(user)
      this.uow.users.put(user.id, user).subscribe(r => {
        this.session.updateUser(user);
        // this.router.navigateByUrl('/admin/utilisateurs');
      });
    }
  }
}

