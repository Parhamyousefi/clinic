import { Component, OnInit } from '@angular/core';
import { TreatmentsService } from './../../_services/treatments.service';
import { UserService } from '../../_services/user.service';
import { SharedModule } from '../../share/shared.module';
import { MainService } from './../../_services/main.service';
import moment from 'moment-jalaali';



@Component({
  selector: 'app-today-appointments',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './today-appointments.component.html',
  styleUrl: './today-appointments.component.css'
})
export class TodayAppointmentsComponent implements OnInit {

  constructor(
    private treatmentsService: TreatmentsService,
    private userService: UserService,
    private mainService: MainService
  ) { }



  clinicsList: any = [];
  selectedClinic: any;
  todayAppointmentsList: any = [];
  servicesList: any = [];
  selectedservice: any;
  selectedDatefrom: any = new Date(new Date().setHours(0, 0, 0, 0));
  selectedTimefrom: any = '00:00';
  selectedDateTo: any = new Date(new Date().setHours(0, 0, 0, 0));
  selectedTimeTo: any = '23:00';
  async ngOnInit() {
    await this.getClinics();
    await this.getBillableItems();
    setTimeout(() => {
      this.getAppointment();
    }, 1000);
  }

  async getAppointment() {
    let model = {
      fromDate: this.selectedDatefrom,
      toDate: this.selectedDateTo,
      clinic: this.selectedClinic?.code,
      service: this.selectedservice?.code,
      from: this.convertTimeToUTC(this.selectedTimefrom),
      to: this.convertTimeToUTC(this.selectedTimeTo)
    }
    try {
      let res: any = await this.treatmentsService.getTodayAppointments(model).toPromise();
      this.todayAppointmentsList = res;
    }
    catch { }

  }

  async getClinics() {
    try {
      let res = await this.userService.getClinics().toPromise();
      this.clinicsList = res;
      this.clinicsList.forEach((clinic: any) => {
        clinic.code = clinic.id;
      });
      setTimeout(() => {
        this.selectedClinic = this.clinicsList[0];
      }, 1000);
    }
    catch { }
  }

  async getBillableItems() {
    try {
      let res = await this.mainService.getBillableItems().toPromise();
      this.servicesList = res;
      this.servicesList.forEach((service: any) => {
        service.code = service.id;
      });
      // setTimeout(() => {
      //   this.selectedservice = this.servicesList[0];
      // }, 1000);
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

  onCalendarOpen(): void {
    setTimeout(() => {
      const calendarBody = document.querySelector('.mat-calendar-body');
      if (!calendarBody) return;

      const faToEnDigits = (str: string): string =>
        str.replace(/[۰-۹]/g, d => String('۰۱۲۳۴۵۶۷۸۹'.indexOf(d)));

      const allCells = Array.from(
        calendarBody.querySelectorAll('.mat-calendar-body-cell-content')
      ) as HTMLElement[];

      const findCellByDay = (targetDay: number): HTMLElement | undefined =>
        allCells.find(cell => {
          const day = parseInt(faToEnDigits(cell.textContent?.trim() || '0'), 10);
          return day === targetDay;
        });

      const todayCell = calendarBody.querySelector('.mat-calendar-body-today') as HTMLElement | null;
      const selectedCell = calendarBody.querySelector('.mat-calendar-body-selected') as HTMLElement | null;

      const todayDay = todayCell
        ? parseInt(faToEnDigits(todayCell.textContent?.trim() || '0'), 10)
        : null;
      const selectedDay = selectedCell
        ? parseInt(faToEnDigits(selectedCell.textContent?.trim() || '0'), 10)
        : null;

      todayCell?.classList.remove('mat-calendar-body-today');
      selectedCell?.classList.remove('mat-calendar-body-selected');

      const newTodayCell = todayDay && todayDay > 2 ? findCellByDay(todayDay - 2) : null;
      const newSelectedCell = selectedDay && selectedDay > 2 ? findCellByDay(selectedDay - 2) : null;

      newTodayCell?.classList.add('mat-calendar-body-today');
      newSelectedCell?.classList.add('mat-calendar-body-selected');
    }, 300);

  }

  onDateChange(event: any): void {
    const originalDate = moment(event.value);
    const shiftedDate = originalDate.clone().subtract(2, 'day');
    this.selectedDatefrom = shiftedDate;


  }

}
