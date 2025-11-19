import { Component } from '@angular/core';
import { TableModule } from "primeng/table";
import { UserService } from '../../_services/user.service';
import { RouterLink } from "@angular/router";
import { DialogModule } from "primeng/dialog";
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { MainService } from '../../_services/main.service';
import { DropdownModule } from 'primeng/dropdown';
import { AttendanceScheduleComponent } from "../attendance-schedule/attendance-schedule.component";
import { Subject } from 'rxjs';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [TableModule, RouterLink, DialogModule, FormsModule, CommonModule, DropdownModule, AttendanceScheduleComponent],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent {
  userId$ = new Subject<number>();
  usersList: any;
  showtimeModal: any;
  clinicsList: any;
  roles: any;
  selectedScheduleUser: any;

  changeUser(id: number) {
    this.userId$.next(id);
  }

  constructor(
    private userService: UserService,
    private toastR: ToastrService,
    private mainService: MainService
  ) { }
  ngOnInit() {
    this.getRoles();
    this.getUsers();
  }

  async getUsers() {
    let res: any = await this.userService.getAllUsers().toPromise();
    this.usersList = res;
    this.usersList.forEach(user => {
      user.roleName = this.roles.filter(role => role.id == user.roleId)[0]['name'];
    });
  }

  async getClinics() {
    try {
      let res = await this.mainService.getClinics().toPromise();
      this.clinicsList = res;
      this.clinicsList.forEach((clinic: any) => {
        clinic.code = clinic.id;
      });
    }
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات')
    }
  }

  showtimeSchedule(user) {
    this.showtimeModal = true;
    this.getClinics();
    this.selectedScheduleUser = user.id;
  }

  async getRoles() {
    try {
      let res: any = await this.userService.getRoles().toPromise();
      if (res.length > 0) {
        this.roles = res;
        this.roles.forEach((type: any) => {
          type.code = type.id;
        });
      }

    }
    catch { }
  }
}
