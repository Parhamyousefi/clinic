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
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { firstValueFrom } from 'rxjs';
import swal from 'sweetalert2';
@Component({
  selector: 'app-patients',
  standalone: true,
  imports: [TableModule, FormsModule, SelectButtonModule, DialogModule, CommonModule, SelectButtonModule, InputMaskModule, DropdownModule],
  templateUrl: './patients.component.html',
  styleUrl: './patients.component.css'
})
export class PatientsComponent {
  patientsList: any = [];
  showCreatePatient: boolean = false;
  newPatient: any = [];
  genderList: any[] = [{ label: 'مرد', value: '1' }, { label: 'زن', value: '2' }];
  titleList: any[] = [
    { name: "جناب", code: "1" },
    { name: "دکتر", code: "2" },
    { name: "آقا", code: "3" },
    { name: "خانم", code: "4" },
    { name: "پروفسور", code: "5" },
    { name: "مهندس", code: "6" },
  ];
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
    { name: "موبایل", code: 1 },
    { name: "منزل", code: 2 },
    { name: "محل کار", code: 3 },
    { name: "فکس", code: 4 },
    { name: "سایر", code: 5 },
  ]
  phoneNum: any = [];
  editpatientMode: boolean = false;
  selectedPatientAddPhoneId: any;
  patientPhoneEditMode: boolean = false;
  selectedEditPhoneNum: any;
  selectedEditPhonePatientId: any;
  hasPhoneNum: boolean;
  constructor(
    private patientService: PatientService,
    private router: Router,
    private mainService: MainService,
    private contactService: ContactService,
    private toastR: ToastrService
  ) {
  }

  ngOnInit() {
    this.getPatients();
    this.getJobs();
    this.getContacts();
  }
  async getPatients() {
    let res: any = await this.patientService.getPatients().toPromise();
    if (res.length > 0) {
      this.patientsList = res;
    }
    this.patientsList.forEach(async patient => {
      patient.patientPhone = await this.getPatientPhone(patient.id);
      patient.phoneNum = patient.patientPhone.number;
    });
  }

  createPatientModal() {
    this.showCreatePatient = true;
    this.getJobs();
    this.getContacts();
  }


  async createPatient() {
    let model = {
      titleId: this.newPatient.title.code,
      firstName: this.newPatient.firstName,
      lastName: this.newPatient.lastName,
      gender: this.newPatient.gender,
      fatherName: this.newPatient.fatherName,
      birthDate: this.newPatient.birthDate,
      city: this.newPatient.city,
      referenceNumber: this.newPatient.referenceNumber,
      note: this.newPatient.note,
      referringInsurerId: this.newPatient.mainInsurance,
      referringInsurer2Id: this.newPatient.takmiliInsurance,
      referringContactId: this.newPatient.referringContactId,
      referringContact2Id: this.newPatient.referringContact2Id,
      nationalCode: this.newPatient.nationalCode,
      jobId: this.newPatient.job.code,
      referringInpatientInsurerId: this.newPatient.referringInpatientInsurerId,
      editOrNew: this.editpatientMode ? this.newPatient.id : -1,
    }
    if (this.newPatient.firstName && this.newPatient.lastName && this.newPatient.gender && this.newPatient.fatherName && this.newPatient.birthDate && this.newPatient.job) {
      let res: any = await firstValueFrom(this.patientService.savePatient(model));
      if (res) {
        this.toastR.success('با موفقیت ثبت شد!');
        this.closeCreatePatientModal();
        this.getPatients();
      }
    }
    else {
      this.toastR.error('خطا', 'مقادیر را به درستی وارد کنید');
    }
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
        contact.code = contact.id,
          contact.name = contact.firstName
      });
    }
  }

  closeCreatePatientModal() {
    this.showCreatePatient = false;
    this.newPatient = [];
  }
  async savePhone() {
    let model = {
      patientId: this.selectedPatientAddPhoneId,
      phoneNoTypeId: this.phoneNum.phoneType.code,
      number: this.phoneNum.phoneNumber,
      editOrNew: this.patientPhoneEditMode ? this.selectedEditPhoneNum : -1
    }
    let res = await this.patientService.savePatientPhone(model).toPromise();
    if (res['status'] == 0) {
      this.toastR.success("با موفقیت ثبت شد!")
      this.patientPhoneEditMode = false;
      this.getPatients();
      this.closeAddPhoneNum();
    }
  }

  closeAddPhoneNum() {
    this.showAddPhoneNum = false;
    this.phoneNum = [];
    this.selectedPatientAddPhoneId = '';
    this.selectedEditPhoneNum = '';
    this.patientPhoneEditMode = false;
  }


  openAddPhoneNumModal(patientId) {
    if (this.patientPhoneEditMode) {
      this.hasPhoneNum = true;
    }
    else {
      this.hasPhoneNum = false;
    }
    this.showAddPhoneNum = true;
    this.selectedPatientAddPhoneId = patientId;
  }

  async getPatientPhone(patientId) {
    try {
      const res: any = await this.patientService.getPatientPhone(patientId).toPromise();
      if (res.length > 0) {
        return res[0];
      }
      else {
        return null;
      }
    }
    catch { }
  }

  editPatient(patient) {
    this.editpatientMode = true;
    this.createPatientModal();
    this.newPatient.title = this.titleList.filter(title => title.code == patient.titleId)[0];
    this.newPatient.firstName = patient.firstName;
    this.newPatient.lastName = patient.lastName;
    this.newPatient.gender = this.genderList.filter(gender => gender.value == patient.gender)[0].value;
    this.newPatient.fatherName = patient.fatherName;
    this.newPatient.birthDate = patient.birthDate;
    this.newPatient.city = patient.city;
    this.newPatient.referenceNumber = patient.referenceNumber;
    this.newPatient.note = patient.notes;
    this.newPatient.mainInsurance = patient.referringInsurerId;
    this.newPatient.takmiliInsurance = patient.referringInsurer2Id;
    this.newPatient.referringContactId = patient.referringContactId;
    this.newPatient.referringContact2Id = patient.referringContact2Id;
    this.newPatient.nationalCode = patient.nationalCode;
    this.newPatient.job = this.jobList.filter(job => job.code == patient.jobId)[0];
    this.newPatient.referringInpatientInsurerId = patient.referringInpatientInsurerId;
    this.newPatient.id = patient.id;
  }

  editPhoneNum(patientPhone) {
    this.selectedEditPhoneNum = patientPhone.id;
    this.patientPhoneEditMode = true;
    this.phoneNum.phoneNumber = patientPhone.number;
    this.phoneNum.phoneType = this.phoneTypeList.filter(type => type.code == patientPhone.phoneNoTypeId)[0];
    this.openAddPhoneNumModal(patientPhone.patientId);
  }

  async deletePatient(patientId) {
    swal.fire({
      title: "آیا از حذف این بیمار مطمئن هستید ؟",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "بله انجام بده",
      cancelButtonText: "منصرف شدم",
      reverseButtons: false,
    }).then(async (result) => {
      try {
        if (result.value) {
          let res: any = await this.patientService.deletePatient(patientId).toPromise();
          if (res['status'] == 0) {
            this.toastR.success('با موفقیت حذف گردید');
            this.getPatients();
          }
        }
      }
      catch {
        this.toastR.error('خطایی رخ داد', 'خطا!')
      }
    })
  }

  async deletePatientPhone(phoneId) {
    swal.fire({
      title: "آیا از حذف شماره تلفن بیمار مطمئن هستید ؟",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "بله انجام بده",
      cancelButtonText: "منصرف شدم",
      reverseButtons: false,
    }).then(async (result) => {
      try {
        let res: any = await this.patientService.deletePatientPhone(phoneId).toPromise();
        if (res['status'] == 0) {
          this.getPatients();
          this.toastR.success('با موفقیت حذف گردید');
          this.closeAddPhoneNum();
        }
      }
      catch {
        this.toastR.error('خطایی رخ داد', 'خطا!')
      }
    })
  }
}
