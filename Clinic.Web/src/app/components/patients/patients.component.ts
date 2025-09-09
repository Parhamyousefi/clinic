import { Component } from '@angular/core';
import { PatientService } from '../../_services/patient.service';
import { TableModule } from 'primeng/table';
import { FormsModule } from '@angular/forms';
import { SelectButtonModule } from 'primeng/selectbutton';
import { RouterLink } from "@angular/router";
@Component({
  selector: 'app-patients',
  standalone: true,
  imports: [TableModule, FormsModule, SelectButtonModule, RouterLink],
  templateUrl: './patients.component.html',
  styleUrl: './patients.component.css'
})
export class PatientsComponent {
  patientsList: any = [];
  ;
  constructor(
    private patientService: PatientService
  ) {
  }

  ngOnInit() {
    this.getPatients();
  }

  async getPatients() {
    let res: any = await this.patientService.getPatients().toPromise();
    if (res.length > 0) {
      this.patientsList = res;
      console.log(this.patientsList);

    }
  }
}
