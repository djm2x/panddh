import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SuiviIndicateurComponent } from './suivi-indicateur.component';

describe('SuiviIndicateurComponent', () => {
  let component: SuiviIndicateurComponent;
  let fixture: ComponentFixture<SuiviIndicateurComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SuiviIndicateurComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SuiviIndicateurComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
