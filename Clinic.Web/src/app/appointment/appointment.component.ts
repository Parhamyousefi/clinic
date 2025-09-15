import { Component } from '@angular/core';
import { SharedModule, ShamsiUTCPipe } from "../share/shared.module";
import { FormControl, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserService } from '../_services/user.service';
import { MatCardModule } from '@angular/material/card';
import { MatCalendar, MatCalendarBody } from '@angular/material/datepicker';
import moment from 'moment-jalaali';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { ToastrService } from 'ngx-toastr';
import { PatientService } from '../_services/patient.service';
import { TreatmentsService } from '../_services/treatments.service';
@Component({
  selector: 'app-appointment',
  standalone: true,
  imports: [SharedModule, FormsModule, CommonModule, MatCardModule, MatCalendarBody, MatCalendar, DialogModule, DropdownModule],
  templateUrl: './appointment.component.html',
  styleUrl: './appointment.component.css'
})
export class AppointmentComponent {
  private _selectedDate: Date | null = null;

  appointmentsData: any = [];
  today: any;

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
  weekDays: any = [];
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
  clinicId: any;
  timeSheetData: any = [];
  editmode: boolean = false;
  clinicsList: any = [];
  selectedClinic: any;
  weekMode: any = 0;
  get selectedDate(): any {
    return this._selectedDate;
  }

  set selectedDate(value: any) {
    this._selectedDate = value;
    this.changeDate(0);
  }

  isCalendarVisible = true;

  constructor(
    private userService: UserService,
    private toastR: ToastrService,
    private treatmentService: TreatmentsService,
    private patientService: PatientService
  ) {
  }

  config: any = {
    hideInputContainer: true,
    hideOnOutsideClick: false,
    drops: "down",
    showNearMonthDays: false
  };

  dateNew: any;
  async ngOnInit() {
    this.dateNew = new FormControl(moment().format('jYYYY/jMM/jDD'));
    this.dateNew.valueChanges.subscribe(date => {
      this.onDateSelect(date);
    });

    this.today = moment();
    // this.selectedDate = this.today;
    await this.getPatients();
    await this.getAppointmentTypes();
    await this.getClinics();
    await this.getAppointment(this.today);
    this.today = this.today._d;
    this.getCurrentWeek();
    this.getWeeklyAppointments();
  }

  changeDate(status: number) {
    let formattedDate: any = '';
    switch (status) {
      case 1:
        formattedDate = moment(this.appointmentDate);
        this.appointmentDate = formattedDate.clone().add(1, 'day').toDate();
        this.getAppointment(this.appointmentDate);
        break;

      case 0:
        // formattedDate = moment(this.selectedDate);
        formattedDate = moment(this.dateNew.value, 'jYYYY/jMM/jDD').add(3.5, 'hours');
        this.appointmentDate = formattedDate.clone().toDate();
        this.getAppointment(this.appointmentDate);
        break;

      case -1:
        formattedDate = moment(this.appointmentDate);
        this.appointmentDate = formattedDate.clone().subtract(1, 'day').toDate();
        this.getAppointment(this.appointmentDate);
        break;

      default:
        break;
    }
  }


  async getAppointment(date: any) {
    const shamsiTimePipe = new ShamsiUTCPipe()
    this.hours.forEach(hour => this.timeSheetData[hour] = []);
    try {
      let formattedDate = moment(date).utc().toISOString();

      let model = {

        "clinicId": this.selectedClinic.code,
        "date": formattedDate,
        "doctorId": null
      }
      // let formattedDate = moment(date).format('YYYY-MM-DD');
      let res: any = await this.userService.getAppointments(model).toPromise();
      this.appointmentsData = res;
      this.appointmentsData.forEach((appointment: any) => {
        appointment.typeName = this.appointmentTypes.filter((type: any) => type.id == appointment.appointmentTypeId)[0].name;
        appointment.patientName = this.patientsList.filter((patient: any) => patient.patientCode == appointment.patientId)[0].name;
        appointment.showStartTime = shamsiTimePipe.transform(appointment.start);
        let startIndex = this.hours.indexOf(appointment.showStartTime);
        if (startIndex !== -1) {
          this.timeSheetData[this.hours[startIndex]].push(appointment);
        }
      });
      this.timeSheetHeaderDate = date._d;

    }
    catch { }

  }

