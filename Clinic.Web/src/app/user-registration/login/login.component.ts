import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../_services/user.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  model: any = [];
  token: any;
  constructor(
    private userService: UserService,
    private router: Router,
    private toastR: ToastrService
  ) { }

  ngOnInit() {
  }
  ngAfterViewInit(): void {
    const token = localStorage.getItem('token');
    if (token) {
      this.router.navigate(['/appointment']);

    }
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
          localStorage.setItem("userName", this.model.userName);
          localStorage.setItem('xP98_g#d94H0w', res.secretCode);
          this.router.navigate(["/appointment"]);
        }
      }
      else if (this.model.userName && !this.model.password) {
        this.toastR.error('خطا', 'رمز عبور را وارد نمایید')
      }
      else {
        this.toastR.error('خطا', 'نام کاربری و رمز عبور را وارد نمایید')
      }
    }
    catch { }
  }


  handleKeyUp(event) {
    if (event.key === 'Enter') {
      this.login()
    }
  }
}
