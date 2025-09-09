import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SelectButtonModule } from "primeng/selectbutton";
import { InputMaskModule } from 'primeng/inputmask';
import { PatientService } from '../../../_services/patient.service';
import { Router } from '@angular/router';
import { DropdownModule } from 'primeng/dropdown';
@Component({
  selector: 'app-create-patient',
  standalone: true,
  imports: [SelectButtonModule, FormsModule, InputMaskModule, DropdownModule],
  templateUrl: './create-patient.component.html',
  styleUrl: './create-patient.component.css'
})
export class CreatePatientComponent {
  newPatient: any = [];
  genderList: any[] = [{ label: 'مرد', value: '1' }, { label: 'زن', value: '2' }];
  jobs: any;
  mainInsurance: any;
  takmiliInsurance: any;
  firstReagent: any;
  secondReagent: any;
  InpatientInsurance: any;
  patientTitle: any;

  constructor(
    private patientService: PatientService,
    private router: Router
  ) {
  }

  async createPatient() {
    let model = {
      firstName: this.newPatient.firstName,
      lastName: this.newPatient.lastName,
      gender: this.newPatient.gender,
      fatherName: this.newPatient.fatherName,
      birthDate: this.newPatient.birthDate,
      editOrNew: -1
    }
    let res: any = await this.patientService.savePatient(model).toPromise();
    this.router.navigate(['/patients'])
  }
}
