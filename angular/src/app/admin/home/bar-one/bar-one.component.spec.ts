import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BarOneComponent } from './bar-one.component';

describe('BarOneComponent', () => {
  let component: BarOneComponent;
  let fixture: ComponentFixture<BarOneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BarOneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BarOneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
