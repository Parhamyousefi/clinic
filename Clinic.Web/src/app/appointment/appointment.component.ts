import { Component, ViewChild } from '@angular/core';
import { SharedModule } from "../share/shared.module";
import { DpDatePickerModule, DatePickerComponent } from 'ngx-jalali-date-picker';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserService } from '../_services/user.service';
import { MatCardModule } from '@angular/material/card';
import { MatCalendar, MatCalendarBody } from '@angular/material/datepicker';
import moment from 'moment-jalaali';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';

@Component({
  selector: 'app-appointment',
  standalone: true,
  imports: [SharedModule, DpDatePickerModule, FormsModule, SharedModule, CommonModule, MatCardModule, MatCalendarBody, MatCalendar, DialogModule, DropdownModule],
  templateUrl: './appointment.component.html',
  styleUrl: './appointment.component.css'
})
export class AppointmentComponent {
  private _selectedDate: Date | null = null;

  appointmentsData: any = [];
  today: any;
  // selectedDate: any;

  datePickerConfig = {
    locale: 'fa',
    format: 'jYYYY/jMM/jDD',
    displayMode: 'popup',
    theme: 'material',
    showGoToCurrent: true
  };
  hours = Array.from({ length: 48 }, (_, i) => {
    const hour = Math.floor(i / 2);
    const minute = i % 2 === 0 ? '00' : '30';
    return `${hour.toString().padStart(2, '0')}:${minute}`;
  });
  timeSheetHeaderDate: any;
  showNewAppointment: boolean = false;
  pateints: any = [];
  selectedPateint: any;
  appointmentTypes: any = [];
  selectedType: any;
  patientsList: any;
  get selectedDate(): Date | null {
    return this._selectedDate;
  }

  set selectedDate(value: Date | null) {
    this._selectedDate = value;
    this.changeDate(2);
  }

  constructor(
    private userService: UserService
  ) { }

  config: any = {
    hideInputContainer: true,
    hideOnOutsideClick: false,
    drops: "down",
    showNearMonthDays: false
  };

  async ngOnInit() {
    this.today = moment();
    this.selectedDate = this.today;
    this.getAppointment(this.today);
    this.today = this.today._d;
  }

  changeDate(status: any) {
    let formattedDate = moment(this.selectedDate);
    if (status == 1) {
      formattedDate = formattedDate.add(1, 'day');
    } else if (status == 2) {
      formattedDate = formattedDate.subtract(1, 'day');
    }
    console.log(this.timeSheetHeaderDate);

  }

  async getAppointment(date: any) {
    try {
      let formattedDate = date.format('YYYY-MM-DD');
      let res: any = await this.userService.getAppointments(1, formattedDate).toPromise();
      this.appointmentsData = res;
      this.timeSheetHeaderDate = date._d;
    }
    catch { }

  }

  async createAppointment() {
    let model = {
      "businessId": 0,
      "practitionerId": 0,
      "patientId": 0,
      "appointmentTypeId": 0,
      "start": "2025-08-24T13:56:59.006Z",
      "end": "2025-08-25T13:56:59.006Z",
      "repeatId": 0,
      "repeatEvery": 0,
      "endsAfter": 0,
      "note": "string",
      "arrived": 0,
      "waitListId": 0,
      "cancelled": false,
      "appointmentCancelTypeId": 0,
      "cancelNotes": "string",
      "isUnavailbleBlock": true,
      "modifierId": 0,
      "createdOn": "2025-08-23T13:56:59.006Z",
      "lastUpdated": "2025-08-23T13:56:59.006Z",
      "isAllDay": true,
      "sendReminder": true,
      "appointmentSMS": "2025-08-23T13:56:59.006Z",
      "ignoreDidNotCome": true,
      "creatorId": 0,
      "byInvoice": true
    }

    let res = await this.userService.createAppointment(model).toPromise();
    console.log(res);

  }

  setNewAppointment(time: any) {
    this.showNewAppointment = true;
    this.getPatients();
    this.getAppointmentTypes();
    console.log(time);
  }


  async getPatients() {
    try {
      let res: any = await this.userService.getPatients().toPromise();
      if (res.length > 0) {
        this.patientsList = res;
        this.patientsList.forEach((patient: any) => {
          patient.name = patient.firstName + ' ' + patient.lastName;
          patient.code = patient.patientCode;
        });
      }
    }
    catch { }
  }

  async getAppointmentTypes() {
    try {
      let res: any = await this.userService.getAppointmentTypes().toPromise();
    }
    catch { }
  }




}
