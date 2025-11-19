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

  getSubmitedAppointments(data: any) {
    const uri = this.url + `api/Report/getSubmitedAppointments`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }

  getSubmitedInvoices(data: any) {
    const uri = this.url + `api/Report/getSubmitedInvoices`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }

  getUnpaidInvoices(data: any) {
    const uri = this.url + `api/Report/getUnpaidInvoices`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }

  getOutPatientSummaryReport(data: any) {
    const uri = this.url + `api/Report/getOutPatientSummaryReport`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }

  getOutPatientReportBasedOnCreator(data: any) {
    const uri = this.url + `api/Report/getOutPatientReportBasedOnCreator`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }

  getIncomeReportDetails(data: any) {
    const uri = this.url + `api/Report/getIncomeReportDetails`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }



}
