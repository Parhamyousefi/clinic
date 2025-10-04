import { Component } from '@angular/core';
import { TableModule } from "primeng/table";
import { PatientService } from '../../_services/patient.service';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { SharedModule } from '../../share/shared.module';
import { UserService } from '../../_services/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-patient-appointments',
  standalone: true,
  imports: [TableModule, SharedModule, RouterLink],
  templateUrl: './patient-appointments.component.html',
  styleUrl: './patient-appointments.component.css'
})
export class PatientAppointmentsComponent {
  appointmentsList: any;
  patientAppointmentsList: any = [];
  selectedEditContactId: any;
  clinicsList: any = [];
  selectedClinic: any;
  appointmentTypes: any;
  patientName: any;
  constructor(
    private patientService: PatientService,
    private activeRoute: ActivatedRoute,
    private userService: UserService,
    private toastR: ToastrService
  ) { }

  async ngOnInit() {
    this.selectedEditContactId = this.activeRoute.snapshot.paramMap.get('id');
    await this.getClinics();
    await this.getAppointmentTypes();
    await this.getPatientAppointments(this.selectedEditContactId);
    this.getPatientById(this.selectedEditContactId)
  }

  async getPatientAppointments(id) {
    let res: any = await this.patientService.getPatientAppointments(id).toPromise();
    if (res.length > 0) {
      this.patientAppointmentsList = res;
      this.patientAppointmentsList.forEach(appointment => {
        appointment.clinicName = this.clinicsList.filter(clinic => clinic.id == appointment.businessId)[0].name;
        appointment.typeName = this.appointmentTypes.filter(type => type.id == appointment.appointmentTypeId)[0].name;
      });
    }
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

  async getPatientById(patientId) {
    try {
      let res: any = await this.patientService.getPatientById(patientId).toPromise();
      if (res.length > 0) {
        this.patientName = res[0].firstName + "" + res[0].lastName
      }
    }
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات')
    }
  }
}
