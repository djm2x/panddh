import { SessionService } from 'src/app/shared';
import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit, ViewChild, EventEmitter, ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  countMesure = this.uow.mesures.count();
  countActivite = this.uow.activites.count();
  constructor(private uow: UowService, public session: SessionService) { }

  ngOnInit() {
    console.log(this.session.permissions);
  }

  pandh() {
    window.location.href = 'https://www.didh.gov.ma/ar/publications/khtt-alml-alwtnyt-fy-mjal-aldymqratyt-whqwq-alansan-2018-2021/';
  }

}
