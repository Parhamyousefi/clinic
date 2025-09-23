import { Component } from '@angular/core';
import { TableModule } from "primeng/table";
import { PatientService } from '../../_services/patient.service';

@Component({
  selector: 'app-patient-appointments',
  standalone: true,
  imports: [TableModule],
  templateUrl: './patient-appointments.component.html',
  styleUrl: './patient-appointments.component.css'
})
export class PatientAppointmentsComponent {
  appointmentsList: any;

  constructor(
    private patientService: PatientService
  ) { }

  ngOnInit() {

  }

  async getPatientAppointments(id) {
    let res: any = await this.patientService.getPatientAppointments(id);
  }
}
