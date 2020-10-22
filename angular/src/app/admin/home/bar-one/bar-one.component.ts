import { IndicateurMesureValue, Indicateur } from './../../../Models/models';
import { UowService } from 'src/app/services/uow.service';
import { Component, OnInit } from '@angular/core';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label, Color } from 'ng2-charts';
import { FormControl } from '@angular/forms';
import * as moment from 'moment';

@Component({
  selector: 'app-bar-one',
  templateUrl: './bar-one.component.html',
  styleUrls: ['./bar-one.component.scss']
})
export class BarOneComponent implements OnInit {
  public barChartOptions: ChartOptions = {
    responsive: true,
    title: {
      text: 'قيم المؤشرات ',
      display: true,
    },
    scales: {
      yAxes: [{
        ticks: {
          beginAtZero: true,
          stepSize: 1,
          major: {
            enabled: true
          }
        }
      }]
    }
  };
  public barChartLabels: Label[] = [];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [];
  indicateurs: Indicateur[] = [];
  public barChartData: ChartDataSets[] = [
    { data: [0], label: ''},

  ];
  //
  mesures = [];
  cycles = this.uow.cycles.get();
  // visites = this.uow.visites.get();
  // organes = this.uow.organes.get();
  //
  selectInput = new FormControl(0);
  idVisite = new FormControl(0);
  idCycle = new FormControl(0);
  idOrgane = new FormControl(0);
  constructor(private uow: UowService) { }

  public barChartColors: Color[] = [
    { backgroundColor: 'rgba(151, 151, 151, 0.514)' },
    { backgroundColor: 'green' },
  ];

  ngOnInit() {
  }

  

  selectChange(id, name, id2 = 0) {
    if (name === 'axe') {
      this.uow.sousAxes.getByIdAxe(id).subscribe(r => {
        // this.sousAxes = r as any[];
      });
    } else if (name === 'cycle') {
      this.uow.mesures.getByForeignKey(id).subscribe(r => {
        this.mesures = r as any[];
      });
    } else if (name === 'mesure') {
      this.uow.indicateurMesureValues.getByForeignKey(id).subscribe((r: Indicateur[]) => {
        this.indicateurs = r;
      });
    } else if (name === 'indicateur') {
      this.uow.indicateurMesureValues.getForDiagramme(id, id2).subscribe((r: IndicateurMesureValue[]) => {
        // this.indicateurs = r;
        const fl = r.filter(e => !isNaN(Number(e.value)));
        this.barChartLabels = fl.map(e => {
          // console.log(moment(new Date(e.date)).format('DD/MM/YYYY')  )
          // `${e.date.getDate()}`
          return moment(new Date(e.date)).format('DD/MM/YYYY');
        });

        this.barChartData[0].data = fl.map(e => Number(e.value));

        console.log(this.barChartLabels, this.barChartData[0].data)
      });
    }
  }

  // search() {
  //   this.get(
  //     this.idCycle.value ? this.idCycle.value : 0,
  //     this.idOrgane.value ? this.idOrgane.value : 0,
  //     this.idVisite.value ? this.idVisite.value : 0);
  // }

  // get cycleActive() {
  //   return this.selectInput.value === 'Examen périodique universal';
  // }

  // get visiteActive() {
  //   return this.selectInput.value === 'Procédure spéciale';
  // }

  // get organeActive() {
  //   return this.selectInput.value === 'Organes de traités';
  // }

  selectMecanismeChange(e) {
    // this.idOrganisme = idOrganisme;
    // this.selectedList = [];
    this.idVisite.setValue(null);
    this.idCycle.setValue(null);
    this.idOrgane.setValue(null);
    // this.getPage(0, 10, 'id', 'desc', mecanisme);
  }

}
