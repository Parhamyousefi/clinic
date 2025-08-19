import { Component } from '@angular/core';
import { UserService } from '../_services/user.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  model: any = [];
  constructor(
    private userService: UserService,
  ) { }

  ngOnInit() {

  }

  async login() {
    let data = {
      username: this.model.userName,
      password: this.model.password
    }
    let res = await this.userService.login(data).toPromise();
  }
}
