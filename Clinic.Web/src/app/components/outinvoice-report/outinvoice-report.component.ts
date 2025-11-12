import { Component } from '@angular/core';
import { NgxMaterialTimepickerModule } from "ngx-material-timepicker";
import { SharedModule } from "../../share/shared.module";
import { FormControl } from '@angular/forms';
import moment from 'moment-jalaali';
import { DropdownModule } from 'primeng/dropdown';
import { ContactService } from '../../_services/contact.service';
import { TreatmentsService } from '../../_services/treatments.service';
import { MultiSelectModule } from 'primeng/multiselect';
import { TableModule } from 'primeng/table';
import { ReportService } from '../../_services/report.service';
import { UserService } from '../../_services/user.service';
import { MainService } from '../../_services/main.service';
@Component({
  selector: 'app-outinvoice-report',
  standalone: true,
  imports: [NgxMaterialTimepickerModule, SharedModule, DropdownModule, MultiSelectModule, TableModule],
  templateUrl: './outinvoice-report.component.html',
  styleUrl: './outinvoice-report.component.css'
})
export class OutinvoiceReportComponent {
  selectedDatefrom: any;
  selectedTimefrom: any = '00:00';
  selectedDateTo: any;
  selectedTimeTo: any = '23:00';
  selectedservice: any;
  servicesList: any;
  clinicsList: any;
  selectedClinic: any;
  visitStatusList: any;
  selectedStatus: any;
  newReport: any = [];
  onDateChange($event: any) {
    throw new Error('Method not implemented.');
  }
  tasviehStatus: any[] = [{ label: 'باشد', value: '1' }, { label: 'نباشد', value: '0' }];
  contactsList: any = [];
  summaryReport: any = [];
  doctorsList: any = [];
  usersList: any = [];
  reportList: any = [];
  productsList: any = [];
  reportListCreatorBased: any = [];
  reportDetailsList: any = [];
  constructor(
    private contactService: ContactService,
    private treatmentsService: TreatmentsService,
    private reportService: ReportService,
    private userService: UserService,
    private mainService: MainService,
  ) { }

  ngOnInit() {
    this.selectedDatefrom = new FormControl(moment().format('jYYYY/jMM/jDD'));
    this.selectedDateTo = new FormControl(moment().format('jYYYY/jMM/jDD'));
    this.getContacts();
    this.getBillableItems();
    this.getDoctors();
    this.getAllUsers();
    this.getProducts();
  }


  async getContacts() {
    let res: any = await this.contactService.getContacts().toPromise();
    if (res.length > 0) {
      this.contactsList = res;
      this.contactsList.forEach(contact => {
        contact.code = contact.id,
          contact.name = contact.firstName
      });
    }
  }

  async getBillableItems() {
    try {
      let res = await this.treatmentsService.getBillableItems().toPromise();
      this.servicesList = res;
      this.servicesList.forEach((service: any) => {
        service.code = service.id;
      });
      this.servicesList.unshift({
        name: 'همه',
        id: -1,
      });
    }
    catch { }
  }

  fieldConvert(item) {
    if (item) {
      return item.toString();
    }
    else {
      return null;
    }
  }

  async getReports() {
    await this.getSummaryReport();
    await this.getOutPatientReportBasedOnCreator();
    await this.getIncomeReportDetails();
  }

  async getSummaryReport() {
    let model = {
      "fromDate": moment(this.selectedDatefrom.value, 'jYYYY/jMM/jDD').add(3.5, 'hours').toDate(),
      "fromTime": this.convertTimeToUTC(this.newReport.selectedTimefrom),
      "toDate": moment(this.selectedDateTo.value, 'jYYYY/jMM/jDD').add(3.5, 'hours').toDate(),
      "toTime": this.convertTimeToUTC(this.newReport.selectedTimeTo),
      "userId": null,
      "serviceId": this.fieldConvert(this.newReport.selectedservice),
      "product": this.fieldConvert(this.newReport.selectedProduct),
      "creatorId": this.fieldConvert(this.newReport.creatorId),
      "isPaid": this.fieldConvert(this.newReport.isPaidStatus),
      "referral": this.fieldConvert(this.newReport.referringContactId)
    }
    try {
      let res: any = await this.reportService.getOutPatientSummaryReport(model).toPromise();
      if (res.data) {
        this.reportList = [];
        this.reportList.push(res.data);
      }
    }
    catch { }
  }


  async getOutPatientReportBasedOnCreator() {
    let model = {
      "fromDate": moment(this.selectedDatefrom.value, 'jYYYY/jMM/jDD').add(3.5, 'hours').toDate(),
      "fromTime": this.convertTimeToUTC(this.newReport.selectedTimefrom),
      "toDate": moment(this.selectedDateTo.value, 'jYYYY/jMM/jDD').add(3.5, 'hours').toDate(),
      "toTime": this.convertTimeToUTC(this.newReport.selectedTimeTo),
      "userId": null,
      "serviceId": this.fieldConvert(this.newReport.selectedservice),
      "product": this.fieldConvert(this.newReport.selectedProduct),
      "creatorId": this.fieldConvert(this.newReport.creatorId),
      "isPaid": this.fieldConvert(this.newReport.isPaidStatus),
      "referral": this.fieldConvert(this.newReport.referringContactId)
    }
    try {
      let res: any = await this.reportService.getOutPatientReportBasedOnCreator(model).toPromise();
      if (res.data) {
        this.reportListCreatorBased = [];
        this.reportListCreatorBased = res.data;
      }
    }
    catch { }
  }

  async getIncomeReportDetails() {
    let model = {
      "fromDate": moment(this.selectedDatefrom.value, 'jYYYY/jMM/jDD').add(3.5, 'hours').toDate(),
      "fromTime": this.convertTimeToUTC(this.newReport.selectedTimefrom),
      "toDate": moment(this.selectedDateTo.value, 'jYYYY/jMM/jDD').add(3.5, 'hours').toDate(),
      "toTime": this.convertTimeToUTC(this.newReport.selectedTimeTo),
    }
    try {
      let res: any = await this.reportService.getIncomeReportDetails(model).toPromise();
      if (res) {
        this.reportDetailsList = [];
        this.reportDetailsList = res;
      }
    }
    catch { }
  }

  convertTimeToUTC(time: string): string {
    if (time) {
      let [hours, minutes] = time.split(":").map(Number);
      const now = new Date();
      const date = new Date(Date.UTC(
        now.getFullYear(),
        now.getMonth(),
        now.getDate(),
        hours,
        minutes,
        0,
        0
      ));
      const timePart = date.toISOString().split("T")[1];
      return timePart.replace("Z", "");
    }
    else {
      return null
    }
  }

  async getDoctors() {
    try {
      let res: any = await this.userService.getDoctors().toPromise();
      if (res.length > 0) {
        this.doctorsList = res;
        this.doctorsList.forEach(doctor => {
          doctor.code = doctor.id;
          doctor.name = doctor.firstName + ' ' + doctor.lastName;
        });;
      }
    }
    catch { }
  }

  async getAllUsers() {
    try {
      let res: any = await this.userService.getAllUsers().toPromise();
      if (res.length > 0) {
        this.usersList = res;
        this.usersList.forEach(user => {
          user.code = user.id;
          user.name = user.firstName + ' ' + user.lastName;
        });;
      }
    }
    catch { }
  }

  async getProducts() {
    try {
      let res: any = await this.mainService.getProducts().toPromise();
      if (res.length > 0) {
        this.productsList = res;
        this.productsList.forEach(prod => {
          prod.code = prod.id;
        });;
      }
    }
    catch { }
  }

}
