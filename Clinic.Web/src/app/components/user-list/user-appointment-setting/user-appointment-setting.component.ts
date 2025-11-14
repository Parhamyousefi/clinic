import { Component, OnInit } from '@angular/core';
import { SharedModule } from '../../../share/shared.module';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { MainService } from '../../../_services/main.service';
import { TreatmentsService } from '../../../_services/treatments.service';

@Component({
  selector: 'app-user-appointment-setting',
  standalone: true,
  imports: [SharedModule, CommonModule],
  templateUrl: './user-appointment-setting.component.html',
  styleUrl: './user-appointment-setting.component.css'
})
export class UserAppointmentSettingComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private mainService: MainService,
    private treatmentService: TreatmentsService
  ) {
    this.route.queryParams.subscribe(params => {
      this.userName = params['userName'];
      this.userId = params['id'];
    });
  }

  userName: string;
  userId: number;
  clinicsList: any = [];
  selectedClinic: any;
  times = Array.from({ length: 24 }, (_, i) =>
    i.toString().padStart(2, '0') + ':00'
  );

  appointmentTypes: any = [];
  defaultType: any = null;
  defaultNewPatientType: any = null;
  numberOutTurn: any;
  minutes = [5, 10, 15, 20, 30, 60];
  minuteSelected: any = null;
  fromSelected: any = null;
  toSelected: any = null;
  freeTime: any;

  ngOnInit(): void {
    this.getClinics();
    this.getAppointmentTypes();
  }

  async getClinics() {
    try {
      let res = await this.mainService.getClinics().toPromise();
      this.clinicsList = res;
      this.clinicsList.forEach((clinic: any) => {
        clinic.code = clinic.id;
      });
    }
    catch { }
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
    }
  }



}
