import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  public selectedEditContact: Subject<any>;

  constructor(
    private http: HttpClient

  ) {
    this.selectedEditContact = new Subject();

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

  saveContact(data) {
    const uri = this.url + `api/Contact/saveContact`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
        responseType: 'text'
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }

  deleteContact(id) {
    const token: any = localStorage.getItem("token");
    const uri = this.url + `api/Contact/deleteContact/` + id;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      }),
    };
    return this.http.get(uri, httpOptions);
  }

  getContactPhone(contactId) {
    const token: any = localStorage.getItem("token");
    const uri = this.url + `api/Contact/getContactPhone/` + contactId;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      }),
    };
    return this.http.get(uri, httpOptions);
  }

  savePatientPhone(data) {
    const uri = this.url + `api/Contact/saveContactPhone`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
        responseType: 'text'
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }

  deleteContactPhone(contactId) {
    const token: any = localStorage.getItem("token");
    const uri = this.url + `api/Contact/deleteContactPhone/` + contactId;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + token,
      }),
    };
    return this.http.get(uri, httpOptions);
  }

}
