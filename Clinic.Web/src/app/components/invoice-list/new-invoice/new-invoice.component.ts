import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../_services/user.service';
import { SharedModule } from '../../../share/shared.module';
import { PatientService } from '../../../_services/patient.service';

@Component({
  selector: 'app-new-invoice',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './new-invoice.component.html',
  styleUrl: './new-invoice.component.css'
})
export class NewInvoiceComponent implements OnInit {

  constructor(
    private userService: UserService,
    private patientService: PatientService
  ) { }

  patientsList: any = [];
  selectedPatient: any;
  clinicsList: any = [];
  selectedClinic: any;
  hours = Array.from({ length: 48 }, (_, i) => {
    const hour = Math.floor(i / 2);
    const minute = i % 2 === 0 ? '00' : '30';
    const name = `${hour.toString().padStart(2, '0')}:${minute}`;
    return { id: i, name };
  });
  hasInviceId: number;

  ngOnInit(): void {
    this.getPatients();
    this.getClinics();

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
    catch { }
  }

  async getClinics() {
    try {
      let res = await this.userService.getClinics().toPromise();
      this.clinicsList = res;
      this.clinicsList.forEach((clinic: any) => {
        clinic.code = clinic.id;
      });
    }
    catch { }
  }
}
