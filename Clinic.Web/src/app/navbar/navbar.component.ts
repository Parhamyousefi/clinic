import { Component } from '@angular/core';
export interface imenu {
  text: string;
  link: string;
  roleAccess: number[];
  icon: string
}

export const Menu: imenu[] = [
  { text: "وقت دهی", link: '/', roleAccess: [], icon: '' },
  { text: "اوقات امروز", link: '/', roleAccess: [], icon: '' },
  { text: "بیماران", link: '/', roleAccess: [], icon: '' },
  { text: "صورت حساب ها", link: '/', roleAccess: [], icon: '' },
  { text: "دریافت ها", link: '/', roleAccess: [], icon: '' },
  { text: "پرداخت ها", link: '/', roleAccess: [], icon: '' },
  { text: "کالاهای مصرفی", link: '/', roleAccess: [], icon: '' },
  { text: "هزینه ها", link: '/', roleAccess: [], icon: '' },
  { text: "اشخاص", link: '/', roleAccess: [], icon: '' },
  { text: "نامه ها", link: '/', roleAccess: [], icon: '' },
  { text: "گزارشات", link: '/', roleAccess: [], icon: '' },
  { text: "راهنما", link: '/', roleAccess: [], icon: '' },
];
@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

}
