import { Component } from '@angular/core';
import { NgForOf, NgClass } from "@angular/common";
import { RouterLink } from "@angular/router";
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
  { id: 0, text: "اطلاعات بیمار", link: '/patient-info', roleAccess: [], icon: '' },
  { id: 1, text: "پرونده بالینی", link: '/today-appointment', roleAccess: [], icon: '' },
  { id: 2, text: "پیوست ها", link: '/patient-attachment', roleAccess: [], icon: '' },
  { id: 3, text: "وقت ها", link: '/pateint-appointments', roleAccess: [], icon: '' },
  { id: 4, text: "صورتحساب ها", link: '/', roleAccess: [], icon: '' },
  { id: 5, text: "دریافت ها", link: '/', roleAccess: [], icon: '' },
  { id: 6, text: "پرداخت ها", link: '/', roleAccess: [], icon: '' },
  { id: 7, text: "پیامک ها", link: '/', roleAccess: [], icon: '' },
];
@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [NgForOf, NgClass, RouterLink],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  sidebarMenu: any[] = [];
  selectedSideBarItem: any;
  isMobileSize: boolean
  patientMenu: imenu[];
  constructor(
    private authService: AuthService
  ) {

  }
  ngOnInit() {
    this.isMobileSize = window.innerWidth <= 768 && window.innerHeight <= 1024;
    this.sidebarMenu = Menu;
    this.patientMenu = PatientMenu

  }

  logOut() {
    this.authService.logout();
  }
}
