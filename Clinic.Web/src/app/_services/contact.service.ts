import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(
    private http: HttpClient

  ) {


  }

  url = environment.url;
  token: any = localStorage.getItem("token");


  getContacts() {
    const token: any = localStorage.getItem("token");
    const uri = this.url + `api/Contact/getContacts`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      }),
    };
    return this.http.get(uri, httpOptions);
  }

  getContactTypes() {
    const token: any = localStorage.getItem("token");
    const uri = this.url + `api/Contact/getContactTypes`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      }),
    };
    return this.http.get(uri, httpOptions);
  }
}
