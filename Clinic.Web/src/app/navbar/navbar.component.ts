import { Component } from '@angular/core';
import { NgForOf, NgClass, NgIf } from "@angular/common";
import { NavigationEnd, Router, RouterOutlet, Event, RouterLink, ActivatedRoute } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { PatientService } from '../_services/patient.service';
import { ToastrService } from 'ngx-toastr';
import { PdfMakerComponent } from '../share/pdf-maker/pdf-maker.component';
import swal from 'sweetalert2';
import { PatientMenuComponent } from "../components/patient-menu/patient-menu.component";
export interface imenu {
  id: number;
  text: string;
  link: string;
  roleAccess: number[];
  icon: string
}

export const Menu: imenu[] = [
  { id: 0, text: "وقت دهی", link: '/appointment', roleAccess: [], icon: 'fa fa-calendar' },
  { id: 1, text: "اوقات امروز", link: '/today-appointment', roleAccess: [], icon: 'fa fa-clock-o' },
  { id: 2, text: "بیماران", link: '/patients', roleAccess: [], icon: 'fa fa-users' },
  { id: 3, text: "صورت حساب ها", link: '/invoice-list', roleAccess: [], icon: 'fa fa-file-text' },
  { id: 4, text: "دریافت ها", link: '/receipt-list', roleAccess: [], icon: 'fa fa-credit-card-alt' },
  { id: 5, text: "پرداخت ها", link: '/payment-list', roleAccess: [], icon: 'fa fa-credit-card-alt' },
  { id: 6, text: "کالاهای مصرفی", link: '/product-list', roleAccess: [], icon: 'fa fa-th-large' },
  { id: 7, text: "هزینه ها", link: '/expenses', roleAccess: [], icon: 'fa fa-money' },
  { id: 8, text: "اشخاص", link: '/contacts', roleAccess: [], icon: 'fa fa-user' },
  { id: 9, text: "گزارشات", link: '/', roleAccess: [], icon: 'fa fa-bar-chart' },
  { id: 10, text: "راهنما", link: '/', roleAccess: [], icon: 'fa fa-info-circle' },
];

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [NgForOf, NgClass, RouterLink, NgIf, PdfMakerComponent, PatientMenuComponent],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  sidebarMenu: any[] = [];
  selectedSideBarItem: any;
  selectedPatientSideBarItem: any
  isMobileSize: boolean
  patientMenu: imenu[];
  hasPatientMenu: boolean = false;
  patientId: any;
  patientName: string;
  patientInfo: any;
  openSidebar: boolean;
  constructor(
    private authService: AuthService,
    private router: Router,
    private activeRoute: ActivatedRoute,
    private patientService: PatientService,
    private toastR: ToastrService
  ) {
    router.events.subscribe((event: Event) => {
      let url = location.pathname.split('?')[0];
      let pageUrl = location.pathname;
      if (event instanceof NavigationEnd) {
        if ((url.startsWith('/patient/'))) {
          this.hasPatientMenu = true;
          if ((url.startsWith('/patient/info'))) {
            pageUrl = this.router.url;
            this.patientId = url.split('/').pop();
            this.getPatientById(this.patientId);
          }
        }
        else {
          this.hasPatientMenu = false;
        }
      }
    })

  }
  ngOnInit() {
    let url = location.pathname;
    this.isMobileSize = window.innerWidth <= 768 && window.innerHeight <= 1024;
    if (this.isMobileSize) {
      this.openSidebar = false;
    }
    else {
      this.openSidebar = true;
    }
    this.sidebarMenu = Menu;
    if ((url.startsWith('/patient/'))) {
      this.hasPatientMenu = true;
      this.patientId = url.split('/').pop();
      this.getPatientById(this.patientId);

    }
  }

  logOut() {
    this.authService.logout();
  }


  async getPatientById(patientId) {
    try {
      let res: any = await this.patientService.getPatientById(patientId).toPromise();
      if (res.length > 0) {
        this.patientInfo = res[0]
        this.patientName = res[0].firstName + "" + res[0].lastName;
      }
    }
    catch {
      this.toastR.error('خطا!', 'خطا در دریافت اطلاعات');
    }
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
            this.router.navigate(['/patients']);
          }
        }
      }
      catch {
        this.toastR.error('خطایی رخ داد', 'خطا!')
      }
    })
  }


  mobileSideBarClose() {
    if (this.isMobileSize) {
      this.openSidebar = false;
    }
  }



}

