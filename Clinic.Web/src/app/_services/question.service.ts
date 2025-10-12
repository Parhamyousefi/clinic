import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  url = environment.url;
  token: any = localStorage.getItem("token");

  constructor(
    private http: HttpClient
  ) { }


  saveQuestionValue(data: any) {
    const uri = this.url + `api/Question/saveQuestionValue`;
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        Authorization: "Bearer " + this.token,
      }),
    };
    return this.http.post(uri, data, httpOptions);
  }


}
