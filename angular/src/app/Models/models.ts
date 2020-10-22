export class User {
  id = 0;
  nom = '';
  prenom = '';
  email = '';
  password = '';
  adresse = '';
  tel = '';
  fix = '';
  username = '';
  actif = false;
  idOrganisme = 0;
  idProfil = 0;
  organisme = new Organisme();
  profil = new Profil();
}

export class Indicateur {
  id = 0;
  nom = '';
  source = '';
  indicateurMesures: IndicateurMesure[] = [];
  indicateurMesureValues: IndicateurMesureValue[] = [];
}

export class IndicateurMesureValue {
  id = 0;
  idIndicateur = 0;
  idMesure = 0;
  value = '';
  date = new Date();
  indicateur = new Indicateur();
  mesure = new Mesure();
}

export class IndicateurMesure {
  idIndicateur = 0;
  idMesure = 0;
  // value = '';
  // date = new Date();
  indicateur = new Indicateur();
  mesure = new Mesure();
}

export class Commission {
  id = 0;
  type = '';
  pv = '';
  dateEvenement = new Date();
  membreCommissions: MembreCommission[] = [];
}

export class MembreCommission {
  id = 0;
  nomComplete = '';
  email = '';
  idCommission = 0;
  commission = new Commission();
}

export class Organisme {
  id = 0;
  type = 1;
  label = '';
  adresse = '';
  tel = '';
  users: User[] = [];
}

export class Notification {
  id = 0;
  idConcerner = 0;
  idOrganisme = 0;
  tableConcerner = '';
  message = '';
  destinataire = '';
  date = new Date();
  vu = false;
  priorite = 1;
}

export class Realisation {
  id = 0;
  nom = '';
  situation = '';
  annee = 0;
  taux = '';
  effet = '';
  idActivite = 0;
  activite = new Activite();
}

export class Rapport {
  id = 0;
  titre = '';
  dateDernierRapport = new Date();
  dateObservation = new Date();
  dateProchaineRapport = new Date();
  reference = '';
  pieceJointe = '';
}


export class Activite {
  id = 0;
  nom = '';
  duree = '';
  idMesure = 0;
  mesure = new Mesure();

  dureeToString() {
    return this.duree === '' ? '' : JSON.stringify(this.duree);
  }

  dureeToArray(): string[] {
    try {
      return this.duree !== '' ? JSON.parse(this.duree) : [''];
    } catch (error) {
      return [];
    }
  }
}

export class Mesure {
  id = 0;
  code = '';
  nom = '';
  idType = 0;
  idResponsable = 0;
  idAxe = 0;
  idSousAxe = 0;
  idCycle = 0;
  idNature = 0;
  resultatsAttendu = '';
  objectifGlobal = '';
  objectifSpeciaux = '';
  axe = new Axe();
  sousAxe = new SousAxe();
  cycle = new Cycle();
  nature = new Nature();
  responsable = new User();

  indicateurMesures: IndicateurMesure[] = [];
  indicateurMesureValues: IndicateurMesureValue[] = [];
  activites: Activite[] = [];
  partenariats: Partenariat[] = [];

}

export class Profil {
  id = 0;
  label = '';
}

export class Permission {
  id = 0;
  idProfil = 0;
  action: Action;
  routeScreen = '';
  routeScreenAr = '';
  profil = new Profil();
}

export enum Action {
  Consultation = 'Consultation',
  Modification = 'Modification'
  // Ajout,
  // Suppression,
  // Refuse,
}

// enum FileAccess {
//   // constant members
//   None,
//   Read    = 1 << 1,
//   Write   = 1 << 2,
//   ReadWrite  = Read | Write,
//   // computed member
//   G = "123".length
// }


export class Partenariat {
  idOrganisme = 0;
  idMesure = 0;
  mesure = new Mesure();
  organisme = new Organisme();
}

export class Cycle {
  id = 0;
  label = '';
}

export class Nature {
  id = 0;
  label = '';
}

export class Axe {
  id = 0;
  label = '';
}


export class SousAxe {
  id = 0;
  label = '';
  idAxe = 0;
  axe = new Axe();
}

