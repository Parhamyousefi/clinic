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
  appointmentStartTime: any;
  newAppointmentModel: any = [];
  appointmentDate: any;
  get selectedDate(): Date | null {
    return this._selectedDate;
  }

  set selectedDate(value: Date | null) {
    this._selectedDate = value;
    this.changeDate(0);
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
    console.log(this.selectedDate);

  }

  // changeDate(status: any) {
  //   let formattedDate: any = moment(this.selectedDate);
  //   if (status == 1) {
  //     formattedDate = formattedDate.add(1, 'day');
  //   } else if (status == 2) {
  //     formattedDate = formattedDate.subtract(1, 'day');
  //   }
  //   this.timeSheetHeaderDate = formattedDate._d;
  // }
  // status :  0  => mostaghim taghir bede
  // status :  1 => + day
  // status : -1 => - day 
  // changeDate(status: any) {
  //   let formattedDate: any = moment(this.selectedDate);
  //   switch (status) {
  //     case 1:
  //       this.selectedDate = formattedDate.add(1, 'day');
  //       break;
  //     case 0:
  //       this.appointmentDate = formattedDate._d;
  //       break;
  //     case -1:
  //       this.appointmentDate = formattedDate.subtract(1, 'day');
  //       break;
  //     default:
  //       break;
  //   }

  // }

  changeDate(status: number) {
    let formattedDate: any = '';
    switch (status) {
      case 1:
        formattedDate = moment(this.appointmentDate);
        this.appointmentDate = formattedDate.clone().add(1, 'day').toDate();
        break;

      case 0:
        formattedDate = moment(this.selectedDate);
        this.appointmentDate = formattedDate.clone().toDate();
        break;

      case -1:
        formattedDate = moment(this.appointmentDate);
        this.appointmentDate = formattedDate.clone().subtract(1, 'day').toDate();
        break;

      default:
        break;
    }
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
      "patientId": this.newAppointmentModel.selectedPateint.code,
      "appointmentTypeId": this.newAppointmentModel.selectedType.code,
      "start": this.newAppointmentModel.appointmentStartTime,
      "end": this.newAppointmentModel.appointmentEndTime,
      "repeatId": 0,
      "repeatEvery": 0,
      "endsAfter": 0,
      "note": this.newAppointmentModel.description,
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
    this.newAppointmentModel.appointmentStartTime = this.combineDateAndTime(this.appointmentDate, time);
    this.newAppointmentModel.appointmentEndTime = this.combineDateAndTime(this.appointmentDate, this.getEndTime(time))
    this.showNewAppointment = true;
    this.getPatients();
    this.getAppointmentTypes();
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
      if (res.length > 0) {
        this.appointmentTypes = res;
        this.appointmentTypes.forEach((type: any) => {
          type.code = type.id;
        });
      }

    }
    catch { }
  }


  combineDateAndTime(dateInput: any, timeInput: any): string {
    const date = new Date(dateInput);
    const timeString = String(timeInput);
    const [hours, minutes] = timeString.split(":").map(Number);
    date.setHours(hours, minutes, 0, 0);
    return date.toISOString();
  }



  getEndTime(startTime: string, durationMinutes: number = 15) {
    const [hours, minutes] = startTime.split(":").map(Number);
    const date = new Date();
    date.setHours(hours, minutes, 0, 0);
    date.setMinutes(date.getMinutes() + durationMinutes);
    const endHours = String(date.getHours()).padStart(2, "0");
    const endMinutes = String(date.getMinutes()).padStart(2, "0");
    return `${endHours}:${endMinutes}`;
  }

}
