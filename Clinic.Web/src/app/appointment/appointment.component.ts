import { Component } from '@angular/core';
import { SharedModule } from "../share/shared.module";
import { DpDatePickerModule, IMonth } from 'ng2-date-picker';
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
  weekDetail: any;

  constructor(
    private userService: UserService
  ) { }

  showCalander: any = true;
  changeDate() {
    throw new Error('Method not implemented.');
  }
  getMonthlyClassSchedule($event: IMonth, arg1: number) {
    throw new Error('Method not implemented.');
  }
  selectedDate: any;
  config: any = {
    hideInputContainer: true,
    hideOnOutsideClick: false,
    drops: "down",
    showNearMonthDays: false
  };;
  weekChange(arg0: number) {
    throw new Error('Method not implemented.');
  }
  currentDayForUpComimgString: any;
  upcomingProgram: any;
  currentDayString: any;


  ngOnInit() {
    this.getAppointment();
    // this.createAppointment();
  }
  async getAppointment() {
    let today: any = moment();
    today = today.format('YYYY-MM-DD')
    let res = await this.userService.getAppointments(1, "2025-08-25").toPromise();
    console.log(res);
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

}
