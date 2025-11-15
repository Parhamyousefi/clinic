import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DropdownModule } from "primeng/dropdown";
import { MainService } from '../../_services/main.service';
import { ToastrService } from 'ngx-toastr';
import { SharedModule } from '../../share/shared.module';
import moment from 'moment-jalaali';
import { Subject, Subscription } from 'rxjs';


@Component({
  selector: 'attendance-schedule',
  standalone: true,
  imports: [DropdownModule, CommonModule, FormsModule, SharedModule],
  templateUrl: './attendance-schedule.component.html',
  styleUrl: './attendance-schedule.component.css'
})
export class AttendanceScheduleComponent {
  @Input() userId!: number;
  private sub!: Subscription;
  currentUserId!: number;


  clinicsList: any = [];
  newSchedule: any = [];
  selectedTimefrom: any = '00:00';
  selectedTimeTo: any = '23:00';
  scheduleRows: any = [];
  weekDays: any = [
    { code: 6, name: "شنبه" },
    { code: 0, name: "یکشنبه" },
    { code: 1, name: "دوشنبه" },
    { code: 2, name: "سه‌شنبه" },
    { code: 3, name: "چهارشنبه" },
    { cpde: 4, name: "پنج‌شنبه" },
    { code: 5, name: "جمعه" },
  ]


  hours = Array.from({ length: 48 }, (_, i) => {
    const hour = Math.floor(i / 2);
    const minute = i % 2 === 0 ? '00' : '30';
    const time = `${hour.toString().padStart(2, '0')}:${minute}`;

    const now = moment();
    const slotTime = moment().startOf('day');
    slotTime.set({
      hour: +time.split(':')[0],
      minute: +time.split(':')[1]
    });

    return {
      name: time,
      code: i
    };
  });
  doctorSchedule: any;

  constructor(
    private mainService: MainService,
    private toastR: ToastrService
  ) { }

  ngOnInit() {
    this.getClinics();
    this.scheduleRows = this.weekDays.map(d => ({
      day: d,
      active: false,
      fromTime: this.hours[0],
      toTime: this.hours[47],
      isBreak: false,
      code: d.code
    }));
  }

  ngOnChanges() {
    this.getDoctorSchedules(this.userId);
  }

  async getClinics() {
    try {
      let res = await this.mainService.getClinics().toPromise();
      this.clinicsList = res;
      this.clinicsList.forEach((clinic: any) => {
        clinic.code = clinic.id;
      });
      this.newSchedule.clinic = this.clinicsList[0];
    }
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات')
    }
  }


  buildPayload(row: any) {
    return {
      businessId: this.newSchedule.clinic.code,
      practitionerId: this.userId,
      day: row.day.code,
      fromTime: row.fromTime['name'],
      toTime: row.toTime['name'],
      isBreak: row.isBreak,
      isActive: row.active,
      duration: 0,
      editOrNew: -1
    };



  }

  saveAll() {
    // const validation = this.validateRows();

    // if (!validation.valid) {
    //   alert(validation.message);
    //   return;
    // }
    const activeDays = this.scheduleRows.filter(r => r.isActive);
    if (activeDays.length === 0) {
      this.toastR.error("هیچ روزی انتخاب نشده!");
      return;
    }
    activeDays.forEach(day => {
      let dayModel = this.buildPayload(day);
      this.saveDoctorSchedule(dayModel);

    });
  }

  async saveDoctorSchedule(model) {
    try {
      let res: any = this.mainService.saveDoctorSchedule(model).toPromise();
      if (res.status == 0) {
        this.toastR.success("با موفقیت ذخیره شد!")
      }
    }
    catch { }
  }

  async getDoctorSchedules(userId) {
    try {
      let res: any = this.mainService.getDoctorSchedules(userId).toPromise();
      if (res.length > 0) {
        this.doctorSchedule = res;
      }
    }
    catch { }
  }


  //   {
  //   "businessId": 0,
  //   "practitionerId": 0,
  //   "day": 0,
  //   "fromTime": "string",
  //   "toTime": "string",
  //   "isBreak": true,
  //   "isActive": true,
  //   "duration": 0,
  //   "editOrNew": 0
  // }
}
