import { Component } from '@angular/core';
import { PatientService } from '../../_services/patient.service';
import { TableModule } from 'primeng/table';
import { FormsModule } from '@angular/forms';
import { SelectButtonModule } from 'primeng/selectbutton';
import { Router, RouterLink } from "@angular/router";
import { DialogModule } from "primeng/dialog";
import { CommonModule } from '@angular/common';
import { MainService } from '../../_services/main.service';
import { ContactService } from '../../_services/contact.service';
import { InputMaskModule } from 'primeng/inputmask';
import { DropdownModule } from 'primeng/dropdown';
@Component({
  selector: 'app-patients',
  standalone: true,
  imports: [TableModule, FormsModule, SelectButtonModule, RouterLink, DialogModule, CommonModule, SelectButtonModule, InputMaskModule, DropdownModule],
  templateUrl: './patients.component.html',
  styleUrl: './patients.component.css'
})
export class PatientsComponent {
  patientsList: any = [];
  showCreatePatient: boolean = false;
  newPatient: any = [];
  genderList: any[] = [{ label: 'مرد', value: '1' }, { label: 'زن', value: '2' }];
  jobs: any;
  mainInsurance: any;
  takmiliInsurance: any;
  firstReagent: any;
  secondReagent: any;
  InpatientInsurance: any;
  patientTitle: any;
  jobList: any = [];
  contactsList: any = [];
  showAddPhoneNum: boolean = false;
  phoneTypeList: any = [
    { name: "موبایل", code: 0 },
    { name: "منزل", code: 1 },
    { name: "محل کار", code: 2 },
    { name: "فکس", code: 3 },
    { name: "سایر", code: 4 },
  ]
  phoneNum: any = [];
  constructor(
    private patientService: PatientService,
    private router: Router,
    private mainService: MainService,
    private contactService: ContactService
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

  createPatientModal() {
    this.showCreatePatient = true;
    this.getJobs();
    this.getContacts();
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

  async getJobs() {
    let res: any = await this.mainService.getJobs().toPromise();
    if (res.length > 0) {
      this.jobList = res;
      this.jobList.forEach(job => {
        job.code = job.id
      });

    }
  }

  async getContacts() {
    let res: any = await this.contactService.getContacts().toPromise();
    if (res.length > 0) {
      this.contactsList = res;
      this.contactsList.forEach(contact => {
        contact.code = contact.id
      });
    }
  }

  closeCreatePatientModal() {
    this.showCreatePatient = false;
    this.newPatient = [];
  }
  async savePhone() {
    let model = {
      "patientId": 0,
      "phoneNoTypeId": 0,
      "number": "string",
      "modifierId": 0,
      "createdOn": "2025-09-13T14:41:14.026Z",
      "lastUpdated": "2025-09-13T14:41:14.026Z",
      "creatorId": 0
    }
    let res = await this.patientService.savePatientPhone(model).toPromise();
  }
}
