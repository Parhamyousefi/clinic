import { Component, OnInit } from '@angular/core';
import moment from 'moment';
import { TreatmentsService } from './../../_services/treatments.service';
import { UserService } from '../../_services/user.service';
import { SharedModule } from '../../share/shared.module';
import { MainService } from './../../_services/main.service';

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
  selectedDatefrom: Date | null = null;
  selectedTimefrom: any;
  selectedDateTo: Date | null = null;
  selectedTimeTo: any;
  async ngOnInit() {
    await this.getClinics();
    await this.getJobs();
    await this.getAppointment();
  }

  async getAppointment() {
    let today = moment();
    let model = {
      date: today,
      arrived: null,
      clinic: this.selectedClinic?.code,
      service: this.selectedservice?.code,
      from: null,
      to: null
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
      this.selectedClinic = this.clinicsList[0];
    }
    catch { }
  }

  async getJobs() {
    try {
      let res = await this.mainService.getJobs().toPromise();
      this.servicesList = res;
      this.servicesList.forEach((service: any) => {
        service.code = service.id;
      });
      this.selectedClinic = this.servicesList[0];
    }
    catch { }
  }
}