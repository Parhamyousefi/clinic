import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  url = environment.url;
  constructor(
    private http: HttpClient,
  ) { }


  // login(data: any) {
  //   const uri = this.url + "api/user/login";
  //   const httpOptions = {
  //     headers: new HttpHeaders({
  //       "Content-Type": "application/json",
  //     }),
  //   };
  //   return this.http.post(uri, data, httpOptions);
  // }

  login(data: any) {
    const uri = this.url + "api/user/login";
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }
}
