import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { SharedModule } from '../../../share/shared.module';
import { FormControl, FormsModule } from '@angular/forms';
import moment from 'moment-jalaali';
import { ReportService } from '../../../_services/report.service';


@Component({
  selector: 'app-business-report',
  standalone: true,
  imports: [CommonModule, FormsModule, SharedModule],
  templateUrl: './business-report.component.html',
  styleUrl: './business-report.component.css'
})
export class BusinessReportComponent implements OnInit {

  constructor(
    private reportService: ReportService
  ) { }

  dateOptions: any[] = [
    { name: 'امروز', value: 1 },
    { name: 'دیروز', value: 2 },
    { name: 'یک هفته گذشته', value: 3 },
    { name: 'یک ماه گذشته', value: 4 }
  ];
  selectedTypeDate: any;
  selectedDatefrom: any;
  selectedDateTo: any;
  unpaidInvoicesList: any = [];
  setTimes: any = null;
  locationSummary: any = [];
  serviceSummary: any = [];
  submitedInvoicesDetail: any = null;
  ngOnInit(): void {
    this.selectedDatefrom = new FormControl(moment().format('jYYYY/jMM/jDD'));
    this.selectedDateTo = new FormControl(moment().format('jYYYY/jMM/jDD'));
    this.selectedTypeDate = 1;
    this.handelSelectedType();
  }

  handelSelectedType() {
    let fromDate = moment(this.selectedDatefrom.value, 'jYYYY/jMM/jDD');
    let toDate = moment(this.selectedDateTo.value, 'jYYYY/jMM/jDD');
    switch (this.selectedTypeDate) {
      case 1:
        fromDate = toDate.clone();
        break;
      case 2:
        fromDate = toDate.clone().subtract(1, 'day');
        break;
      case 3:
        fromDate = toDate.clone().subtract(7, 'day');
        break;

      case 4:
        fromDate = toDate.clone().subtract(1, 'month');
        break;
    }
    this.selectedDatefrom.setValue(fromDate.format('jYYYY/jMM/jDD'));
  }

  async getData() {
    this.setTimes = null;
    this.unpaidInvoicesList = [];
    this.locationSummary = [];
    this.serviceSummary = [];
    this.submitedInvoicesDetail = null;

    let model = {
      fromDate: moment(this.selectedDatefrom.value, 'jYYYY/jMM/jDD').add(3.5, 'hours').toDate(),
      toDate: moment(this.selectedDateTo.value, 'jYYYY/jMM/jDD').add(3.5, 'hours').toDate(),
    }
    try {
      let res1: any = await this.reportService.getSubmitedAppointments(model).toPromise();
      let res2: any = await this.reportService.getInvoicesByClinic(model).toPromise();
      let res3: any = await this.reportService.getInvoicesByService(model).toPromise();
      let res4: any = await this.reportService.getUnpaidInvoices(model).toPromise();
      let res5: any = await this.reportService.getSubmitedInvoices(model).toPromise();

      this.setTimes = res1['data']
      this.locationSummary = res2;
      this.serviceSummary = res3;
      this.unpaidInvoicesList = res4;
      this.submitedInvoicesDetail = res5;

    }
    catch { }
  }



}
