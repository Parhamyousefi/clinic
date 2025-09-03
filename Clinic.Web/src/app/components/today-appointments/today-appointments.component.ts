import { Component, OnInit } from '@angular/core';
import moment from 'moment';
import { TreatmentsService } from './../../_services/treatments.service';
import { UserService } from '../../_services/user.service';
import { SharedModule } from '../../share/shared.module';

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
    private userService: UserService
  ) { }

  clinicsList: any = [];
  selectedClinic: any;
  todayAppointmentsList: any = [];

  async ngOnInit() {
    await this.getClinics();
    await this.getAppointment();
  }

  async getAppointment() {
    let today = moment();
    let model = {
      date: today,
      arrived: null,
      clinic: this.selectedClinic.code,
      "service": 0,
      from: null,
      to: null
    }
    try {
      let res: any = await this.treatmentsService.getTodayAppointments(model).toPromise();

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

}
