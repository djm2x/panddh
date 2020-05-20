import { IndicateurMesureValueService } from './indicateur-mesure-values.service';
import { CommissionService } from './commission.service';
import { NotificationService } from './notification.service';
import { CycleService } from './cycle.service';
import { IndicateurService } from './indicateur.service';
import { ProfilService } from './profil.service';
import { OrganismeService } from './organisme.service';
import { UserService } from './user.service';
import { Injectable } from '@angular/core';
import { FileUploadService } from './file.upload.service';
import { SousAxeService } from './sous.axe.service';
import { AxeService } from './axe.service';
import { RapportService } from './rapport.service';
import { PartenariatService } from './partenariat.service';
import { RealisationService } from './realisation.service';
import { MesureService } from './mesure.service';
import { NatureService } from './nature.service';
import { ActiviteService } from './activite.service';
import { IndicateurMesureService } from './indicateur-mesure.service';
import { MembreCommissionService } from './membre-commission.service';
import { PermissionService } from './permission.service';


@Injectable({
  providedIn: 'root'
})
export class UowService {
  users = new UserService();
  profils = new ProfilService();
  permissions = new PermissionService();
  organismes = new OrganismeService();
  files = new FileUploadService();
  cycles = new CycleService();
  notifications = new NotificationService();
  sousAxes = new SousAxeService();
  axes = new AxeService();
  indicateurs = new IndicateurService();
  indicateurMesures = new IndicateurMesureService();
  indicateurMesureValues = new IndicateurMesureValueService();
  membreCommissions = new MembreCommissionService();
  rapports = new RapportService();
  realisations = new RealisationService();
  commissions = new CommissionService();
  mesures = new MesureService();
  natures = new NatureService();
  partenariats = new PartenariatService();
  activites = new ActiviteService();




  // mecanismes = ['Examen périodique universal', 'Organes de traités', 'Procédure spéciale'];
  typeOrganismes = [
    { id: 1, name: 'منظمة'},
    { id: 2, name: 'جهة'},
    { id: 3, name: 'مؤسسة أو غيرها'},
  ];

  routeScreens = [
    // { id: 1, nameF: 'home',  nameA: 'الإستقبال'},
    { id: 2, nameF: 'mesure-executif ',  nameA: 'المخطط التنفيدي'},
    { id: 3, nameF: 'mesure-region',  nameA: 'المخطط التنفيدي الترابي'},
    { id: 4, nameF: 'mesure-programme',  nameA: 'برامج العمل'},
    { id: 5, nameF: 'suivi',  nameA: 'التتبع'},
    { id: 6, nameF: 'rapport-litteraire',  nameA: 'تقرير الحصيلة الأدبي'},
    { id: 7, nameF: 'rapport-qualitative',  nameA: 'تقرير الحصيلة النوعي'},
    { id: 8, nameF: 'commission',  nameA: 'الجنة'},
    { id: 9, nameF: 'suivi-indicateur',  nameA: 'الجنة'},
    // { id: 9, nameF: 'organisme',  nameA: 'المنظمات'},
    // { id: 10, nameF: 'nature',  nameA: 'نوع التدبير'},
    // { id: 11, nameF: 'indicateur',  nameA: 'المؤشرات'},
    // { id: 12, nameF: 'axe',  nameA: 'المحاور'},
    // { id: 13, nameF: 'sous-axe',  nameA: 'المحاور الفرعية'},
    // { id: 14, nameF: 'user',  nameA: 'المستخدمين'},
    // { id: 15, nameF: 'profil',  nameA: 'الوظيفة'},
    // { id: 16, nameF: 'permission',  nameA: 'صلاحيات المستخدم'},
  ];

  constructor() { }
}
