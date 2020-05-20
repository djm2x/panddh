import { SessionService } from './../../../shared/session.service';
import { Notification, Mesure, Organisme } from './../../../Models/models';
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
  // eventToChild = new EventEmitter();
  // organismes = this.uow.organismes.get();
  myForm: FormGroup;
  axes = this.uow.axes.get();
  // mecanismes = this.uow.mecanismes;
  cycles = this.uow.cycles.get();
  sousAxes = [];
  users = this.uow.users.get();
  natures = this.uow.natures.get();
  // plants = ['2018-2021', '2022-2025'];
  // sousAxes = [];
  // syntheses = this.uow.syntheses.get();
  o = new Mesure();
  id = 0;
  // title = 'Nouveau utilisateur';
  // listOrganisme: Organisme[] = [];
  constructor(private route: ActivatedRoute, private router: Router,
    private uow: UowService, private fb: FormBuilder, private session: SessionService) { }

  ngOnInit() {

    this.createForm();
    this.id = +this.route.snapshot.paramMap.get('id');
    if (this.id !== 0) {
      this.uow.mesures.getOne(this.id).subscribe(r => {
        this.o = r as Mesure;
        // console.log(r);

        // this.eventToChild.emit(this.listOrganisme);
        // this.title = 'Modifier Utilisateur';
        this.uow.sousAxes.getByIdAxe(this.o.idAxe).subscribe(s => {
          // this.sousAxes = s as any[];
          this.createForm();
        });
      });
    }
  }

  createForm() {
    this.myForm = this.fb.group({
      id: this.o.id,
      code: [this.o.code, Validators.required],
      nom: [this.o.nom, Validators.required],
      idType: [this.o.idType, Validators.required],
      idResponsable: [this.o.idResponsable],
      idAxe: [this.o.idAxe, Validators.required],
      idSousAxe: [this.o.idSousAxe, Validators.required],
      idCycle: [this.o.idCycle,],
      idNature: [this.o.idNature,],
      resultatsAttendu: [this.o.resultatsAttendu, Validators.required],
      objectifGlobal: [this.o.objectifGlobal, Validators.required],
      objectifSpeciaux: [this.o.objectifSpeciaux, Validators.required],
    });
  }

  get idVisite() { return this.myForm.get('idVisite') as FormControl; }
  get idCycle() { return this.myForm.get('idCycle') as FormControl; }

  submit(o: Mesure) {

    // return;
    if (this.id === 0) {
      this.uow.mesures.post(o).subscribe((r: Mesure) => {
        this.o = r;
      });
    } else {
      this.uow.mesures.put(o.id, o).subscribe((r: Mesure) => {

      });
    }
  }

  selectChange(idAxe: number) {
    this.uow.sousAxes.getByIdAxe(idAxe).subscribe(r => {
      this.sousAxes = r as any[];
    });
  }

  reset() {
    this.o = new Mesure();
    this.createForm();
  }
}
