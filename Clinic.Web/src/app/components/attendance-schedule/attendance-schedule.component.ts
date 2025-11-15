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
  @Input() userId$!: Subject<number>;
  private sub!: Subscription;
  currentUserId!: number;


  clinicsList: any = [];
  newSchedule: any = [];
  selectedTimefrom: any = '00:00';
  selectedTimeTo: any = '23:00';
  weekDays: any = [
    { code: 0, name: "شنبه" },
    { code: 1, name: "یکشنبه" },
    { code: 2, name: "دوشنبه" },
    { code: 3, name: "سه‌شنبه" },
    { code: 4, name: "چهارشنبه" },
    { cpde: 5, name: "پنج‌شنبه" },
    { code: 6, name: "جمعه" },
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

  constructor(
    private mainService: MainService,
    private toastR: ToastrService
  ) { }

  ngOnInit() {
    this.getClinics();
    this.sub = this.userId$.subscribe((id) => {
      this.currentUserId = id;
      console.log('User ID changed:', id);
      // می‌تونی اینجا مثلا API کال بزنی یا لیست ساعت‌ها رو فیلتر کنی
    });

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


  ngOnDestroy(): void {
    this.sub?.unsubscribe(); // ✅ جلوگیری از memory leak
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
