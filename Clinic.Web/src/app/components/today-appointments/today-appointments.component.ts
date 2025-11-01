import { Component, OnInit } from '@angular/core';
import { TreatmentsService } from './../../_services/treatments.service';
import { UserService } from '../../_services/user.service';
import { SharedModule } from '../../share/shared.module';
import { MainService } from './../../_services/main.service';
import moment from 'moment-jalaali';
import { FormControl } from '@angular/forms';
import { Router, RouterLink } from "@angular/router";
import { InputMaskModule } from 'primeng/inputmask';
import { InvoiceService } from '../../_services/invoice.service';
import { ToastrService } from 'ngx-toastr';
import { MultiSelectModule } from 'primeng/multiselect';
@Component({
  selector: 'app-today-appointments',
  standalone: true,
  imports: [SharedModule, RouterLink, InputMaskModule, MultiSelectModule],
  templateUrl: './today-appointments.component.html',
  styleUrl: './today-appointments.component.css'
})
export class TodayAppointmentsComponent implements OnInit {
  appointmentDiscount: any;

  constructor(
    private treatmentsService: TreatmentsService,
    private userService: UserService,
    private mainService: MainService,
    private invoiceService: InvoiceService,
    private toastR: ToastrService,
    private router: Router
  ) { }

  clinicsList: any = [];
  selectedClinic: any;
  todayAppointmentsList: any = [];
  servicesList: any = [];
  selectedservice: any;
  selectedDatefrom: any;
  selectedTimefrom: any = '00:00';
  selectedDateTo: any;
  selectedTimeTo: any = '23:00';
  showNewDiscount: boolean = false;
  visitStatusList: any = [
    { name: "انتظار ", code: 1 },
    { name: "پذیرش شده", code: 2 },
    { name: "ملاقات شده", code: 3 },
    { name: "تسویه نشده", code: 4 },
    { name: "تخفیف گرفته", code: 5 },
  ]
  filteredAppointments: any = [];
  showAppointmentDetail: any;
  appointmentDetailItem: any = [];
  selectedStatus: any = [];
  discountAppointment: any = [];
  discount: any = [];
  appointmentInvoices: any = [];


  async ngOnInit() {
    this.selectedDatefrom = new FormControl(moment().format('jYYYY/jMM/jDD'));
    this.selectedDateTo = new FormControl(moment().format('jYYYY/jMM/jDD'));
    await this.getClinics();
    await this.getBillableItems();
    setTimeout(() => {
      this.getAppointment();
    }, 1000);
  }

  async getAppointment() {
    let model = {
      fromDate: moment(this.selectedDatefrom.value, 'jYYYY/jMM/jDD').add(3.5, 'hours').toDate(),
      toDate: moment(this.selectedDateTo.value, 'jYYYY/jMM/jDD').add(3.5, 'hours').toDate(),
      clinic: this.selectedClinic?.code,
      service: this.selectedservice?.code,
      from: this.convertTimeToUTC(this.selectedTimefrom),
      to: this.convertTimeToUTC(this.selectedTimeTo)
    }
    try {
      const res: any = await this.treatmentsService.getTodayAppointments(model).toPromise();
      this.todayAppointmentsList = res;
      this.filteredAppointments = [];

      if (this.selectedStatus && this.selectedStatus.length > 0) {
        this.selectedStatus.forEach(status => {
          let filtered = [];

          switch (status.code) {
            case 4:
              filtered = this.todayAppointmentsList.filter(a => a.receipt == 0);
              break;

            case 5:
              filtered = this.todayAppointmentsList.filter(a => a.totalDiscount > 0);
              break;

            default:
              filtered = this.todayAppointmentsList.filter(a => a.status === status.code);
              break;
          }

          this.filteredAppointments.push(...filtered);
        });
      } else {
        this.filteredAppointments = [...this.todayAppointmentsList];
      }

    } catch { }
  }

  async getClinics() {
    try {
      let res = await this.mainService.getClinics().toPromise();
      this.clinicsList = res;
      this.clinicsList.forEach((clinic: any) => {
        clinic.code = clinic.id;
      });
      setTimeout(() => {
        this.selectedClinic = this.clinicsList[0];
      }, 1000);
    }
    catch { }
  }

  async getBillableItems() {
    try {
      let res = await this.treatmentsService.getBillableItems().toPromise();
      this.servicesList = res;
      this.servicesList.forEach((service: any) => {
        service.code = service.id;
      });
      this.servicesList.unshift({
        name: 'همه',
        id: -1,
      });
      // setTimeout(() => {
      //   this.selectedservice = this.servicesList[0];
      // }, 1000);
    }
    catch { }
  }

  convertTimeToUTC(time: string): string {
    let [hours, minutes] = time.split(":").map(Number);
    const now = new Date();
    const date = new Date(Date.UTC(
      now.getFullYear(),
      now.getMonth(),
      now.getDate(),
      hours,
      minutes,
      0,
      0
    ));
    const timePart = date.toISOString().split("T")[1];
    return timePart.replace("Z", "");
  }

  onDateChange(newDate: string) {
  }

  openDiscount(event, item, isEdit) {
    event.stopPropagation();
    if (isEdit) {
      this.discount.amount = item.totalDiscount;
    }
    this.showNewDiscount = true;
    this.discountAppointment = item
  }

  async submitDiscount() {
    try {
      let model = {
        "invoiceId": this.discountAppointment.invoiceId,
        "totalDiscount": this.discount.amount
      }
      let res: any = await this.invoiceService.saveInvoiceDiscount(model).toPromise();
      if (res.status == 0) {
        this.toastR.success('با موفقیت ثبت شد!');
        this.getAppointment();
      }
      this.showNewDiscount = false;
    }
    catch { }
  }

  filterAppointments(searchText: any) {
    if (!searchText) {
      this.filteredAppointments = this.todayAppointmentsList;
      return;
    }

    const text = searchText.toLowerCase();

    this.filteredAppointments = this.todayAppointmentsList.filter(item => {
      return (
        item.patientPhone?.toLowerCase().includes(text) ||
        item.patientName?.toLowerCase().includes(text) ||
        item.id.toString().includes(text)
      );
    });
  }

  async openAppointmentDetail(event, item) {
    event.stopPropagation();
    this.appointmentDetailItem = [];
    try {
      this.showAppointmentDetail = true;
      // this.invoiceService.getInvoiceDetails(item.id).toPromise();
      let res: any = await this.invoiceService.getInvoiceDetails(item.id).toPromise();
      if (res.length > 0) {
        this.appointmentDetailItem = res;
      }
    }
    catch { }
  }

  cancelDiscount() {
    this.discountAppointment = [];
    this.showNewDiscount = false;
  }

  navigateToTreatment(item) {
    if (item.status != 1) {
      this.router.navigate(["/patient/treatment/" + item.patientId])
    }
  }

}