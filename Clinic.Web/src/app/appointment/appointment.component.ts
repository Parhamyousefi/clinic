import { Component, ViewChild } from '@angular/core';
import { SharedModule } from "../share/shared.module";
import { DpDatePickerModule, DatePickerComponent } from 'ngx-jalali-date-picker';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserService } from '../_services/user.service';
import moment from 'moment';
@Component({
  selector: 'app-appointment',
  standalone: true,
  imports: [SharedModule, DpDatePickerModule, FormsModule, SharedModule, CommonModule],
  templateUrl: './appointment.component.html',
  styleUrl: './appointment.component.css'
})
export class AppointmentComponent {
  appointmentsData: any = [];
  today: any;
  selectedDate: any;

  datePickerConfig = {
    locale: 'fa',
    format: 'jYYYY/jMM/jDD',
    displayMode: 'popup',
    theme: 'material',
    showGoToCurrent: true
  };
  @ViewChild('picker') picker!: DatePickerComponent;
  hours = Array.from({ length: 48 }, (_, i) => {
    const hour = Math.floor(i / 2);
    const minute = i % 2 === 0 ? '00' : '30';
    return `${hour.toString().padStart(2, '0')}:${minute}`;
  });
  constructor(
    private userService: UserService
  ) { }

  config: any = {
    hideInputContainer: true,
    hideOnOutsideClick: false,
    drops: "down",
    showNearMonthDays: false
  };

  ngAfterViewInit() {
    this.picker.showCalendars();
  }

  async ngOnInit() {
    this.today = moment();
    this.getAppointment(this.today);
    this.today = this.today._d;
  }

  async getAppointment(date: any) {
    date = date._d.format('YYYY-MM-DD');
    let res: any = await this.userService.getAppointments(1, date).toPromise();
    if (res.length > 0) {
      this.appointmentsData = res;
    }

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
    console.log(time);

  }




}
