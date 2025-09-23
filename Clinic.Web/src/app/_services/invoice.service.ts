import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  constructor(
    private http: HttpClient
  ) { }

  url = environment.url;
  token: any = localStorage.getItem("token");

  getInvoices() {
    const token: any = localStorage.getItem("token");
    const uri = this.url + `api/Invoice/getInvoices`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      }),
    };
    return this.http.get(uri, httpOptions);
  }

  saveInvoice(data) {
    const uri = this.url + `api/Invoice/saveInvoice`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
        responseType: 'text'
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }


  saveInvoiceItem(data) {
    const uri = this.url + `api/Invoice/saveInvoiceItem`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
        responseType: 'text'
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }
}
