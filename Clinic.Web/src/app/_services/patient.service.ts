import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  url = environment.url;
  token: any = localStorage.getItem("token");

  constructor(
    private http: HttpClient,

  ) { }


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
}
