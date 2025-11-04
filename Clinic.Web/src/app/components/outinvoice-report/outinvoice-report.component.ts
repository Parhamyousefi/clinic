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

  constructor(
    private contactService: ContactService,
    private treatmentsService: TreatmentsService,
    private reportService: ReportService,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.selectedDatefrom = new FormControl(moment().format('jYYYY/jMM/jDD'));
    this.selectedDateTo = new FormControl(moment().format('jYYYY/jMM/jDD'));
    this.getContacts();
    this.getBillableItems();
    this.getDoctors();
    this.getAllUsers();
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

  async getSummaryReport() {
    let model = {
      "fromDate": moment(this.selectedDatefrom.value, 'jYYYY/jMM/jDD').add(3.5, 'hours').toDate(),
      // "fromTime": this.convertTimeToUTC(this.newReport.selectedTimefrom),
      "toDate": moment(this.selectedDateTo.value, 'jYYYY/jMM/jDD').add(3.5, 'hours').toDate(),
      // "toTime": this.convertTimeToUTC(this.newReport.selectedTimeTo),
      "userId": null,
      "serviceId": this.newReport.selectedservice || null,
      "product": this.newReport.selectedProduct,
      "creatorId": this.newReport.creatorId,
      "isPaid": this.newReport.isPaid,
      "referral": this.newReport.referringContactId
    }
    try {
      let res: any = await this.reportService.getOutPatientSummaryReport(model).toPromise();
    }
    catch { }
  }


  convertTimeToUTC(time: string): string {
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

  async getDoctors() {
    try {
      let res: any = await this.userService.getDoctors().toPromise();
      if (res.length > 0) {
        this.doctorsList = res;
        this.doctorsList.forEach(doctor => {
          doctor.code = doctor.id;
          doctor.name = doctor.firstName + ' ' + doctor.lastName;
        });;
        console.log(this.doctorsList);

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
        console.log(this.doctorsList);

      }
    }
    catch { }
  }

}
