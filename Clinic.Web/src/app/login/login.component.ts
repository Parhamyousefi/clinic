import { Component } from '@angular/core';
import { UserService } from '../_services/user.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  model: any = [];
  constructor(
    private userService: UserService,
    private router: Router,
    private toastR: ToastrService
  ) { }

  ngOnInit() {

  }

  async login() {
    try {
      if (this.model.userName && this.model.password) {
        let data = {
          Username: this.model.userName,
          Password: this.model.password
        }
        let res: any = await this.userService.login(data).toPromise();
        if (res.token && res.secretCode) {
          localStorage.setItem("token", res.token);
          this.router.navigate(["/appointment"]);
          // this.router.navigateByUrl('/appointment', { replaceUrl: true });
        }
      }
      else {
      }
    }
    catch { }
  }
}
