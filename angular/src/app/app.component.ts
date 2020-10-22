import { UowService } from 'src/app/services/uow.service';

import { Router, NavigationStart, RouterOutlet } from '@angular/router';
import { Component, ViewChild, ChangeDetectorRef, OnInit } from '@angular/core';
import { MatButton } from '@angular/material';
import { SessionService } from './shared';
import { MediaMatcher } from '@angular/cdk/layout';
import { routerTransition } from './shared/animations';
import { ManagePermissionService } from './shared/manage.permission.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [routerTransition],
})
export class AppComponent implements OnInit {
  @ViewChild('btndev', { static: true }) btndev: MatButton;
  keyDevTools = '';
  panelOpenState = false;
  mobileQuery: MediaQueryList;
  currentSection = 'section1';
  userImg = '../../assets/caisse.jpg';
  opened = true;
  idRole = -1;
  isConnected = false;
  // montantCaisse = this.s.notify;
  route = this.router.url;

  constructor(private session: SessionService, public router: Router
    ,  private permission: ManagePermissionService, private uow: UowService) { }

  async ngOnInit() {

    this.permission.permissions = await this.uow.permissions.get().toPromise();
    // this.getRoute();

  }

  get patchRoute() { return this.route.split('/'); }

  getRoute() {
    this.router.events.subscribe(route => {
      if (route instanceof NavigationStart) {
        this.route = route.url;
        console.log(this.route);
      }
    });
  }



  disconnect() {
    this.session.doSignOut();
    this.router.navigate(['/auth']);
  }

  getState(outlet: RouterOutlet) {
    return outlet.activatedRouteData.state;
  }
}
