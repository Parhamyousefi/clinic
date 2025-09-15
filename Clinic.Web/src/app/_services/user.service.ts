import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  url = environment.url;
  token: any = localStorage.getItem("token");
  constructor(
    private http: HttpClient,
  ) { }

  login(data: any) {
    const uri = this.url + "api/user/login";
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }

  getAppointments(data: any) {
    const uri = this.url + `api/Treatment/getAppointments`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }

  createAppointment(data: any) {
    const uri = this.url + `api/Treatment/createAppointment`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }


  getAppointmentTypes() {
    const token: any = localStorage.getItem("token");
    const uri = this.url + `api/treatment/getAppointmentTypes`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      }),
    };
    return this.http.get(uri, httpOptions);
  }

  getClinics() {
    const token: any = localStorage.getItem("token");
    const uri = this.url + `api/main/getClinics`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      }),
    };
    return this.http.get(uri, httpOptions);
  }

}
