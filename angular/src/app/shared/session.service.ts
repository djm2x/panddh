import { Injectable, PLATFORM_ID, Inject, EventEmitter } from '@angular/core';
import { User, Permission, Action } from '../Models/models';

const USER = 'USER';
const PERMISSION = 'PERMISSION';
const TOKEN = 'TOKEN';
const ROLE = 'ROLE';

const ID_ADMIN = 1;
const ID_SUPER_VISUER = 2;
const ID_POINT_FOCAL = 3;
const PROPREITAIRE = 4;
@Injectable({
  providedIn: 'root'
})
export class SessionService {
  public user = new User();
  public token = '';
  public idRole = -1;
  permissions: Permission[] = [];
  public notif: EventEmitter<{ is: boolean, user: User, idRole?: number }> = new EventEmitter();
  constructor() {
    this.getSession();
  }
  // se connecter
  public doSignIn(user: User, token, idRole) {
    if (!user || !token || !idRole) {
      return;
    }
    this.user = user;
    this.token = token;
    this.idRole = idRole;
    localStorage.setItem(USER, (JSON.stringify(this.user)));
    localStorage.setItem(TOKEN, (JSON.stringify(this.token)));
    localStorage.setItem(ROLE, (JSON.stringify(this.idRole)));
    this.notif.next({ is: true, user: this.user });
  }

  public doSavePermission(permissions: Permission[] = []) {
    this.permissions = permissions;
    localStorage.setItem(PERMISSION, (JSON.stringify(this.permissions)));
  }

  public updateUser(user: User) {
    if (!user) {
      return;
    }
    this.user = user;
    localStorage.setItem(USER, (JSON.stringify(this.user)));
    this.notif.next({ is: true, user: this.user });
  }

  // se deconnecter
  public doSignOut(): void {
    this.user = new User();
    localStorage.removeItem(USER);
    localStorage.removeItem(TOKEN);
    localStorage.removeItem(ROLE);
    this.notif.next({ is: false, user: this.user });
  }

  //
  checkPermission(route = '', i = 0): boolean {
    if (this.user.idProfil === 1) {
      return true;
    }

    if (route === 'suivi') {
      // console.log(route, i)
    }

    // i === 0 => Consultation
    // i === 1 => Modification
    const action = i !== 1 ? Action.Consultation : Action.Modification;
    const obj = this.permissions.find(e => (i === 0 || e.action === action) && route.includes(e.routeScreen));
    // if (route.includes('suivi')) {
    //   console.log(obj, route)
    // }
    return obj !== undefined;
  }

  // this methode is for our auth guard
  get isSignedIn(): boolean {
    console.log(!!localStorage.getItem(USER) ||
      !!localStorage.getItem(TOKEN) ||
      !!localStorage.getItem(ROLE));
    return !!localStorage.getItem(USER) ||
      !!localStorage.getItem(TOKEN) ||
      !!localStorage.getItem(ROLE)
      ;
  }

  public getSession(): void {
    try {
      this.user = JSON.parse(localStorage.getItem(USER));
      this.token = JSON.parse(localStorage.getItem(TOKEN));
      this.idRole = JSON.parse(localStorage.getItem(ROLE));
      this.permissions = JSON.parse(localStorage.getItem(PERMISSION));
      // this.user = JSON.parse(atob(localStorage.getItem(USER)));
      // this.token = JSON.parse(atob(localStorage.getItem(TOKEN)));
      // this.idRole = JSON.parse(atob(localStorage.getItem(ROLE)));
      this.notif.next({ is: true, user: this.user });
    } catch (error) {
      this.user = new User();
      this.token = '';
      this.idRole = -1;
      this.permissions = [];
      console.warn('error localstorage data', error);
    }

    // console.log('token here : ', this.token);
    // console.log('idRole here : ', this.idRole);
  }



  get getUser() {
    return this.user;
  }

  get isAdmin() {
    return this.user.idProfil === ID_ADMIN;
  }

  get isSuperViseur() {
    return this.user.idProfil === ID_SUPER_VISUER;
  }

  get isPointFocal() {
    return this.user.idProfil === ID_POINT_FOCAL;
  }

  get isProprietaire() {
    return this.user.idProfil === PROPREITAIRE;
  }
}


// class User {
//   id: 0;
//   name = '';
// }

