import { Component } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet, Event } from '@angular/router';
import { NavbarComponent } from "./navbar/navbar.component";
import { NgIf } from "@angular/common";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'clinic';
  showNavbar: boolean = false;

  constructor(
    private router: Router,
  ) {

    router.events.subscribe((event: Event) => {
      let url = location.pathname.split('?')[0];
      if (event instanceof NavigationEnd) {
        if ((url.startsWith("/login") || url == '')) {
          this.showNavbar = false;
          return;
        }
        this.showNavbar = true;
      }
    })
  }
}



