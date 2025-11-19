import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OutinvoiceReportComponent } from './outinvoice-report.component';

describe('OutinvoiceReportComponent', () => {
  let component: OutinvoiceReportComponent;
  let fixture: ComponentFixture<OutinvoiceReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OutinvoiceReportComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OutinvoiceReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
