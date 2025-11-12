import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import moment from 'moment-jalaali';


export const RoleMap = new Map([
  ['QE5#AGj@@UV+!Ad2@!msuv6!', 6], //Admin
  ['M)tCXD%Y@uEQTj*@FLmuD)P$', 7], //Secretary - Reception
  ['0N4hrN4RdZiCSgLrDGDY5lU3', 8], //Secretary - Timing
  ['cMI(3H!++nysmyT5CwXe*sVf', 9], //Doctor
  ['S%T6RLp2vtABa@rfTahIg8JZ', 10], //Technician
  ['R#cjGk$RjeXxy%m3bB5KxKUR', 11], //Medical Record
  ['@#(RES2^yQ%AwrJ9(P&rq7&X', 12], //Inpatient
  ['z&pMHUN^K3S#DR@P5+RZbKnB', 13], //Supervisor
  ['%N!jpwfkpMqdw&4W5)qAr79y', 14], //Finance
  ['es*y5#WQwPI3^VLhdcm#@T3E', 15], //Assistant
  ['x(CtV8C5@yarxzd$xPe$F%uv', 16], //Manager
  ['WJDNcw%+nv74^Zrms(G%E!@3', 17], //Secretary Mix
  ['H*5#H)Wf8LRTw%!a#(cK44kC', 18], //Manager - Test
  ['uM54#sJa(3$qjB64rjvT3x24', 19], //Research
])

@Injectable({
  providedIn: 'root'
})

export class UtilService {

  constructor(
    private http: HttpClient
  ) { }


  checkUserType() {
    let secret = localStorage.getItem('xP98_g#d94H0w');
    return RoleMap.get(secret) || -1;
  }



  getBase64(file: any) {
    if (!file) {
      return new Promise((resolve, reject) => {
        resolve('');
      });
    }
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => {
        resolve(reader.result);
      };
    });
  }

  getIranianHolidaysWithFridays(): Observable<string[]> {
    const apiKey = 'KQcB85KNJqb4EnsKohwMJfsqvZsn5l9B';
    const jalaliYear = moment().format('jYYYY');
    const gregorianYear = moment(`${jalaliYear}/01/01`, 'jYYYY/MM/DD').format('YYYY');
    const url = `https://calendarific.com/api/v2/holidays?api_key=${apiKey}&country=IR&year=${gregorianYear}`;

    return this.http.get<any>(url).pipe(
      map(response => {
        const official = response.response.holidays.map(h => {
          const jDate = moment(h.date.iso).format('jYYYY/jMM/jDD');
          return jDate;
        });

        const fridays: string[] = [];
        let date = moment(`${jalaliYear}/01/01`, 'jYYYY/jMM/jDD');
        while (date.jYear() === parseInt(jalaliYear)) {
          if (date.day() === 5) {
            fridays.push(date.format('jYYYY/jMM/jDD'));
          }
          date.add(1, 'day');
        }

        const all = [...new Set([...official, ...fridays])];
        return all.sort();
      })
    );
  }

}
