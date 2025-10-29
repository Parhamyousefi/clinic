import { MainService } from './../../_services/main.service';
import { Component } from '@angular/core';
import { SharedModule, ShamsiUTCPipe } from "../../share/shared.module";
import { FormControl, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserService } from '../../_services/user.service';
import { MatCardModule } from '@angular/material/card';
import moment from 'moment-jalaali';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { ToastrService } from 'ngx-toastr';
import { PatientService } from '../../_services/patient.service';
import { TreatmentsService } from '../../_services/treatments.service';
import { firstValueFrom } from 'rxjs';
@Component({
  selector: 'app-appointment',
  standalone: true,
  imports: [SharedModule, FormsModule, CommonModule, MatCardModule, DialogModule, DropdownModule],
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
  // hours = Array.from({ length: 48 }, (_, i) => {
  //   const hour = Math.floor(i / 2);
  //   const minute = i % 2 === 0 ? '00' : '30';
  //   return `${hour.toString().padStart(2, '0')}:${minute}`;
  // });


  hours = Array.from({ length: 48 }, (_, i) => {
    const hour = Math.floor(i / 2);
    const minute = i % 2 === 0 ? '00' : '30';
    const time = `${hour.toString().padStart(2, '0')}:${minute}`;

    const now = moment(); // الان
    const slotTime = moment().startOf('day');
    slotTime.set({
      hour: +time.split(':')[0],
      minute: +time.split(':')[1]
    });

    return {
      time,
      isBeforeNow: slotTime.isBefore(now)
    };
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
  dayIndexMap = {
    Saturday: 0,
    Sunday: 1,
    Monday: 2,
    Tuesday: 3,
    Wednesday: 4,
    Thursday: 5
  };
  weeklyTimetable: any = [];
  weeklyAppointments: any = [];
  weekDaysAppointmentCount: any = [];
  get selectedDate(): any {
    return this._selectedDate;
  }

  set selectedDate(value: any) {
    this._selectedDate = value;
    this.changeDate(0);
  }

  isBeforeNow: boolean;
  isCalendarVisible = true;
  newPateint: any = [];
  constructor(
    private userService: UserService,
    private toastR: ToastrService,
    private treatmentService: TreatmentsService,
    private patientService: PatientService,
    private mainService: MainService
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
    this.getWeeklyAppointments();
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
    this.isBeforeNow = moment(this.appointmentDate).isBefore(moment().startOf('day'));

  }


  async getAppointment(date: any) {
    const shamsiTimePipe = new ShamsiUTCPipe()
    this.hours.forEach(hour => this.timeSheetData[hour.time] = []);
    try {
      let formattedDate = moment(date).utc().toISOString();

      let model = {

        "clinicId": this.selectedClinic.code,
        "date": formattedDate,
        "doctorId": null
      }
      // let formattedDate = moment(date).format('YYYY-MM-DD');
      let res: any = await this.treatmentService.getAppointments(model).toPromise();
      this.appointmentsData = res;
      this.appointmentsData.forEach((appointment: any) => {
        appointment.typeName = this.appointmentTypes.filter((type: any) => type.id == appointment.appointmentTypeId)[0].name;
        appointment.patientName = this.patientsList.filter((patient: any) => patient.id == appointment.patientId)[0].name;
        appointment.showStartTime = shamsiTimePipe.transform(appointment.start);
        // let startIndex = this.hours.indexOf(appointment.showStartTime);
        let startIndex = this.hours.findIndex(h => h.time === appointment.showStartTime);
        if (startIndex !== -1) {
          this.timeSheetData[this.hours[startIndex].time].push(appointment);
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
      let res = await this.treatmentService.createAppointment(model).toPromise();
      this.toastR.success('با موفقیت ثبت شد')
      this.getAppointment(this.appointmentDate);
      this.getWeeklyAppointments()
      this.newAppointmentModel = [];
      this.showNewAppointment = false;
      this.editmode = false;
    }
    catch (err) {
      this.toastR.error('خطا!', 'خطا در ثبت وقت')
    }
  }

  setNewAppointment(time: any) {
    if (this.isBeforeNow || this.timeIsBeforeNow(this.appointmentDate, time.time)) {
      this.toastR.error('ثبت وقت برای ساعت های پیشین ممکن نیست! ')
    }
    else {
      // this.newAppointmentModel = [];
      this.newAppointmentModel.appointmentStartTime = this.combineDateAndTime(this.appointmentDate, time.time);
      this.newAppointmentModel.appointmentEndTime = this.combineDateAndTime(this.appointmentDate, this.getEndTime(time.time))
      this.showNewAppointment = true;
    }
  }

  async getPatients() {
    try {
      let res: any = await this.patientService.getPatients().toPromise();
      if (res.length > 0) {
        this.patientsList = res;
        this.patientsList.forEach((patient: any) => {
          patient.name = patient.firstName + ' ' + patient.lastName;
          patient.code = patient.id;
        });
      }
    }
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات')

    }
  }

  async getAppointmentTypes() {
    try {
      let res: any = await this.treatmentService.getAppointmentTypes().toPromise();
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
    this.newAppointmentModel.selectedPatient = this.patientsList.filter((patient: any) => patient.id == appointment.patientId)[0];
    this.newAppointmentModel.appointmentStartTime = appointment.start;
    this.newAppointmentModel.appointmentEndTime = appointment.end;
    this.newAppointmentModel.note = appointment.note;
    this.showNewAppointment = true;
    this.editmode = true;
  }

  async getClinics() {
    try {
      let res = await this.mainService.getClinics().toPromise();
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
        isPast: weekStart.isBefore(moment(), 'day'),
        dayAppointments: []
      });
      weekStart.add(1, 'day');
    }

    this.weekDays = daysOfWeek;
    return this.weekDays;
  }

  setWeeklyNewAppointment(date: any, time: any, isPast: any) {
    if (isPast || this.timeIsBeforeNow(date, time)) {
      this.toastR.error('ثبت وقت برای روزهای پیشین ممکن نیست! ')
    }
    else {
      this.newAppointmentModel.appointmentStartTime = this.combineDateAndTime(date, time);
      this.newAppointmentModel.appointmentEndTime = this.combineDateAndTime(date, this.getEndTime(time))
      this.showNewAppointment = true;
    }
  }

  async getWeeklyAppointments() {
    const shamsiTimePipe = new ShamsiUTCPipe()
    this.hours.forEach(hour => this.weeklyTimetable[hour.time] = this.getCurrentWeek());
    let res: any = await this.treatmentService.getWeeklyAppointments().toPromise();
    this.weeklyAppointments = this.transformAppointments(res);
    this.weeklyAppointments.forEach(appointment => {
      appointment.patientName = this.patientsList.filter((patient: any) => patient.patientCode == appointment.patientId)[0].name;
      // let startIndex = this.hours.indexOf(appointment.time);
      let startIndex = this.hours.findIndex(h => h.time === appointment.time);

      this.weeklyTimetable[this.hours[startIndex].time][appointment.dayOfWeek].dayAppointments.push(appointment);
    });
    console.log(this.weeklyTimetable);

  }

  onDateSelect(date: string) {
    this.isCalendarVisible = false;
    setTimeout(() => {
      this.isCalendarVisible = true;
    }, 10);
    this.changeDate(0);
  }

  transformAppointments(data: any) {
    const dayMap: Record<string, number> = {
      Saturday: 0,
      Sunday: 1,
      Monday: 2,
      Tuesday: 3,
      Wednesday: 4,
      Thursday: 5
    }

    const result = Object.entries(data)
      .flatMap(([day, appointments]) =>
        (appointments as any[]).map((appointment) => ({
          ...appointment,
          dayOfWeek: dayMap[day] ?? null,
        }))
      );
    return result;
  }


  timeIsBeforeNow(date: Date, hour: string): boolean {
    const [h, m] = hour.split(':').map(Number);
    const slot = moment(date).hour(h).minute(m).second(0);
    return slot.isBefore(moment());
  }


  async createPatient() {
    if (!this.newPateint.firstName || !this.newPateint.lastName || !this.newPateint.mobile) {
      this.toastR.error('تمامی موارد خواسته شده رو تکمیل کیند');
      return
    }
    let model = {
      titleId: null,
      firstName: this.newPateint.firstName,
      lastName: this.newPateint.lastName,
      gender: null,
      fatherName: null,
      birthDate: null,
      city: null,
      note: null,
      referringInsurerId: null,
      referringInsurer2Id: null,
      referringContactId: null,
      referringContact2Id: null,
      nationalCode: null,
      jobId: null,
      referringInpatientInsurerId: null,
      editOrNew: -1,
      mobile: this.newPateint.mobile,
    }
    let res: any = await firstValueFrom(this.patientService.savePatient(model));
    if (res) {
      this.toastR.success('با موفقیت ثبت شد!');
      await this.getPatients();
      this.newAppointmentModel.selectedPatient = this.patientsList.filter(x => x.firstName == this.newPateint.firstName)[0];
    }

  }
}