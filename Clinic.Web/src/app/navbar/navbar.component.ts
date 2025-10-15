import { Component } from '@angular/core';
import { NgForOf, NgClass, NgIf } from "@angular/common";
import { NavigationEnd, Router, RouterOutlet, Event, RouterLink, ActivatedRoute } from '@angular/router';
import { AuthService } from '../_services/auth.service';
export interface imenu {
  id: number;
  text: string;
  link: string;
  roleAccess: number[];
  icon: string
}

export const Menu: imenu[] = [
  { id: 0, text: "وقت دهی", link: '/appointment', roleAccess: [], icon: '' },
  { id: 1, text: "اوقات امروز", link: '/today-appointment', roleAccess: [], icon: '' },
  { id: 2, text: "بیماران", link: '/patients', roleAccess: [], icon: '' },
  { id: 3, text: "صورت حساب ها", link: '/invoice-list', roleAccess: [], icon: '' },
  { id: 4, text: "دریافت ها", link: '/', roleAccess: [], icon: '' },
  { id: 5, text: "پرداخت ها", link: '/', roleAccess: [], icon: '' },
  { id: 6, text: "کالاهای مصرفی", link: '/', roleAccess: [], icon: '' },
  { id: 7, text: "هزینه ها", link: '/', roleAccess: [], icon: '' },
  { id: 8, text: "اشخاص", link: '/contacts', roleAccess: [], icon: '' },
  { id: 9, text: "گزارشات", link: '/', roleAccess: [], icon: '' },
  { id: 10, text: "راهنما", link: '/', roleAccess: [], icon: '' },
];


export const PatientMenu: imenu[] = [
  { id: 0, text: "اطلاعات بیمار", link: '/patient/patient-info', roleAccess: [], icon: '' },
  { id: 1, text: "پرونده بالینی", link: '/patient/today-appointment', roleAccess: [], icon: '' },
  { id: 2, text: "پیوست ها", link: '/patient/patient-attachment', roleAccess: [], icon: '' },
  { id: 3, text: "وقت ها", link: '/patient/pateint-appointments', roleAccess: [], icon: '' },
  { id: 4, text: "صورتحساب ها", link: '/', roleAccess: [], icon: '' },
  { id: 5, text: "دریافت ها", link: '/', roleAccess: [], icon: '' },
  { id: 6, text: "پرداخت ها", link: '/', roleAccess: [], icon: '' },
  { id: 7, text: "پیامک ها", link: '/', roleAccess: [], icon: '' },
];
@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [NgForOf, NgClass, RouterLink, NgIf],
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
  constructor(
    private authService: AuthService,
    private router: Router,
    private activeRoute: ActivatedRoute
  ) {
    router.events.subscribe((event: Event) => {
      let url = location.pathname.split('?')[0];
      if (event instanceof NavigationEnd) {
        if ((url.startsWith('/patient/'))) {
          this.hasPatientMenu = true;
          // this.patientId = this.activeRoute.snapshot.paramMap.get('id');
        }
        else {
          this.hasPatientMenu = false;
        }
      }
    })

  }
  ngOnInit() {
    this.activeRoute.paramMap.subscribe(params => {
      this.patientId = params.get('id');
      console.log('Patient ID:', this.patientId);
    });
    let url = location.pathname;
    this.isMobileSize = window.innerWidth <= 768 && window.innerHeight <= 1024;
    this.sidebarMenu = Menu;
    this.patientMenu = PatientMenu;
  }

  logOut() {
    this.authService.logout();
  }
}

