import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MainService } from '../../../_services/main.service';
import { UserService } from '../../../_services/user.service';
import { ToastrService } from 'ngx-toastr';
import { DropdownModule } from 'primeng/dropdown';

@Component({
  selector: 'app-time-exception',
  standalone: true,
  imports: [CommonModule, FormsModule, DropdownModule],
  templateUrl: './time-exception.component.html',
  styleUrl: './time-exception.component.css'
})
export class TimeExceptionComponent {

  newException: any = [];
  timeExceptions: any = [];
  doctorsList: any = [];
  clinicsList: any = [];
  selectedClinic: any;

  constructor(
    private toastR: ToastrService,
    private userService: UserService,
    private mainService: MainService
  ) { }

  ngOnInit() {
    this.getDoctors();
    this.getClinics();
  }

  async getDoctors() {
    try {
      let res: any = await this.userService.getDoctors().toPromise();
      if (res.length > 0) {
        this.doctorsList = res;
        this.doctorsList.forEach(doctor => {
          doctor.code = doctor.id;
          doctor.name = doctor.firstName + ' ' + doctor.lastName;
        });
      }
    }
    catch { }
  }

  async getClinics() {
    try {
      let res = await this.mainService.getClinics().toPromise();
      this.clinicsList = res;
      this.clinicsList.forEach((clinic: any) => {
        clinic.code = clinic.id;
      });
      this.newException.selectedClinic = this.clinicsList[0];
    }
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات');
    }
  }

  async saveException() {
    let model =
    {
      "startDate": "string",
      "startTime": "string",
      "endTime": "string",
      "practitionerId": 0,
      "timeExceptionTypeId": 0,
      "repeatId": 0,
      "repeatEvery": 0,
      "endsAfter": 0,
      "duration": 0,
      "grigoryDate": "2025-12-01T16:13:15.038Z",
      "businessId": 0,
      "practitionerTimeExceptionId": 0,
      "outOfTurn": 0,
      "defaultAppointmentTypeId": 0,
      "timeSlotSize": 0,
      "editOrNew": -1
    }
    try {
      if (!this.newException.selectedDoctor || !this.newException.dateFrom || !this.newException.dateTo) {
        let res: any = await this.mainService.saveTimeException(this.newException).toPromise();
        this.toastR.success('اطلاعات با موفقیت ثبت شد');
        this.newException = [];
        this.getExceptions();
      }
    }
    catch { }
  }
  
  getExceptions() { }
}