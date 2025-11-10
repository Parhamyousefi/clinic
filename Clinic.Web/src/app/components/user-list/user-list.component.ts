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

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [TableModule, RouterLink, DialogModule, FormsModule, CommonModule, DropdownModule],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent {

  usersList: any;
  showtimeModal: any;
  clinicsList: any;


  constructor(
    private userService: UserService,
    private toastR: ToastrService,
    private mainService: MainService
  ) { }
  ngOnInit() {
    this.getUsers();
  }

  async getUsers() {
    let res: any = await this.userService.getAllUsers().toPromise();
    this.usersList = res;
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

  showtimeSchedule() {
    this.showtimeModal = true;
    this.getClinics();
  }
}
