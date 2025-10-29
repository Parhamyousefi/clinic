import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientReceiptsComponent } from './patient-receipts.component';

describe('PatientReceiptsComponent', () => {
  let component: PatientReceiptsComponent;
  let fixture: ComponentFixture<PatientReceiptsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PatientReceiptsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PatientReceiptsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
