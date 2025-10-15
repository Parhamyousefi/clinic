import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientAttachmentComponent } from './patient-attachment.component';

describe('PatientAttachmentComponent', () => {
  let component: PatientAttachmentComponent;
  let fixture: ComponentFixture<PatientAttachmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PatientAttachmentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PatientAttachmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
