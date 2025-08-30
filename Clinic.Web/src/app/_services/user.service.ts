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

  getAppointments(clinicId: any, date: any) {
    const token: any = localStorage.getItem("token");
    const uri = this.url + `api/Treatments/getAppointments/` + clinicId + '/' + date;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      }),
    };
    return this.http.get(uri, httpOptions);
  }

  createAppointment(data: any) {
    const uri = this.url + `api/Treatments/createAppointment`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }

  getPatients() {
    const token: any = localStorage.getItem("token");
    const uri = this.url + `api/Patient/getPatients`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      }),
    };
    return this.http.get(uri, httpOptions);
  }

  getAppointmentTypes() {
    const token: any = localStorage.getItem("token");
    const uri = this.url + `api/treatments/getAppointmentTypes`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      }),
    };
    return this.http.get(uri, httpOptions);
  }

}