  async createAppointment() {
    try {
      let model = {
        "businessId": this.selectedClinic.code,
        "practitionerId": null,
        "patientId": this.newAppointmentModel.selectedPatient.code,
        "appointmentTypeId": this.newAppointmentModel.selectedType.code,
        "start": this.newAppointmentModel.appointmentStartTime,
        "end": this.newAppointmentModel.appointmentEndTime,
        "repeatId": null,
        "repeatEvery": null,
        "endsAfter": null,
        "note": this.newAppointmentModel.note,
        "arrived": null,
        "waitListId": null,
        "cancelled": null,
        "appointmentCancelTypeId": null,
        "cancelNotes": null,
        "isUnavailbleBlock": null,
        "modifierId": null,
        "createdOn": null,
        "lastUpdated": null,
        "isAllDay": null,
        "sendReminder": null,
        "appointmentSMS": null,
        "ignoreDidNotCome": null,
        "creatorId": null,
        "byInvoice": null,
        "editOrNew": this.editmode == true ? this.newAppointmentModel.id : -1
      }
      let res = await this.userService.createAppointment(model).toPromise();
      this.toastR.success('با موفقیت ثبت شد')
      this.getAppointment(this.appointmentDate)
      this.newAppointmentModel = [];
      this.showNewAppointment = false;
      this.editmode = false;
    }
    catch (err) {
      this.toastR.error('خطا!', 'خطا در ثبت وقت')

    }
  }

  setNewAppointment(time: any) {
    // this.newAppointmentModel = [];
    this.newAppointmentModel.appointmentStartTime = this.combineDateAndTime(this.appointmentDate, time);
    this.newAppointmentModel.appointmentEndTime = this.combineDateAndTime(this.appointmentDate, this.getEndTime(time))
    this.showNewAppointment = true;
  }


  async getPatients() {
    try {
      let res: any = await this.patientService.getPatients().toPromise();
      if (res.length > 0) {
        this.patientsList = res;
        this.patientsList.forEach((patient: any) => {
          patient.name = patient.firstName + ' ' + patient.lastName;
          patient.code = patient.patientCode;
        });
      }
    }
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات')

    }
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
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات')
    }
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

  editAppointment(appointment: any) {
    this.newAppointmentModel.id = appointment.id;
    this.newAppointmentModel.selectedType = this.appointmentTypes.filter((type: any) => type.id == appointment.appointmentTypeId)[0];
    this.newAppointmentModel.selectedPatient = this.patientsList.filter((patient: any) => patient.patientCode == appointment.patientId)[0];
    this.newAppointmentModel.appointmentStartTime = appointment.start;
    this.newAppointmentModel.appointmentEndTime = appointment.end;
    this.newAppointmentModel.note = appointment.note;
    this.showNewAppointment = true;
    this.editmode = true;


  }

  async getClinics() {
    try {
      let res = await this.userService.getClinics().toPromise();
      this.clinicsList = res;
      this.clinicsList.forEach((clinic: any) => {
        clinic.code = clinic.id;
      });
      this.selectedClinic = this.clinicsList[0];
    }
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات')
    }
  }

  closeNewAppointmentModal() {
    this.showNewAppointment = false;
    this.newAppointmentModel = [];
  }


  getCurrentWeek() {
    let currentDate = moment(this.appointmentDate);
    let weekStart: any = currentDate.clone().locale('fa').startOf('week');
    let daysOfWeek = [];

    for (let i = 0; i < 6; i++) {
      daysOfWeek.push({
        dayName: weekStart.locale('fa').format('dddd'),
        dayNumber: weekStart.format('jDD'),
        fullDate: weekStart.toDate(),
        isToday: weekStart.isSame(moment(), 'day'),
      });
      weekStart.add(1, 'day');
    }

    this.weekDays = daysOfWeek;
    console.log(this.weekDays);
  }


  setWeeklyNewAppointment(date: any, time: any) {
    this.newAppointmentModel.appointmentStartTime = this.combineDateAndTime(date, time);
    this.newAppointmentModel.appointmentEndTime = this.combineDateAndTime(date, this.getEndTime(time))
    this.showNewAppointment = true;
  }


  async getWeeklyAppointments() {
    let res: any = await this.treatmentService.getWeeklyAppointments().toPromise();
    console.log(res);

  }
  onDateSelect(date: string) {
    this.isCalendarVisible = false;
    setTimeout(() => {
      this.isCalendarVisible = true;
    }, 10);
    this.changeDate(0);
  }

}
