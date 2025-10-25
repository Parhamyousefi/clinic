import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  constructor(
    private http: HttpClient
  ) { }
  url = environment.url;
  token: any = localStorage.getItem("token");

  getInvoicesByClinic(data: any) {
    const uri = this.url + `api/Report/getInvoicesByClinic`;
    const httpOptions = { 
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }
  getInvoicesByService(data: any) {
    const uri = this.url + `api/Report/getInvoicesByService`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }
  getAppointmentsAndUnpaidInvoices(data: any) {
    const uri = this.url + `api/Report/getAppointmentsAndUnpaidInvoices`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }

}
