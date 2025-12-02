import { Component, OnInit } from '@angular/core';
import { SharedModule } from '../../share/shared.module';
import Swal from 'sweetalert2';
import { ToastrService } from 'ngx-toastr';
import { MainService } from '../../_services/main.service';
import moment from 'moment-jalaali';
import { FormControl } from '@angular/forms';
import { UserService } from '../../_services/user.service';

@Component({
  selector: 'app-out-of-turn-exceptions',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './out-of-turn-exceptions.component.html',
  styleUrl: './out-of-turn-exceptions.component.css'
})
export class OutOfTurnExceptionsComponent implements OnInit {


  constructor(
    private mainService: MainService,
    private toastR: ToastrService,
    private userService: UserService
  ) { }

  displayFormModal: boolean = false;
  form: any = [];
  itemList: any = [];
  clinicsList: any = [];
  doctorList: any = [];

  ngOnInit(): void {
    this.getUsers();
    this.getClinics();
    this.form.selectedDate = new FormControl(moment().format('jYYYY/jMM/jDD'));

  }

  save() {

  }

  openModal() {
    this.displayFormModal = true;
  }

  edit(item) {

  }

  async deleteItem(id) {
    Swal.fire({
      title: "آیا از حذف این مورد مطمئن هستید ؟",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "بله انجام بده",
      cancelButtonText: "منصرف شدم",
      reverseButtons: false,
    }).then(async (result) => {
      try {
        if (result.value) {
          // let res: any = await this.mainService.deleteDoctorSchedule(id).toPromise();
          // if (res.status == 0) {
          //   this.toastR.success("با موفقیت حذف شد!")
          // }
        }
      }
      catch {
        this.toastR.error('خطایی رخ داد', 'خطا!')
      }
    })
  }


  async getClinics() {
    try {
      let res = await this.mainService.getClinics().toPromise();
      this.clinicsList = res;
      setTimeout(() => {
        this.form.selectedClinic = this.clinicsList[0];
      }, 1000);
    }
    catch { }
  }

  async getUsers() {
    let res: any = await this.userService.getAllUsers().toPromise();
    this.doctorList = res.filter(x => x.roleId == 9);
    this.doctorList.forEach(user => {
      user.name = user.firstName + ' ' + user.lastName;
    });
    this.form.selectedDoctor = this.doctorList[0];
  }


}
