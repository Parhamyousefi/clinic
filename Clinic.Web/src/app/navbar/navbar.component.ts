import { Component } from '@angular/core';
import { NgForOf, NgClass } from "@angular/common";
import { RouterLink } from "@angular/router";
export interface imenu {
  id: number;
  text: string;
  link: string;
  roleAccess: number[];
  icon: string
}

export const Menu: imenu[] = [
  { id: 0, text: "وقت دهی", link: '/appointment', roleAccess: [], icon: '' },
  { id: 1, text: "اوقات امروز", link: '/', roleAccess: [], icon: '' },
  { id: 2, text: "بیماران", link: '/', roleAccess: [], icon: '' },
  { id: 3, text: "صورت حساب ها", link: '/', roleAccess: [], icon: '' },
  { id: 4, text: "دریافت ها", link: '/', roleAccess: [], icon: '' },
  { id: 5, text: "پرداخت ها", link: '/', roleAccess: [], icon: '' },
  { id: 6, text: "کالاهای مصرفی", link: '/', roleAccess: [], icon: '' },
  { id: 7, text: "هزینه ها", link: '/', roleAccess: [], icon: '' },
  { id: 8, text: "اشخاص", link: '/', roleAccess: [], icon: '' },
  { id: 9, text: "نامه ها", link: '/', roleAccess: [], icon: '' },
  { id: 10, text: "گزارشات", link: '/', roleAccess: [], icon: '' },
  { id: 11, text: "راهنما", link: '/', roleAccess: [], icon: '' },
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
  ngOnInit() {
    this.sidebarMenu = Menu;

  }
}
